using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ErrorMessage : MonoBehaviour
{
    [SerializeField] ItemEventSO errorMessage;
    [SerializeField] TextMeshProUGUI _errorText;

    private void OnEnable()
    {
        errorMessage.OnRaiseEvent += DisplayError;
    }
    private void OnDisable()
    {
        errorMessage.OnRaiseEvent -= DisplayError;
    }
    private void Start()
    {
        _errorText.text = "";
    }
    void DisplayError(string message)
    {
        StopAllCoroutines();
        StartCoroutine(RunMessage(message));
    }

    IEnumerator RunMessage(string message)
    {
        _errorText.text = "";
        _errorText.text = message;
        yield return new WaitForSeconds(5f);
        _errorText.text = "";
    }
}
