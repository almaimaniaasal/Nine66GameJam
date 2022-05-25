using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollideMechanic : MonoBehaviour
{
	public AudioSource AudioSource;
	public AudioClip Clip;
	public SoundManager soundManager;

	ThrowCube cube;

	[SerializeField] GameObject cubePrefab;

	private void Awake()
	{
		cube = GetComponent<ThrowCube>();
	}

	private void OnCollisionEnter(Collision collision)
	{
		ThrowCube otherCube;


		//if (collision.gameObject.tag == "Cube")
		//{
		otherCube = collision.gameObject.GetComponent<ThrowCube>();

		if (otherCube == null)
			return;
		// check if contacted with other cube
		if (otherCube != null && cube.cubeID > otherCube.cubeID)
		{
			Debug.Log("Collided");
			// check if both cubes have same number
			if (cube.getNumText().text == otherCube.getNumText().text)
			{
				Vector3 contactPoint = collision.contacts[0].point;
				

				// check if cubes number less than max number in CubeSpawner:
				if (int.Parse(otherCube.getNumText().text) < 4096)
				{
					// spawn a new cube as a result
					GameObject newCube = Instantiate(cubePrefab, transform.position, Quaternion.identity);
					newCube.GetComponent<ThrowCube>().enabled = false;
					int newNum = int.Parse(otherCube.getNumText().text) * 2;
					TMP_Text newNumText = newCube.GetComponentInChildren(typeof(TMP_Text)) as TMP_Text;
					newNumText.text = newNum.ToString();

					//push the new cube up and forward:
					float pushForce = 0.5f;
					newCube.GetComponent<Rigidbody>().AddForce(new Vector3(0, .3f, .5f) * pushForce);

					// add some torque:
					float randomValue = Random.Range(-10f, 10f);
					Vector3 randomDirection = Vector3.one * randomValue;
					newCube.GetComponent<Rigidbody>().AddTorque(randomDirection);
					
				}

				// the explosion should affect surrounded cubes too:
				Collider[] surroundedCubes = Physics.OverlapSphere(contactPoint, 2f);
				float explosionForce = 150f;
				float explosionRadius = 0.5f;

				foreach (Collider coll in surroundedCubes)
				{
					if (coll.attachedRigidbody != null)
						coll.attachedRigidbody.AddExplosionForce(explosionForce, contactPoint, explosionRadius);
				}
				

				//FX.Instance.PlayCubeExplosionFX(contactPoint, cube.CubeColor);
				//soundManager.playDifferentSounds1(AudioSource,Clip);

				// Destroy the two cubes:
				
				Destroy(cube.gameObject);
				Destroy(otherCube.gameObject);
			}
		}
		//}
	}
}
