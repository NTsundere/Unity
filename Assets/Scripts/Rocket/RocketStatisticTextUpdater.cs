using TMPro;
using UnityEngine;

public class RocketStatisticTextUpdater : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _healthText;
    [SerializeField] private RocketHealth _rocketHealth;

    private void Start()
    {
        RocketEventNotification.ScoreChanged += RedrawText;
        RocketEventNotification.HealthChanged += RedrawText;
    }

    private void RedrawText()
    {
        if (_scoreText != null && _healthText != null)
        {
            _scoreText.text = $"Score: " + ScoreCollect.Score.ToString();
            _healthText.text = $"Health: " + _rocketHealth.Health.ToString();
        }
    }

}