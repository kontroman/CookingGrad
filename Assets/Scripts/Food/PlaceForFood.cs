using System;
using UnityEngine;

public class PlaceForFood : MonoFoodPlace
{
    public event Action FoodPlaceUpdated;

    public bool Cook = false;
    public float CookTime = 0f; //Initizlize on start from DataScript
    public float OvercookTime = 0f;

    public Food CurrentFood { get; private set; } = null;

    public bool IsCooking { get; private set; } = false;

    public bool IsFree { get { return CurrentFood == null; } }

    private float _timer = 0f;

    public float TimerNormalized
    {
        get
        {
            if (IsFree || !Cook || !IsCooking)
            {
                return 0f;
            }
            if (CurrentFood.CurrentStatus == Food.FoodStatus.Raw)
            {
                return _timer / CookTime;
            }
            return _timer / OvercookTime;
        }
    }

    //Обработка таймера для готовки еды на устройстве
    private void Update()
    {
        if (IsFree || !Cook || !IsCooking)
            return;

        _timer += Time.deltaTime;
        switch (CurrentFood.CurrentStatus)
        {
            case Food.FoodStatus.Raw:
                {
                    if(_timer > CookTime)
                    {
                        CurrentFood.NextStep();
                        _timer = 0;
                        if(OvercookTime <= 0f)
                            IsCooking = false;
                        FoodPlaceUpdated?.Invoke();
                    }
                    break;
                }
            case Food.FoodStatus.Cooked:
                {
                    if (_timer > OvercookTime)
                    {
                        CurrentFood.NextStep();
                        _timer = 0f;
                        IsCooking = false;
                        FoodPlaceUpdated?.Invoke();
                    }
                    break;
                }
        }
    }

    //Освобождение места на устройстве
    public override void FreePlace()
    {
        CurrentFood = null;
        _timer = 0f;
        IsCooking = false;
        FoodPlaceUpdated?.Invoke();
    }

    //Добавить еду на устройство
    public override bool PlaceFood(Food food)
    {
        if (!IsFree)
            return false;

        CurrentFood = food;
        if (Cook && CurrentFood.CurrentStatus != (Food.FoodStatus.Overcooked))
            IsCooking = true;

        FoodPlaceUpdated?.Invoke();
        return true;
    }
}
