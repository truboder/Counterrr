using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class View : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textCounter;
    [SerializeField] private Counter _counter;

    private void OnEnable()
    {
        _counter.CountChanged += DisplayCounter;
    }

    private void OnDisable()
    {
        _counter.CountChanged -= DisplayCounter;
    }

    private void DisplayCounter()
    {
        float count = _counter.Count;
        _textCounter.text = count.ToString();
    }
}
