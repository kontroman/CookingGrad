using UnityEngine;
using DG.Tweening;

namespace Devotion.Scripts.Controllers
{
    public class CustomerAnimationController : MonoBehaviour
    {
        public void DoMoveToPlace(Transform place)
        {
            transform.DOPath(new Vector3[] { transform.position, place.transform.position }, 5f, PathType.Linear);
        }
    }
}