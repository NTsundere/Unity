using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMover : MonoBehaviour
{
    private Animator _animator;
    private NavMeshAgent _agent;
    private Rigidbody _rigidbody;
    
    private bool _isAgentLosed = false;
    private bool _isDied = false;

    public event Action Died;

    public void OnDied()
    {
        Died?.Invoke();
    }
    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
        StartCoroutine(MoveAgent());

        Died += Die;
    }

    private void OnDestroy()
    {
        Died -= Die;
    }

    private IEnumerator MoveAgent()
    {
        while (_isAgentLosed == false)
        {
            _agent.SetDestination(new Vector3(UnityEngine.Random.Range(0, 40), 0, UnityEngine.Random.Range(0, 40)));
            yield return new WaitForSeconds(10f);
        }
    }

    private void Die()
    {
        if (_isDied == false)
        {
            _isAgentLosed = true;
            _isDied = true;
            _agent.SetDestination(transform.position);
            _animator.Play("Ded");
            _agent.enabled = false;
            Collider collider = GetComponent<Collider>();
            collider.isTrigger = true;
        }
    }
}
