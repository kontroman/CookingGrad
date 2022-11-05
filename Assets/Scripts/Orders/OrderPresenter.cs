using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderPresenter : MonoBehaviour
{
	public OrderVisualizer Visualizer = null;

	OrderPlace _orderPlace = null;

	private void Start()
	{
		_orderPlace = GetComponent<OrderPlace>();
		_orderPlace.CurrentOrderUpdated += OnOrderUpdated;
	}

	private void OnDestroy()
	{
		if (_orderPlace)
		{
			_orderPlace.CurrentOrderUpdated -= OnOrderUpdated;
		}
	}

	private void OnOrderUpdated()
	{
		Visualizer.Init(_orderPlace.CurrentOrder);
	}
}
