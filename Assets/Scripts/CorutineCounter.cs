using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CorutineCounter : MonoBehaviour
{
    [SerializeField] private float _timeStep = 0.5f;
    private int counter = 0;
    private bool isPaused = true;
    private Coroutine coroutine;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("������������ ������ ���.");

            if (isPaused == false)
            {
                StopCoroutine(coroutine);
                isPaused = true;
                Debug.Log("������� �� �����. ��������: " + counter);
            }
            else
            {
                coroutine = StartCoroutine(Count());
                isPaused = false;
            }
        }
    }

    IEnumerator Count()
    {
        while(true)
        {
            counter++;
            Debug.Log("�������: " +  counter);
            yield return new WaitForSeconds(_timeStep);
        }
    }
}
