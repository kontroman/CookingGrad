using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayTask : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private GameObject _checkbox;
    [SerializeField] private TextMeshProUGUI _title;

    public void Init(LevelTask task)
    {
        string postfix = task.HasCounter ? task.Count.ToString() : " ";

        _icon.sprite = task.Icon;
        _title.text = task.Discription + postfix;

        if (_checkbox)
            _checkbox.SetActive(task.IsCompleted);
    }

}
