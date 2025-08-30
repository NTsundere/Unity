using UnityEngine;

public class RocketTrap : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<RocketControl>(out RocketControl rocket))
        {
            Destroy(rocket);
            Destroy(gameObject);
        }
    }
}
