using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CustomersController : MonoBehaviour
{
    public static CustomersController Instance { get; private set; }

    public int CustomersTargetNumber = 15;
    public float CustomerWaitTime = 25f;
    public float CustomerSpawnTime = 3f;
    public List<CustomerPlace> CustomerPlaces = null;

    public int TotalCustomersGenerated { get; private set; } = 0;
    public event Action TotalCustomersGeneratedChanged;
    const string CUSTOMER_PREFABS_PATH = "Prefabs/Customer";

    public float _timer = 0f;
    Stack<List<Order>> _orderSets;

    bool HasFreePlaces { get { return CustomerPlaces.Any(x => x.IsFree); } }

    public bool IsComplete { get { return TotalCustomersGenerated >= CustomersTargetNumber && CustomerPlaces.All(x => x.IsFree); } }

    private void Awake()
    {
        if (Instance != null) return;
        else Instance = this;

        Init();
    }

    private void Update()
    {
        if (!HasFreePlaces)
            return;

        _timer += Time.deltaTime;

        if ((TotalCustomersGenerated >= CustomersTargetNumber) || (!(_timer > CustomerSpawnTime)))
            return;

        SpawnCustomer();
        _timer = 0f;
    }

    public void Init()
    {
        var totalOrders = 0;
        _orderSets = new Stack<List<Order>>();
        for (var i = 0; i < CustomersTargetNumber; i++)
        {
            var orders = new List<Order>();
            var ordersNum = UnityEngine.Random.Range(1, 4);
            for (var j = 0; j < ordersNum; j++)
            {
                orders.Add(GenerateRandomOrder());
            }
            _orderSets.Push(orders);
            totalOrders += ordersNum;
        }
        CustomerPlaces.ForEach(x => x.Free());
        _timer = 0f;

        TotalCustomersGenerated = 0;
        TotalCustomersGeneratedChanged?.Invoke();

        //GameplayController.Instance.OrdersTarget = totalOrders - 2;
        //GameplayController.Instance.StartGame();
    }

    private Order GenerateRandomOrder()
    {
        var oc = OrdersController.Instance;
        return oc.Orders[UnityEngine.Random.Range(0, oc.Orders.Count)];
    }
    void SpawnCustomer()
    {
        var freePlaces = CustomerPlaces.FindAll(x => x.IsFree);
        if (freePlaces.Count <= 0)
        {
            return;
        }

        var place = freePlaces[UnityEngine.Random.Range(0, freePlaces.Count)];
        place.PlaceCustomer(GenerateCustomer());
        TotalCustomersGenerated++;
        TotalCustomersGeneratedChanged?.Invoke();
    }

    private Customer GenerateCustomer()
    {
        var customerGo = Instantiate(Resources.Load<GameObject>(CUSTOMER_PREFABS_PATH));
        var customer = customerGo.GetComponent<Customer>();

        var orders = _orderSets.Pop();
        customer.Init(orders);

        return customer;
    }



    public void FreeCustomer(Customer customer)
    {
        var place = CustomerPlaces.Find(x => x.CurrentCustomer == customer);
        if (place == null)
        {
            return;
        }
        place.Free();

        //GameplayController.Instance.CheckGameFinish();
    }

    private List<Customer> FindAndSortOredersByTime()
    {
        List<Customer> activeCustomersOrders = FindObjectsOfType<Customer>().ToList();
        activeCustomersOrders.Sort((w1, w2) => w1.WaitTime.CompareTo(w2.WaitTime));

        return activeCustomersOrders;
    }

    public bool ServeOrder(Order order)
    {
        foreach (Customer _customer in FindAndSortOredersByTime())
        {
            if (_customer.TryServeOrder(order))
            {
                if (_customer.IsComplete) FreeCustomer(_customer);
                return true;
            }
        }
        return false;
    }

}
