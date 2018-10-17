using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFlowController : MonoBehaviour
{

	private PlayerController Player;
	
	private void Awake()
	{
		Player = FindObjectOfType<PlayerController>();
	}

	private void Update()
	{
		transform.position = Player.transform.position;
	}
}
