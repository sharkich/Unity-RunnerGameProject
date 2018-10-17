using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvController : MonoBehaviour
{

	[SerializeField]
	private GameObject _roadSegment;

	private void Awake()
	{
		for (var i = 0; i < 20; i++)
		{
			var go = Instantiate(_roadSegment);
			go.transform.position = new Vector3(0, 0, -10 + i * 5);
		}
	}
}
