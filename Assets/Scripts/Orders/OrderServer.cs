using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderServer : MonoBehaviour
{
	OrderPlace _orderPlace;

	void Start()
	{
		_orderPlace = GetComponent<OrderPlace>();
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
