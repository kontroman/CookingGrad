using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

public sealed class OrderPlace : MonoFoodPlace
{
    public List<PlaceForFood> Places = new List<PlaceForFood>();

    public List<string> CurrentOrder = new List<string>();

    public event Action CurrentOrderUpdated;

    List<Order> AvailableOrders = new List<Order>();

    private void Start()
    {
        AvailableOrders.AddRange(OrdersController.Instance.Orders);
    }

    private bool CanAddFood(Food food)
    {
        if (CurrentOrder.Contains(food.FoodName))
        {
            Debug.Log("Current food already contains here");
            return false;
        }

        foreach(var order in AvailableOrders)
        {
            foreach(var orderFood in order.Foods.Where(x => x.Name == food.FoodName))
            {
                if (string.IsNullOrEmpty(orderFood.Dopings) || CurrentOrder.Contains(orderFood.Dopings))
                    return true;
            }
        }

        return false;
    }

    void UpdatePossibleOrders()
    {
        var ordersToRemove = new List<Order>();
        foreach (var order in AvailableOrders)
        {
            if (order.Foods.Where(x => x.Name == CurrentOrder[CurrentOrder.Count - 1]).Count() == 0)
            {
                ordersToRemove.Add(order);
            }
        }
        AvailableOrders.RemoveAll(x => ordersToRemove.Contains(x));
    }

    public override bool PlaceFood(Food food)
    {
        if (!CanAddFood(food))
        {
            Debug.Log("CantPlaceFood");
            return false;
        }

        foreach (var place in Places)
        {
            if (!place.PlaceFood(food))
            {
                continue;
            }

            CurrentOrder.Add(food.FoodName);
            UpdatePossibleOrders();
            CurrentOrderUpdated?.Invoke();
            return true;
        }
        return false;
    }
    public override void FreePlace()
    {
        AvailableOrders.Clear();
        AvailableOrders.AddRange(OrdersController.Instance.Orders);

        CurrentOrder.Clear();

        foreach (var place in Places)
        {
            place.FreePlace();
        }

        CurrentOrderUpdated?.Invoke();
    }
}
