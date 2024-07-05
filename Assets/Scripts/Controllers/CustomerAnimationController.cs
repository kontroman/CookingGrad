using UnityEngine;
using DG.Tweening;

namespace Devotion.Scripts.Controllers
{
    public class CustomerAnimationController : MonoBehaviour
    {
        public void DoMoveToPlace(Transform place, TweenCallback onComplete = null, Ease ease = Ease.Linear)
        {
            var tween = transform.DOMove(place.transform.position, 4f).SetEase(ease);

            if (onComplete != null)
            {
                tween.OnComplete(onComplete);
            }
        }
    }
}