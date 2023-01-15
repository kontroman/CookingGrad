using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerLoader : MonoBehaviour
{
    public GameObject UIManagerPrefab;
    void Awake()
    {
        if (UIManager.Instance == null)
            Instantiate(UIManagerPrefab);
    }
}
