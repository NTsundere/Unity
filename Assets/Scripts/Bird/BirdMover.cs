using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdMover : MonoBehaviour
{ 
    [SerializeField] private float _force = 900;
    private Rigidbody _birdrb;

    private void Start()
    {
        _birdrb = GetComponent<Rigidbody>();
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Debug.Log("1");
            _birdrb.AddForce(0, _force, 0);
        }
        
    }
    private void FixedUpdate()
    {
    }
    public void Die()
    {
        Destroy(transform.gameObject);
        SceneManager.LoadScene("Bird");
    }
}
