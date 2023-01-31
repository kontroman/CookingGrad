using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerPlace : MonoBehaviour
{
	public Customer CurrentCustomer { get; private set; } = null;

	public bool IsFree { get { return CurrentCustomer == null; } }

	public void PlaceCustomer(Customer customer)
	{
		CurrentCustomer = customer;
		customer.transform.SetParent(transform);
		customer.transform.localPosition = Vector3.zero;
	}

	public void Free()
	{
		if (!CurrentCustomer)
		{
			return;
		}
		var customer = CurrentCustomer;
		CurrentCustomer = null;
		Destroy(customer.gameObject);
	}
}
