using System;
using UnityEngine;

public sealed class FoodPresenter : MonoBehaviour
{
    [Serializable]
    public class FoodVisualizerSet
    {
        public GameObject EmptyFood = null;
        public FoodVisualizer RawFood = null;
        public FoodVisualizer CookedFood = null;
        public FoodVisualizer OvercookedFood = null;

        public void HideFood()
        {
            if (EmptyFood != null)
                EmptyFood.SetActive(false);

            RawFood?.SetEnable(false);
            CookedFood?.SetEnable(false);
            OvercookedFood?.SetEnable(false);
        }

        public void ShowEmptyFood()
        {
            HideFood();

            if (EmptyFood != null)
                EmptyFood.SetActive(true);
        }

        public void ShowFoodByStatus(Food.FoodStatus status)
        {
            HideFood();

            switch (status)
            {
                case Food.FoodStatus.Raw:
                    {
                        RawFood?.SetEnable(true);
                        return;
                    }
                case Food.FoodStatus.Cooked:
                    {
                        CookedFood?.SetEnable(true);
                        return;
                    }
                case Food.FoodStatus.Overcooked:
                    {
                        OvercookedFood?.SetEnable(true);
                        return;
                    }
            }
        }
    }


    public string               foodName = string.Empty;
    public FoodVisualizerSet    visualSet = null;
    public PlaceForFood         foodPlace = null;

    private void Start()
    {
        visualSet?.HideFood();

        if (foodPlace)
            foodPlace.FoodPlaceUpdated += OnFoodPlaceUpdated;
    }

    private void OnDisable()
    {
        if (foodPlace)
            foodPlace.FoodPlaceUpdated -= OnFoodPlaceUpdated;
    }

    private void OnFoodPlaceUpdated()
    {
        if (foodPlace.IsFree)
            visualSet?.ShowEmptyFood();
        else
        {
            if (foodPlace.CurrentFood.FoodName == foodName)
                visualSet?.ShowFoodByStatus(foodPlace.CurrentFood.CurrentStatus);
            else
                visualSet?.HideFood();
        }
    }
}
