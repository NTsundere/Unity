using UnityEngine;

public class RocketControl2 : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float _speed = 5f;
    [SerializeField] private float _rotationSpeed = 1;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float sideForce = Input.GetAxis("Horizontal")*_rotationSpeed;
        float forwardForce = Input.GetAxis("Vertical") * _speed;

        rb.AddRelativeForce(-forwardForce, 0, 0);
        rb.AddRelativeTorque(0, sideForce, 0);
    }
}
