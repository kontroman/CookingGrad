using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "LevelData", menuName = "Datas/Game/LevelTasks")]
public class LevelTask : SerializedScriptableObject
{
    [EnumToggleButtons, GUIColor(0.9f, 1, 1)]
    public Quest MainTask;

    [EnumToggleButtons, GUIColor(0.9f, 1, 1)]
    public QuestType Type;

    [PreviewField][TableColumnWidth(60, resizable:false)]
    public Sprite Icon;

    [TextArea(2, 5)]
    public string Discription;

    public bool HasCounter;

    [ShowIf("HasCounter")]
    public int Count;

    public bool IsCompleted;
}

public enum Quest
{
    ServeCustomers,
    ServeFoods,
    CollectMoney,
    NoOvercooked,
    NoTrash,
    NoUnhappy,
    CountHappy
}

public enum QuestType
{
    Main,
    Secondary,
    Additional
}