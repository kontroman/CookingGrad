using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public sealed class FoodTransfer : MonoBehaviour, IPointerClickHandler
{
    public bool transferOnlyCookedFood = true;

    public List<MonoFoodPlace> places = new List<MonoFoodPlace>();

    PlaceForFood _place = null;

    private float _lastClickTime;
    private float _clickInterval = 0.5f;

    private void Start()
    {
        _place = GetComponent<PlaceForFood>();
    }

    public void TransferFood()
    {
        var food = _place.CurrentFood;

        if (food == null) return;

        if (transferOnlyCookedFood && (food.CurrentStatus == Food.FoodStatus.Cooked))
        {
            _place.PlaceFood(food);

            foreach (var place in places)
            {
                if (!place.PlaceFood(food))
                    continue;

                _place.FreePlace();
                return;
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if ((_lastClickTime + _clickInterval) > Time.time)
        {
            if (_place.CurrentFood.CurrentStatus == Food.FoodStatus.Overcooked)
            {
                GameIniter.Instance.InvokeAction(true);
                _place.FreePlace();
            }
        }

        _lastClickTime = Time.time;
    }
}
