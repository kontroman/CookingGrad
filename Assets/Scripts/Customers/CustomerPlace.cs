using Devotion.Scripts.Orders;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace Devotion.Scripts.Customers
{
	public class CustomerPlace : MonoBehaviour
	{
		public Customer CurrentCustomer { get; private set; } = null;

		public bool IsFree { get { return CurrentCustomer == null; } }

		public async void PlaceCustomer(Customer customer)
		{
			CurrentCustomer = customer;
			customer.transform.SetParent(transform);
			customer.AnimationController.DoMoveToPlace(this.transform);

			await Task.Delay(5000);

			customer.ActivateCustomer();
			//customer.transform.localPosition = Vector3.zero;
		}

		public void Free(Transform endpoint = null)
		{
			if (!CurrentCustomer)
				return;

			var customer = CurrentCustomer;
            CurrentCustomer.OrderPlace.SetActive(false);
            CurrentCustomer = null;

            customer.AnimationController.DoMoveToPlace(endpoint, () => 
			{
                Destroy(customer.gameObject);
            }, DG.Tweening.Ease.InQuad);

		}
	}
}