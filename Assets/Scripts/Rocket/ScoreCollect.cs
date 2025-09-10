using Unity.VisualScripting;
using UnityEngine;

public class ScoreCollect : MonoBehaviour
{
    public static float Score;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Score += 1;
            Destroy(gameObject);

            RocketEventNotification.OnScoreChanged();
        }
    }
}
