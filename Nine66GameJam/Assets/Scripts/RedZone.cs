using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedZone : MonoBehaviour
{
	private void OnTriggerStay(Collider other)
	{
		ThrowCube cube = other.GetComponent<ThrowCube>();
		if(cube != null)
		{
			if (cube.GetComponent<Rigidbody>().velocity.magnitude < 0.1f)
			{
				Debug.Log("GameOver");
			}
		}
	}
}
