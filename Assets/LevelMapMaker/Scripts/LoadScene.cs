using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Mkey
{
	public class LoadScene : MonoBehaviour
	{
		public void Load(int number)
        {
            if (SceneLoader.Instance) SceneLoader.Instance.LoadScene(number);
        }
	}
}
