using System.Collections;
using TMPro;
using UnityEngine;

public class SailHandler : MonoBehaviour
{
    [SerializeField] private WindDirection _windDirection;
    [SerializeField] private float _rotationSpeed = 2f;
    [SerializeField] private Transform _ship;
    [SerializeField] private Transform _sailArrow;
    [SerializeField] private TMP_Text _shipSpeedText;
    [SerializeField] private Rigidbody rb;

    private float _defaultShipSpeed = 5f;
    private float _wind;
    private float _targetSailAngle;


    private void Start()
    {
        
    }

    private void Update()
    {
        _wind = _windDirection.Wind;

        // ���������� ��������� �������
        float horizontal = Input.GetAxis("Horizontal");
        _targetSailAngle = horizontal * 80f; // ������������ ������������ ���� �������� �������
        transform.localRotation = Quaternion.Slerp(transform.localRotation,
            Quaternion.Euler(0, _targetSailAngle, 0), _rotationSpeed * Time.deltaTime);

        // ��������� ���������� ����������� ������� (��������� ������� ������� � �������)
        Vector3 globalSailDirection = _ship.rotation * transform.localRotation * Vector3.forward;

        // ����������� ����������� � ���� (0-360 ��������)
        float sailGlobalAngle = Vector3.SignedAngle(Vector3.forward, globalSailDirection, Vector3.up);
        if (sailGlobalAngle < 0) sailGlobalAngle += 360;

        // ������������ ������� �� �������
        _sailArrow.rotation = Quaternion.Euler(0, 0, -sailGlobalAngle);

        // ������ ������������� �������
        float awa = (_wind - sailGlobalAngle + 360) % 360;
        float effectiveAwa = Mathf.Abs(awa - 180);
        float angularDifference = Mathf.Min(effectiveAwa, 360 - effectiveAwa);
        float efficiency = Mathf.Max(0, 1 - (angularDifference / 80));

        // ���������� �������� �������
        float shipSpeed = _defaultShipSpeed * efficiency;
        _shipSpeedText.text = $"��������: {shipSpeed:F1}";
        rb.AddForce(_ship.forward * shipSpeed * 100 * Time.deltaTime);
    }

    // ���������� ��������� �������
    private void FixedUpdate()
    {
        float turn = Input.GetAxis("Horizontal") * _rotationSpeed;
        Vector3 newAngularVelocity = _ship.up * turn;
        rb.angularVelocity = newAngularVelocity;
    }
}
