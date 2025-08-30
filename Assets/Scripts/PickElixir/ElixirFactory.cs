using UnityEngine;

public class ElixirFactory : MonoBehaviour
{
    [SerializeField] private Transform _spawnPoint;

    public void Create(Elixir elixir)
    {
        Elixir instance = Instantiate(elixir);
        instance.SpawnTo(_spawnPoint.position);
    }
}
