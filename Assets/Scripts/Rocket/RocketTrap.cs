using UnityEngine;

public class RocketTrap : MonoBehaviour
{
    [SerializeField] private float _damage = 1f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<RocketControl>(out RocketControl rocketControl) && other.TryGetComponent<RocketHealth>(out RocketHealth rocketHealth))
        {
            if (rocketHealth.Health <= 0)
            {
                Destroy(rocketControl);
            }
            else
            {
                rocketHealth.Reduce(_damage);
            }
            Destroy(gameObject);
        }
    }
}
