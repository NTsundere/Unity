using UnityEngine;

public class Elixir : MonoBehaviour
{
    public virtual void Use()
    {
        Destroy(gameObject);
    }

    public void SpawnTo(Vector3 spawnPoint)
    {
        Vector2 randomPoint = Random.insideUnitCircle * 3;
        transform.position= spawnPoint + new Vector3(randomPoint.x, 0, randomPoint.y);
    }
}
