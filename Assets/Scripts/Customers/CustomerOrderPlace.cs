using UnityEngine;

public class CustomerOrderPlace : MonoBehaviour
{
    public Order CurrentOrder { get; private set; } = null;

    public bool IsActive { get { return CurrentOrder != null; } }

    public void Init(Order order)
    {
        CurrentOrder = order;
        gameObject.SetActive(true);
    }

    public void Done()
    {
        CurrentOrder = null;
        gameObject.SetActive(false);
    }

}
