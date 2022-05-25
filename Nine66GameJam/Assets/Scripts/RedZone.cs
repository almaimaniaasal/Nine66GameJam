using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedZone : MonoBehaviour
{
	public GameObject losewindow;
	private void OnTriggerStay(Collider other)
	{
		ThrowCube cube = other.GetComponent<ThrowCube>();
		if(cube != null)
		{
			if (cube.GetComponent<Rigidbody>().velocity.magnitude < 0.1f)
			{
				Time.timeScale=0;
				losewindow.SetActive(true);
				Debug.Log("GameOver");
			}
		}
	}
}
