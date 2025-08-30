using UnityEngine;

public class ElixirComponent : MonoBehaviour
{
    [SerializeField] private ElixirType _type;
    private Elixir elixir;

    private void Start()
    {
        elixir = new Elixir();
        Use(elixir);
    }

    public void Use(Elixir elixir)
    {
        elixir.Use();
    }
}
