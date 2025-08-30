using UnityEditor.SceneManagement;
using UnityEngine;

public class Bomb : Elixir
{
    private Rigidbody rb;
    public override void Use()
    {
        Debug.Log("Used a Bomb!");
        //Rigidbody rb = gameObject.AddComponent<Rigidbody>();

        rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;
        transform.SetParent(null);
        //rb.useGravity = true;
        Vector3 throwDirection = transform.right;
        rb.AddForce(throwDirection*2, ForceMode.Impulse);
        //rb.linearVelocity = throwDirection*2000;
    }
}
