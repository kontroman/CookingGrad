using UnityEngine;

public abstract class MonoFoodPlace : MonoBehaviour
{
	public abstract bool PlaceFood(Food food);
	public abstract void FreePlace();
}
