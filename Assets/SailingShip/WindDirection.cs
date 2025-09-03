using System.Collections;
using TMPro;
using UnityEngine;

public class WindDirection : MonoBehaviour
{
    [SerializeField] private TMP_Text directionText;

    private Vector3 windDirection;

    private void Start()
    {
        StartCoroutine(ChangeWindDirection());
    }
    private IEnumerator ChangeWindDirection()
    {
        windDirection = new Vector3(Random.Range(0, 360), 0, Random.Range(0, 360));
        Debug.Log(windDirection);
        yield return new WaitForSeconds(10f);
        StartCoroutine(ChangeWindDirection());

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, windDirection);
    }
}
