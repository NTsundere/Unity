using System.Collections;
using TMPro;
using UnityEngine;

public class WindDirection : MonoBehaviour
{
    [SerializeField] private TMP_Text _directionText;
    [SerializeField] private Transform _compassArrow;
    private float _windDirection;

    public float Wind => _windDirection;

    private void Start()
    {
        _directionText.enabled = false;
        StartCoroutine(ChangeWindDirection());
    }
    private IEnumerator ChangeWindDirection()
    {
        _windDirection = Random.Range(0, 360);
        Quaternion newArrowRotation = Quaternion.Euler(0,0, _windDirection);
        float progress = 0f;
        _directionText.enabled = true;
        while (progress < 2f) 
        {
            progress += Time.deltaTime;
            _compassArrow.rotation = Quaternion.Lerp(_compassArrow.rotation, newArrowRotation, progress/5);
            yield return null;
        }
        _compassArrow.transform.rotation = newArrowRotation;
        Debug.Log(_windDirection);
        yield return new WaitForSeconds(2f);
        _directionText.enabled = false;
        yield return new WaitForSeconds(8f);
        StartCoroutine(ChangeWindDirection());

    }
}
