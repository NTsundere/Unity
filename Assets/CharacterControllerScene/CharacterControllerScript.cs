using UnityEngine;

public class CharacterControllerScript : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    
    private CharacterController _characterController;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        _characterController.Move(move*_speed*Time.deltaTime);
    }
}
