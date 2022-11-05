using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

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
            CurrentSet = Place.CurrentFood.CurrentStatus == Food.FoodStatus.Raw ? Raw : Cooked;
        }
        else
        {
            //Нужна анимация пропажи таймера

            gameObject.transform.localScale = Vector3.zero;
            gameObject.SetActive(false);
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

}
