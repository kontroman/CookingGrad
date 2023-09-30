using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class Customer : MonoBehaviour
{
    public Image CurrentSprite = null;
    public List<Sprite> AvailableSprites = null;
    public Image TimerBar = null;
    public List<CustomerOrderPlace> OrderPlaces = null;
    public CustomerAnimationController AnimationController = null;
    public GameObject OrderPlace = null;

    const string OrdersPrefabsPath = "Prefabs/Orders/{0}";

    List<Order> _orders = null;
    float _timer = 0f;
    bool _isActive = false;

    public float WaitTime { get { return CustomersController.Instance.CustomerWaitTime - _timer; } }
    public bool IsComplete { get { return _orders.Count == 0; } }

    void Update()
    {
        if (!_isActive)
        {
            return;
        }
        _timer += Time.deltaTime;
        TimerBar.fillAmount = WaitTime / CustomersController.Instance.CustomerWaitTime;

        if (WaitTime <= 0f)
        {
            CustomersController.Instance.FreeCustomer(this);
        }
    }

    [ContextMenu("Set random sprite")]
    void SetRandomSprite()
    {
        CurrentSprite.sprite = AvailableSprites[Random.Range(0, AvailableSprites.Count)];
        CurrentSprite.SetNativeSize();
    }

    public void Init(List<Order> orders, Transform spawnPosition)
    {
        _orders = orders;

        transform.position = spawnPosition.position;

        if(_orders.Count > OrderPlaces.Count)
        {
            Debug.LogError("Too many orders for one customer");
            return;
        }

        //OrderPlaces.ForEach(x => x.Done());

        var i = 0;
        for(; i < _orders.Count; i++)
        {
            var order = _orders[i];
            var place = OrderPlaces[i];
            var dish = Instantiate(Resources.Load<GameObject>(string.Format(OrdersPrefabsPath, order.name)), place.transform, false);
            place.Init(order, dish);
        }

        SetRandomSprite();
    }

    public void ActivateCustomer()
    {
        OrderPlace.SetActive(true);

        _isActive = true;
        _timer = 0;
    }

    public async Task<bool> TryServeOrderAsync(Order order)
    {
        var place = OrderPlaces.Find(x => x.CurrentOrder == order);

        if (!place)
            return false;
        
        _orders.Remove(order);

        await place.Done();

        _timer = Mathf.Max(0f, _timer - 6f);
        return true;
    }

    public void ResetTimer()
    {
        _timer = 0;
    }
}   
