using System;
using System.Collections;
using UnityEngine;


public class ClockLogic : MonoBehaviour
{
    public event Action<int> OnCountChanged;

    private int _count = 0;
    private int _clickCount = 0;
    private bool _isPaused = false;

    private float _updateInterval = 0.5f;
    private float _pauseDuration = 10f;
    private int _bonusAmount = 10;
    private int _clicksToPause = 2;

    private void OnEnable() => StartCoroutine(CounterRoutime());
    private void OnDisable() => StopAllCoroutines();

    public void AddBonus()
    {
        _count += _bonusAmount;
        _clickCount++;

        if (Input.GetMouseButtonDown(0))
        {

            if (_clickCount == _clicksToPause)
            {
                _isPaused = true;
                _clickCount = 0;
            }

            OnCountChanged?.Invoke(_count);
        }
    }

    private IEnumerator CounterRoutime()
    {
        while (true)
        {
            OnCountChanged?.Invoke(_count);
            _count++;

            if (_isPaused)
            {
                yield return new WaitForSeconds(_pauseDuration);
                _isPaused = false;
            }
            else
            {
                yield return new WaitForSeconds(_updateInterval);
            }
        }
    }
}