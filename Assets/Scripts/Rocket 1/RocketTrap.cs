using UnityEngine;

public class RocketTrap2 : MonoBehaviour
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
