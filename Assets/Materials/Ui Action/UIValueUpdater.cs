using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIValueUpdater : MonoBehaviour
{
    [SerializeField] private TMP_Text _goldText;
    [SerializeField] private TMP_Text _diamondText;
    [SerializeField] private TMP_Text _energyText;

    private Dictionary<UIValueType, TMP_Text> _valueMap;

    private void Start()
    {
        _valueMap = new Dictionary<UIValueType, TMP_Text>()
        {
            {UIValueType.Gold, _goldText },
            {UIValueType.Diamond, _diamondText },
            {UIValueType.Energy, _energyText },
        };

        UIEventNotification.ValueChanged += OnValueChanged;
    }

    private void OnValueChanged(UIValueType type, float newValue)
    {
        if (_valueMap.TryGetValue(type, out var textField))
        {
            textField.text = newValue.ToString();
        }
    }

    private void OnDestroy()
    {
        UIEventNotification.ValueChanged -= OnValueChanged;
    }
}
