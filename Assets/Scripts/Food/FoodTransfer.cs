using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class FoodTransfer : MonoBehaviour
{
    public bool transferOnlyCookedFood = true;

    public List<MonoFoodPlace> places = new List<MonoFoodPlace>();

    PlaceForFood _place = null;

    private void Start()
    {
        _place = GetComponent<PlaceForFood>();
    }

    public void TransferFood()
    {
        var food = _place.CurrentFood;

        if (food == null) return;

        if (transferOnlyCookedFood && (food.CurrentStatus != Food.FoodStatus.Cooked)){
            _place.PlaceFood(food);
        }

        foreach(var place in places)
        {
            if (!place.PlaceFood(food))
                continue;
            _place.FreePlace();
            return;
        }
    }
}
