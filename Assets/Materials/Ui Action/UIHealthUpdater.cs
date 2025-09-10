using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthUpdater : MonoBehaviour
{
    [SerializeField] private TMP_Text _healthText;
    [SerializeField] private Image[] _hearts;
    [SerializeField] private Image _healthBar;

    private UIValue _healthValue; // в будущем можно создать отдельный класс который содержит жизни, и его ссылку прокидывать через юнити, или через zenject

    private bool _isActive = false;
    private bool _inProgress = false;

    private void Start()
    {
        _healthValue = new UIValue(UIValueType.Health);
        UIEventNotification.HealthChanged += HealthUpdater;
    }

    private IEnumerator ChangeHealth()
    {
        while (_healthValue.Value >= 0)
        {
            if (_isActive)
            {
                _inProgress = true;
                _healthValue.Reduce(0.05f);
                UIEventNotification.OnHealthChanged();
            }
            yield return new WaitForSeconds(0.05f);
        }
        _isActive = false;
        _inProgress = false;
    }

    private void HealthUpdater()
    {
        _healthText.text = _healthValue.Value.ToString("F1");
        for(int i = 0;  i < _hearts.Length; i++)
        {
            if (i >= _healthValue.Value)
            {
                _hearts[i].enabled = false;
            } 
            else
            {
                _hearts[i].enabled = true;
            }
        }
        _healthBar.fillAmount = _healthValue.Value / 10;
    }

    public void ResetHealth()
    {
        _healthValue.Set(10f);
        UIEventNotification.OnHealthChanged();
        _healthText.text = "10";
        for (int i = 0; i < _hearts.Length; i++)
        {
             _hearts[i].enabled = true;
        }
        _healthBar.fillAmount = 1f;
    }

    public void StartHealthChange()
    {
        if (_inProgress == false)
        {
            _isActive = true;
            StartCoroutine(ChangeHealth());
        }
    }    

    public void PlayHealthChange()
    {
        _isActive = true;
    }

    public void StoptHealthChange()
    {
        _isActive = false;
    }
}
