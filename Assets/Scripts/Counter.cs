using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private float _timeStep = 0.5f;

    private bool _isPaused;
    private Coroutine _coroutine;

    public event Action<int> UpdateCounter;

    public int CurrentNumber { get; private set; }

    private void Start()
    {
        _isPaused = true;
        CurrentNumber = 0;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Пользователь прожал ЛКМ.");

            if (_isPaused == false)
            {
                StopCoroutine(_coroutine);
                _isPaused = true;
            }
            else
            {
                _coroutine = StartCoroutine(CounterUp());
                _isPaused = false;
            }
        }
    }

    IEnumerator CounterUp()
    {
        while(true)
        {
            CurrentNumber++;
            UpdateCounter?.Invoke(CurrentNumber);

            yield return new WaitForSeconds(_timeStep);
        }
    }
}
