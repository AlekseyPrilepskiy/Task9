using TMPro;
using UnityEngine;

public class View : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textMesh;
    [SerializeField] private Counter _counter;

    private void Start()
    {
        _counter.UpdateCounter += OnUpdateCounter;
    }

    private void OnUpdateCounter(int number)
    {
        _textMesh.text = _counter.CurrentNumber.ToString();
    }
}
