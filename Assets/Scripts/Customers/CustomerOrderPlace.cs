using System.Collections;
using UnityEngine;
using DG.Tweening;
using System.Threading.Tasks;

public class CustomerOrderPlace : MonoBehaviour
{
    public Order CurrentOrder { get; private set; } = null;
    public GameObject DoneIcon;
    public bool IsActive { get { return CurrentOrder != null; } }

    private GameObject _dish;

    public void Init(Order order, GameObject dish)
    {
        CurrentOrder = order;
        gameObject.SetActive(true);
        _dish = dish;
    }

    public async Task Done()
    {
        CurrentOrder = null;

        if (_dish) _dish.SetActive(false);

        StartCoroutine(MarkAsDone());

        await Task.Delay(650);
    }

    IEnumerator MarkAsDone()
    {
        DoneIcon.SetActive(true);

        DoneIcon.transform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), 0.3f);

        yield return new WaitForSeconds(0.3f);

        DoneIcon.transform.DOScale(Vector3.one, 0.05f);

        yield return new WaitForSeconds(0.05f);

        DoneIcon.transform.DOScale(Vector3.zero, 0.3f);

        yield return new WaitForSeconds(0.3f);

        gameObject.SetActive(false);
    }
}
