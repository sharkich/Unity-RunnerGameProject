using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class RoadSegments : MonoBehaviour
{

	private GameObject _player;
	
	private void Awake()
	{
		_player = FindObjectOfType<PlayerController>().gameObject;
	}

	private void Update()
	{
		if (transform.position.z < _player.transform.position.z - 10)
		{
			transform.Translate(Vector3.forward * 100);
		}
	}
}
