using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CustomerAnimationController : MonoBehaviour
{
    public void DoMoveToPlace(Transform place)
    {
        transform.DOPath(new Vector3[] {transform.position, place.transform.position}, 5f, PathType.Linear);
    }
}
