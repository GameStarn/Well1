using TMPro;
using UnityEngine;

public class ClockView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    public void UpdateDisplay(int value)
    {
        _text.text = value.ToString();
    }
}