using System.Collections.Generic;
using UnityEngine;

namespace Devotion.Scripts.Food
{
    public class FoodVisualizer : MonoBehaviour
    {
        [SerializeField]
        private string FoodName;

        [SerializeField]
        private List<GameObject> FoodParts = new List<GameObject>();

        public void SetEnable(bool value)
        {
            gameObject.SetActive(value);
            FoodParts.ForEach(x => x.SetActive(value));
        }
    }
}