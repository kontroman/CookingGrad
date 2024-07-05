using Devotion.Scripts.Controllers;
using Devotion.Scripts.Customers;
using UnityEngine;

namespace Devotion.Scripts.Interface
{
    public class FeedCake : MonoBehaviour
    {
        public void ActiveCake()
        {
            float minWaitTime = float.MaxValue;
            Customer customerWithMinWaitTime = null;

            foreach (var customerPlace in CustomersController.Instance.CustomerPlaces)
            {
                if (customerPlace.CurrentCustomer != null)
                {
                    float waitTime = customerPlace.CurrentCustomer.WaitTime;
                    if (waitTime < minWaitTime)
                    {
                        minWaitTime = waitTime;
                        customerWithMinWaitTime = customerPlace.CurrentCustomer;
                    }
                }
            }

            if (customerWithMinWaitTime != null)
            {
                customerWithMinWaitTime.ResetTimer();
            }
        }
    }
}