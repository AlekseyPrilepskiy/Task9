using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public event Action MouseButtonPressed;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MouseButtonPressed?.Invoke();
        }
    }
}

