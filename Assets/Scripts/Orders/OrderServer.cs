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
	public void TryServeOrder()
	{
		var order = OrdersController.Instance.FindOrder(_orderPlace.CurrentOrder);
		if ((order == null) || !CustomersController.Instance.ServeOrder(order))
		{
			return;
		}

		_orderPlace.FreePlace();
	}
}
