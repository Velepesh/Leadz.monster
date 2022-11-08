using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class DifficultySelection : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown _dropdown;

    private const string DIFFICULT_INDEX = "DifficultIndex";

    private DifficultyType _type = DifficultyType.Easy;

    private int _index
    {
        get { return PlayerPrefs.GetInt(DIFFICULT_INDEX, 0); }
        set { PlayerPrefs.SetInt(DIFFICULT_INDEX, value); }
    }

    public event UnityAction<DifficultyType> DifficaltySelected;

    private void Start()
    {
        UpdateDropdown(_index);
    }

    public void SelectDifficulty(int value)
    {
        if (value == 0)
            _type = DifficultyType.Easy;
        else if (value == 1)
            _type = DifficultyType.Normal;
        else if (value == 2)
            _type = DifficultyType.Hard;

        _index = value;
        UpdateDropdown(value);

        DifficaltySelected?.Invoke(_type);
    }

    public void UpdateDropdown(int value)
    {
        _dropdown.value = value;
    }
}