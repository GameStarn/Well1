using UnityEngine;

public class ClockPresenter : MonoBehaviour
{
    [SerializeField] private ClockLogic _clockLogic;
    [SerializeField] private InputHandler _inputHandler;
    [SerializeField] private ClockView _clockView;

    private void OnEnable()
    {
        _inputHandler.OnClickDetecten += _clockLogic.AddBonus;
        _clockLogic.OnCountChanged += _clockView.UpdateDisplay;
    }

    private void OnDisable()
    {
        _inputHandler.OnClickDetecten -= _clockLogic.AddBonus;
        _clockLogic.OnCountChanged -= _clockView.UpdateDisplay;
    }
}