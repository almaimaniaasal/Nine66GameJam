using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ThrowCube : MonoBehaviour
{
	public AudioSource AudioSource;
	public AudioClip Clip;
	public SoundManager soundManager;
	private Vector2 startPos, endPos, direction;

	private float touchTimeStart, touchTimeFinish, timeInterval;

	private Rigidbody rb;
	private Collider coll;
	private Renderer cubeRenderer;

	[SerializeField] private float throwForceInXAndY;
	[SerializeField] private float throwForceInZ;

	[SerializeField] private GameObject cubePrefab;
	[SerializeField] private GameObject respawanPoint;


	int[] nums = { 2, 4};
	static int staticID = 0;

	public int cubeID;

	bool isBasicCube = true;
	
	public TMP_Text getNumText()
	{
		return GetComponentInChildren(typeof(TMP_Text)) as TMP_Text;
	}

	private void Awake()
	{
		//cubeSpawn();
		cubeID = staticID++;
		
	}

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
		coll = GetComponent<Collider>();
		cubeRenderer = GetComponent<Renderer>();
		coll.enabled = false;
	}

	private void Update()
	{
		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
		{
			Debug.Log("Screen is touched");
			touchTimeStart = Time.time;
			startPos = Input.GetTouch(0).position;
		}

		if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended && isBasicCube)
		{

				cubeThrow();
			isBasicCube = false;
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
		soundManager.playDifferentSounds(AudioSource,Clip);


		Invoke("enableCollider", 0.1f);
		Invoke("cubeSpawn", 0.05f);
	}

	private void cubeSpawn()
	{
		GameObject newCube = Instantiate(cubePrefab, respawanPoint.transform.position, Quaternion.identity);
		TMP_Text numsTexts = newCube.GetComponentInChildren(typeof(TMP_Text)) as TMP_Text;
		int randNum = Random.Range(0, nums.Length);
		numsTexts.text = nums[randNum].ToString();
		//Debug.Log(numsTexts.text);
		

		isBasicCube = true;

		this.enabled = false;
		//Destroy(this);
		
		//mainCube = CubeSpawner.Instance.SpawnRandom();
		//mainCube.IsMainCube = true;
	}
	public void enableCollider(){
		coll.enabled = true;
	}
}
