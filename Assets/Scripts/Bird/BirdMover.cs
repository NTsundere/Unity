using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public partial class BirdMover : MonoBehaviour
{ 
    [SerializeField] private float _force = 900;
    [SerializeField] private Canvas _restartWindow;

    private Rigidbody _birdrb;

    private float _score = 0f;
    private bool _isDied = false;

    public float Score => _score; 

    private void Start()
    {
        _birdrb = GetComponent<Rigidbody>();
        _restartWindow.enabled = false;

        BirdEventNotification.Died += Die;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && gameObject != null && _isDied == false) {
            _birdrb.AddForce(0, _force, 0);
            _score += 1;

            BirdEventNotification.OnScoreChanged();
        }
        
    }

    private void Die()
    {
        _restartWindow.enabled = true;
        _isDied = true;
    }
}
