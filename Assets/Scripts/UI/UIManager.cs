using System.Collections.Generic;
using UnityEngine;
using System;
public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public List<GameObject> Windows = new List<GameObject>();
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
            Destroy(gameObject);
       
        InitUI();
    }

    private void InitUI()
    {
        //to do
    }


    void Start()
    {
        foreach (var window in Windows)
        {
            var windowComponent = window.GetComponent<Window>();
            if (windowComponent is MainMenuWindow)
                windowComponent.Open();
            else
                windowComponent.Close();
        }
    }

    public T GetWindow<T>() where T : Window
    {
        foreach (var window in Windows)
        {
            var windowComponent = window.GetComponent<Window>();
            if (windowComponent is T)
                return (T)windowComponent;
        }
        return null;
    }
}