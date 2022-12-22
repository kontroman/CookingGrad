using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupFoodServer : MonoBehaviour
{
	public List<FoodServer> Servers = null;

	[UsedImplicitly]
	public void TryServe()
	{
		foreach (var server in Servers)
		{
			if (server.TryServeFood())
			{
				return;
			}
		}
	}
}
