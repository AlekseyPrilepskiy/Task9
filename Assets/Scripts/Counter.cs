using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

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

        _inputReader.MouseButtonPressed += ToggleCounter;
    }

    public void ToggleCounter()
    {
        if (_isStart)
        {
            _isStart = false;
            StopCounter();
        }
        else
        {
            _isStart = true;
            StartCounter();
        }
    }

    private void StartCounter()
    {
        if (_coroutine == null)
        {
            _coroutine = StartCoroutine(CounterUp());
        }
    }

    private void StopCounter()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _coroutine = null;
        }
    }

    private IEnumerator CounterUp()
    {
        while (true)
        {
            _currentNumber++;
            ValueChanged?.Invoke(_currentNumber);

            yield return _waitTime;
        }
    }
}

