using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;

    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out RaycastHit hitInfo, 100f)) 
            {
                Collider[] hitColliders = Physics.OverlapSphere(hitInfo.point, _explosionRadius);
                foreach (var collider in hitColliders)
                {
                    Rigidbody rb = collider.GetComponent<Rigidbody>();
                    if(rb != null)
                    {
                        rb.AddExplosionForce(_explosionForce, hitInfo.point, _explosionRadius);
                    }
                }
            }
        }
    }
}
