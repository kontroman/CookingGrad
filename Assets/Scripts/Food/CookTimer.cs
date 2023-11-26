using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Devotion.Scripts.Game.Boosters;

public sealed class CookTimer : MonoBehaviour
{
    [Serializable]
    public class TimerSpriteSet
    {
        public Sprite Background = null;
        public Sprite Foreground = null;
    }
    
    public PlaceForFood Place = null;

    public Image Background = null;
    public Image Foreground = null;

    public TimerSpriteSet Raw = null;
    public TimerSpriteSet Cooked = null;

    private bool _noOvercook;
    private bool _isCooking;

    TimerSpriteSet CurrentSet
    {
        set
        {
            if (value == null) return;

            if (Background)
            {
                Background.sprite = value.Background;
                //Background.SetNativeSize();
            }
            if (Foreground)
            {
                Foreground.sprite = value.Foreground;
                //Foreground.SetNativeSize();
            }
        }
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private void Awake()
    {
        if (Place)
            Place.FoodPlaceUpdated += OnFoodPlaceUpdated;
    }

    private void OnDestroy()
    {
        if (Place)
            Place.FoodPlaceUpdated -= OnFoodPlaceUpdated;
    }

    private void Start()
    {
        OnFoodPlaceUpdated();

        if (BoostersManager.Instance.GetBooster(Booster.BoosterType.NoOvercooked))
            _noOvercook = true;

        gameObject.transform.localScale = Vector3.zero;
        gameObject.SetActive(false);
    }

    void Update()
    {
        if (Place == null)
            return;

        if (Place.IsCooking)
            Foreground.fillAmount = Place.TimerNormalized;
    }

    private void OnFoodPlaceUpdated()
    {
        if (Place.IsCooking)
        {
            gameObject.SetActive(true);
            _isCooking = true;

            if (Place.CurrentFood.CurrentStatus == Food.FoodStatus.Cooked && _noOvercook)
            {
                StartCoroutine(HideTimer());
                return;
            }

            CurrentSet = Place.CurrentFood.CurrentStatus == Food.FoodStatus.Raw ? Raw : Cooked;
        }
        else
        {
            if(gameObject.activeSelf)
                StartCoroutine(HideTimer());
        }
    }

    private void OnEnable()
    {
        StartCoroutine(TimerAppearence());
    }

    private IEnumerator TimerAppearence()
    {
        while(transform.localScale.x < 1.1f)
        {
            transform.localScale = new Vector3(transform.localScale.x + 0.05f, transform.localScale.y + 0.05f, 1);
            yield return new WaitForSeconds(0.01f);
        }

        while (transform.localScale.x > 1f)
        {
            transform.localScale = new Vector3(transform.localScale.x - 0.05f, transform.localScale.y - 0.05f, 1);
            yield return new WaitForSeconds(0.01f);
        }
    }

    private IEnumerator HideTimer()
    {
        if (!_isCooking) yield break;
        _isCooking = false;

        while (transform.localScale.x < 1.1f)
        {
            transform.localScale = new Vector3(transform.localScale.x + 0.05f, transform.localScale.y + 0.05f, 1);
            yield return new WaitForSeconds(0.01f);
        }

        while (transform.localScale.x > 0f)
        {
            transform.localScale = new Vector3(transform.localScale.x - 0.05f, transform.localScale.y - 0.05f, 1);
            yield return new WaitForSeconds(0.01f);
        }

        gameObject.transform.localScale = Vector3.zero;
        gameObject.SetActive(false);
    }

}
