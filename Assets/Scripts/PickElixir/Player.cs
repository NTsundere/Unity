using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform _hand;
    [SerializeField] private float _speed = 2f;

    private Rigidbody _rigidbody;
    private Elixir _currentElixir;

    private bool _isTakenNow = false;

    private float elixirTakeCooldown = 0.5f;
    private float elixirTakeTime= 0f;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (elixirTakeTime > 0f)
        {
            elixirTakeTime -= Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.E) && _currentElixir != null)
        {
            _currentElixir.Use();
            _isTakenNow = false;
            _currentElixir = null;
            elixirTakeTime = elixirTakeCooldown;
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            transform.Translate(transform.right * _speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.rotation = Quaternion.Euler(0f, -90f, 0f);
            transform.Translate(-transform.forward * _speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            transform.Translate(-transform.right * _speed * Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.rotation = Quaternion.Euler(0f, 90f, 0f);
            transform.Translate(transform.forward * _speed * Time.deltaTime);
        }
    }

    private void TakeElixir(Elixir elixir)
    {
        _currentElixir = Instantiate(elixir, _hand.position + new Vector3(0.5f, 0, 0), Quaternion.identity, transform);
        //_currentElixir.transform.rotation = Quaternion.EulerRotation(0,0,0); ???

        _isTakenNow = true;
        Debug.Log($"Taked: {_currentElixir}");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Elixir>(out Elixir elixir) && !_isTakenNow && elixirTakeTime <= 0)
        {
            TakeElixir(elixir);
            Destroy(other.gameObject);
        }
    }
}
