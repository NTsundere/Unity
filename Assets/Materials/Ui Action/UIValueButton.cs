using UnityEngine;

public class UIValueButton : MonoBehaviour
{
    [SerializeField] private UIValueType _type;
    [SerializeField] private bool _isAddButton = true;
    [SerializeField] private float _amount;

    private UIValue _targetValue;

    public void Initialize(UIValue gold, UIValue diamond, UIValue energy)
    {
        _targetValue = _type switch
        {
            UIValueType.Gold => gold,
            UIValueType.Diamond => diamond,
            UIValueType.Energy => energy,
            _ => gold
        };
    }

    public void OnButtonClick()
    {
        if (_isAddButton)
        {
            _targetValue.Add(_amount);
        }
        else
        {
            _targetValue.Reduce(_amount);
        }
    }
}
