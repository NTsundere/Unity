using System;

public class UIEventNotification
{
    public static event Action<UIValueType, float> ValueChanged;
    public static event Action HealthChanged;

    public static void OnValueChanged(UIValueType valueType, float value)
    {
        ValueChanged?.Invoke(valueType, value);
    }    
    
    public static void OnHealthChanged()
    {
        HealthChanged?.Invoke();
    }
}
