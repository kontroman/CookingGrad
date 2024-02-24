using JetBrains.Annotations;
using System.Collections.Generic;
using UnityEngine;

namespace Devotion.Scripts.Food
{
	public class GroupFoodServer : MonoBehaviour
	{
		public List<FoodServer> Servers = null;

		[UsedImplicitly]
		public async void TryServe()
		{
			foreach (var server in Servers)
			{
				var result = await server.TryServeFood();

				if (result)
				{
					return;
				}
			}
		}
	}
}