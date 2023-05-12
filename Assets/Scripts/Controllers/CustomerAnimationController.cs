using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CustomerAnimationController : MonoBehaviour
{
    public void DoMoveToPlace(Transform place)
    {
        transform.DOLocalMove(Vector3.zero, 5f);
    }
}
