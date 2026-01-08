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

    private void Start()
    {
        StartCoroutine(CounterRoutime(0.5f));
    }

    private IEnumerator CounterRoutime(float dely)
    {

        while (true)
        {
            _text.text = _count.ToString("");
            _count++;


            if (_isPaused)
            {
                yield return new WaitForSeconds(10f);
                _isPaused = false;
            }
            else
            {
                yield return new WaitForSeconds(dely);
            }
        }

    }

    public void OnButtonClick()
    {
        _count += 10;
        _clickCount++;

        if (_clickCount == 2)
        {
            _isPaused = true;
            _clickCount = 0;
        }

        _text.text = _count.ToString("");
    }
}
