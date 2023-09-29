using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "FoodPrice", menuName = "Datas/Food/Price")]
public class Price : ScriptableObject
{
    public string FoodName;
    public int FoodPrice;
}
