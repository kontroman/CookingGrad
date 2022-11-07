using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderVisualizer : MonoBehaviour
{
    public List<FoodVisualizer> visual = new List<FoodVisualizer>();

    private void Start()
    {
        Clear();
    }

    private void Clear()
    {
        visual.ForEach(x => x.SetEnable(false));
    }

    public void Init(List<string> foods)
    {
        Clear();

        foreach(var v in visual)
        {
            if (foods.Contains(v.name))
                v.SetEnable(true);
        }
    }

}
