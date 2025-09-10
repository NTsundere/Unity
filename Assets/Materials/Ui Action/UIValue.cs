public class UIValue
{
    private UIValueType _valueType;
    private float _value;

    public float Value => _value;

    public UIValue(UIValueType valueType, float value = 10)
    {
        _valueType = valueType;
        _value = value;
    }

    public void Add(float amount)
    {
        _value += amount;
        UIEventNotification.OnValueChanged(_valueType, _value);
    }

    public void Reduce(float amount)
    {
        _value -= amount;
        UIEventNotification.OnValueChanged(_valueType, _value);
    }

    public void Set(float amount)
    {
        _value = amount;
        UIEventNotification.OnValueChanged(_valueType, _value);
    }
}
