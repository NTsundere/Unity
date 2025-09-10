using UnityEngine;

public class RocketControl : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _rotationSpeed = 1;
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        RocketEventNotification.Died += Die;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float sideForce = Input.GetAxis("Horizontal")*_rotationSpeed;
        float forwardForce = Input.GetAxis("Vertical") * _speed;

        rb.AddRelativeForce(0, 0, forwardForce);
        rb.AddRelativeTorque(0, sideForce, 0);
    }


    private void Die()
    {
        if (TryGetComponent<RocketControl>(out RocketControl control))
        {
            Destroy(control);
        }
    }
}
