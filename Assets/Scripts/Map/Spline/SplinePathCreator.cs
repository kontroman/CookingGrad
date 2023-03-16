using UnityEngine;

public class SplinePathCreator : MonoBehaviour
{
    [HideInInspector]
    public SplinePath splinePath;

    public void CreatePath()
    {
        splinePath = new SplinePath(transform.position);
    }
}
