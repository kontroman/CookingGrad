using Devotion.Scripts.Game.Boosters;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class FoodServer : MonoBehaviour
{
	PlaceForFood _place = null;

	void Start()
	{
		_place = GetComponent<PlaceForFood>();
	}

	public async Task<bool> TryServeFood()
	{
		if (_place.IsFree || (_place.CurrentFood.CurrentStatus != Food.FoodStatus.Cooked))
		{
			return false;
		}
		var order = OrdersController.Instance.FindOrder(new List<string>(1) { _place.CurrentFood.FoodName });
		bool task = await CustomersController.Instance.ServeOrder(order);

		if ((order == null) || !task)
		{
			return false;
		}

		_place.FreePlace();
		return true;
	}
}
