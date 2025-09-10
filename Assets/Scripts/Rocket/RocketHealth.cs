using UnityEngine;

public class RocketHealth : MonoBehaviour
{
    [SerializeField] private float _health =3f;

    public float Health => _health;

    public void Add(float amount)
    {
        _health += amount;
        RocketEventNotification.OnHealthChanged();
    }

    public void Reduce(float amount)
    {
        _health -= amount;
        RocketEventNotification.OnHealthChanged();
    }
}
