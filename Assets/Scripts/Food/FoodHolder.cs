using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class FoodHolder : MonoBehaviour
{
    [SerializeField]
    private string FoodName;

    [SerializeField]
    public List<MonoFoodPlace> PlacesForFood = new List<MonoFoodPlace>();

    public void TryToPlaceFood()
    {
        foreach(MonoFoodPlace place in PlacesForFood)
        {
            if (place.PlaceFood(new Food(FoodName)))
                return;
        }
    }
}
