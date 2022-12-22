using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodServer : MonoBehaviour
{
	PlaceForFood _place = null;

	void Start()
	{
		_place = GetComponent<PlaceForFood>();
	}

	public bool TryServeFood()
	{
		if (_place.IsFree || (_place.CurrentFood.CurrentStatus != Food.FoodStatus.Cooked))
		{
			return false;
		}
		var order = OrdersController.Instance.FindOrder(new List<string>(1) { _place.CurrentFood.FoodName });
		if ((order == null) || !CustomersController.Instance.ServeOrder(order))
		{
			return false;
		}

		_place.FreePlace();
		return true;
	}
}
