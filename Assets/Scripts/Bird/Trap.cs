using UnityEngine;

public class Trap : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<BirdMover>(out BirdMover birdMover))
        {
            BirdEventNotification.OnDied();
        }
    }
}
