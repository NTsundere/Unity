using UnityEngine;

public class PlayerDiamond : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(-transform.right * _speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(-transform.forward * _speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(transform.right * _speed * Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(transform.forward * _speed * Time.deltaTime);
        }
    }
}
