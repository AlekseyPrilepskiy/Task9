using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _timeStep = 0.5f;
    [SerializeField] private InputReader _inputReader;

    private int _currentNumber;
    private bool _isStart;
    private Coroutine _coroutine;
    private WaitForSeconds _waitTime;

    public event Action<int> ValueChanged;

    private void Start()
    {
        _currentNumber = 0;
        _isStart = false;
        _waitTime = new WaitForSeconds(_timeStep);
    }

    private void OnEnable()
    {
        _inputReader.MouseButtonPressed += TogglePause;
    }

    private void OnDisable()
    {
        _inputReader.MouseButtonPressed -= TogglePause;
    }

    public void TogglePause()
    {
        if (_isStart)
        {
            _isStart = false;
            Stop();
        }
        else
        {
            _isStart = true;
            Run();
        }
    }

    private void Run()
    {
        if (_coroutine == null)
        {
            _coroutine = StartCoroutine(Counting());
        }
    }

    private void Stop()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }

    private IEnumerator Counting()
    {
        while (true)
        {
            _currentNumber++;
            ValueChanged?.Invoke(_currentNumber);

            yield return _waitTime;
        }
    }
}

