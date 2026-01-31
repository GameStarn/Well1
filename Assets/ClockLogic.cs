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

    private WaitForSeconds _updateWait;
    private WaitForSeconds _pauseWait;

    private void Awake()
    {
        _updateWait = new WaitForSeconds(_updateInterval);
        _pauseWait = new WaitForSeconds(_pauseDuration);
    }

    private void OnEnable() => StartCoroutine(CounterRoutime());
    private void OnDisable() => StopAllCoroutines();

    public void AddBonus()
    {
        _count += _bonusAmount;
        _clickCount++;

        if (_clickCount >= _clicksToPause)
        {
            _isPaused = true;
            _clickCount = 0;
        }

        OnCountChanged?.Invoke(_count);
    }

    private IEnumerator CounterRoutime()
    {
        while (true)
        {
            OnCountChanged?.Invoke(_count);
            _count++;

            if (_isPaused)
            {
                yield return _pauseWait;
                _isPaused = false;
            }
            else
            {
                yield return _updateWait;
            }
        }
    }
}