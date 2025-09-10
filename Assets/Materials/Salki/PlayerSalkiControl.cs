using UnityEngine;
using UnityEngine.AI;

public class PlayerSalkiControl : MonoBehaviour
{
    [SerializeField] private GameObject _mouseUI;

    private NavMeshAgent _agent;
    private Camera _camera;
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _camera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                _agent.SetDestination(hitInfo.point);
                _mouseUI.transform.position = hitInfo.point;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent<EnemyMover>(out EnemyMover enemyMover))
        {
            enemyMover.OnDied();
        }
    }
}
