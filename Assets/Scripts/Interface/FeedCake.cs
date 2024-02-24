using Devotion.Scripts.Controllers;
using UnityEngine;

namespace Devotion.Scripts.Interface
{
    public class FeedCake : MonoBehaviour
    {
        public void ActiveCake()
        {
            foreach (var customerPlace in CustomersController.Instance.CustomerPlaces)
            {
                if (customerPlace.CurrentCustomer != null)
                    customerPlace.CurrentCustomer.ResetTimer();
            }
        }
    }
}