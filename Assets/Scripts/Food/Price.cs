using System;
using UnityEngine;

namespace Devotion.Scripts.Food
{
    [Serializable]
    [CreateAssetMenu(fileName = "FoodPrice", menuName = "Datas/Food/Price")]
    public class Price : ScriptableObject
    {
        public string FoodName;
        public int FoodPrice;
    }
}