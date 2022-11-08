using System;
using TMPro;
using UnityEngine;

public class View : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;

    private void Awake()
    {
        try
        {
            Validate();
        }
        catch (Exception e)
        {
            enabled = false;
            throw e;
        }
    }

    protected void UpdateText(string name, int value)
    {
        _text.text = $"{name} {value.ToString()}";
    }

    private void Validate()
    {
        if (_text == null)
            throw new InvalidOperationException();
    }
}