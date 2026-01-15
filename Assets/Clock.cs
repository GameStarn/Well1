using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Clock : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    private int _count = 0;
    private int _clickCount = 0;
    private bool _isPaused = false;

    private float _updateCoroutine = 0.5f;
    private float _delayTime = 10f;
    private int _increaseCount = 10;
    private int _numberOfClicks = 2;

    private void OnEnable()
    {
        StartCoroutine(CounterRoutime(_updateCoroutine));
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            _count += _increaseCount;
            _clickCount++;

            if (_clickCount == _numberOfClicks)
            {
                _isPaused = true;
                _clickCount = 0;
            }

            _text.text = _count.ToString("");
        }
    }

    private IEnumerator CounterRoutime(float delay)
    {
        WaitForSeconds normalDelay = new WaitForSeconds(delay);
        WaitForSeconds pauseDelay = new WaitForSeconds(_delayTime);

        while (enabled)
        {
            _text.text = _count.ToString("");
            _count++;


            if (_isPaused)
            {
                yield return pauseDelay;
                _isPaused = false;
            }
            else
            {
                yield return normalDelay;
            }
        }
    }
}
