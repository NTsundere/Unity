using UnityEngine;
using UnityEngine.AI;

public class PlayerControls : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Camera _camera;
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
              _agent.SetDestination(hitInfo.point);
            }
        }
    }
}
