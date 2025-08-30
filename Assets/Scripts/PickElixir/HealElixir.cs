using UnityEngine;

public class HealElixir : Elixir
{
    public override void Use()
    {
        Debug.Log("Used Heal Elixir");
        base.Use();
    }
}
