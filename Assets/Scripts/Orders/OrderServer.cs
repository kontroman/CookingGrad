using Devotion.Scripts.Game.Boosters;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class OrderServer : MonoBehaviour
{
	OrderPlace _orderPlace;

	void Start()
	{
		_orderPlace = GetComponent<OrderPlace>();

		if (BoostersManager.Instance.GetBooster(Booster.BoosterType.AutoServer))
			_orderPlace.CurrentOrderUpdated += TryServeOrder;
    }

	[UsedImplicitly]
	public async void TryServeOrder()
	{
		var order = OrdersController.Instance.FindOrder(_orderPlace.CurrentOrder);

		bool task = await CustomersController.Instance.ServeOrder(order);

		if ((order == null) || !task)
		{
			return;
		}

		_orderPlace.FreePlace();
	}
}
