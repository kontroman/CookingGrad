using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
