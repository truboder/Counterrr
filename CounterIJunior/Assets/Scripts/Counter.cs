using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Counter : MonoBehaviour
{
    private bool _isCounting = false;
    private float  _count = 0f;
    private float _delay = 0.5f;

    private Coroutine _coroutine;

    public float Count => _count;

    public event UnityAction CountChanged;

    private void Start()
    {
        _coroutine = StartCoroutine(TimeCounter(_delay));
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_isCounting)
            {
                StopCounting();
            }
            else
            {
                StartCounting();
            }
        }
    }

    private void StartCounting()
    {
        _isCounting = true;

        _coroutine = StartCoroutine(TimeCounter(_delay));
    }

    private void StopCounting()
    {
        _isCounting = false;

        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
    }

    private IEnumerator TimeCounter(float delay)
    {
        while (_isCounting)
        {
            _count++;

            CountChanged?.Invoke();

            Debug.Log(_count);
            yield return new WaitForSeconds(delay);
        }
    }
}
