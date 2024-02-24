using UnityEngine;

namespace Devotion.Scripts.Food
{
	public abstract class MonoFoodPlace : MonoBehaviour
	{
		public abstract bool PlaceFood(Food food);
		public abstract void FreePlace();
	}
}