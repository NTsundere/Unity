using UnityEngine;

public class UIResourceCreator : MonoBehaviour
{
    [SerializeField] private UIValueButton[] _valueButtons;

    private UIValue _gold;
    private UIValue _diamond;
    private UIValue _energy;
    private UIValue _health;  

    private void Start()
    {
        _gold = new UIValue(UIValueType.Gold);
        _diamond = new UIValue(UIValueType.Diamond);
        _energy = new UIValue(UIValueType.Energy);
        _health = new UIValue(UIValueType.Health);

        foreach (UIValueButton button in _valueButtons)
        {
            button.Initialize(_gold, _diamond, _energy);
        }
    }
}
