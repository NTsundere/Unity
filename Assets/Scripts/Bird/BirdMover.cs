using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdMover : MonoBehaviour
{ 
    [SerializeField] private float _force = 900;
    [SerializeField] private GameObject _restartWindow;
    private Rigidbody _birdrb;
    private float _score = 0f;

    public float Score => _score; 

    public event Action ScoreChanged;

    private void Start()
    {
        _birdrb = GetComponent<Rigidbody>();
        _restartWindow.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && gameObject != null) {
            _birdrb.AddForce(0, _force, 0);
            _score += 1;
            ScoreChanged?.Invoke();
        }
        
    }

    public void Die()
    {
        _restartWindow.SetActive(true);
        Destroy(transform.gameObject);
    }
}
