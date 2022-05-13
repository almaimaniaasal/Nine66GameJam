using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowCube : MonoBehaviour
{
	private Vector2 startPos, endPos, direction;

	private float touchTimeStart, touchTimeFinish, timeInterval;

	private Rigidbody rb;

	[SerializeField] private float throwForceInXAndY;
	[SerializeField] private float throwForceInZ;

	[SerializeField] private GameObject spawnPoint;
	[SerializeField] private GameObject cubePrefab;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	private void Update()
	{
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
		{
			touchTimeStart = Time.time;
			startPos = Input.GetTouch(0).position;
		}

		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
		{
			cubeThrow();
		}
	}

	private void cubeThrow()
	{
		touchTimeFinish = Time.time;

		timeInterval = touchTimeFinish - touchTimeStart;

		endPos = Input.GetTouch(0).position;

		direction = startPos - endPos;

		rb.isKinematic = false;
		rb.AddForce(-direction.x * throwForceInXAndY, -direction.y * throwForceInXAndY, throwForceInZ / timeInterval);

		Invoke("cubeSpawn", 0.2f);
	}

	private void cubeSpawn()
	{
		GameObject newCube = Instantiate(cubePrefab, spawnPoint.transform.position, Quaternion.identity);

		Destroy(this, 0.5f);
	}
}
