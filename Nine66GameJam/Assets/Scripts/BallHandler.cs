using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallHandler : MonoBehaviour
{
	[SerializeField] private GameObject ballPrefab;
	[SerializeField] private GameObject HingeJoint;

	[SerializeField] private float ballDespawnTime;
	[SerializeField] private float releaseDelay;
	[SerializeField] private float respawnTime;
	[SerializeField] private float maxDragDistance;


	private Rigidbody2D theBall;
	private Rigidbody2D hingeJointRb;
	private SpringJoint2D ballSpringJoint;

	private bool isFingerDown = false;
	private bool disableTouchInput = false;

	private int ballCount = 0;

	private Camera mainCam;

	public int BallCount
	{
		get { return ballCount; }
	}

	// Start is called before the first frame update
	void Start()
	{
		mainCam = Camera.main;
		hingeJointRb = HingeJoint.GetComponent<Rigidbody2D>();
		ballSpawn();
	}

	// Update is called once per frame
	void Update()
	{
		//if (touchScreen.primaryTouch.press.isPressed == false)
		//	return;
		if (theBall == null)
			return;

		if (disableTouchInput)
			return;

		if (Input.touchCount == 0)
		{
			if (isFingerDown)
			{
				launch();
			}
			return;
		}

		pullBack();
	}

	private void ballSpawn()
	{
		GameObject ball = Instantiate(ballPrefab, HingeJoint.transform.position, Quaternion.identity);
		theBall = ball.GetComponent<Rigidbody2D>();
		ballSpringJoint = ball.GetComponent<SpringJoint2D>();
		ballSpringJoint.connectedBody = hingeJointRb;
		ballCount++;
	}

	private void pullBack()
	{
		isFingerDown = true;
		theBall.isKinematic = true;
		//theBall.bodyType = RigidbodyType2D.Dynamic;

		//Vector2 touchPosition = touchScreen.primaryTouch.position.ReadValue();
		Vector2 touchPosition = Input.GetTouch(0).position;
		Vector2 worldPosition = mainCam.ScreenToWorldPoint(touchPosition);

		if (Vector3.Distance(worldPosition, HingeJoint.transform.position) > maxDragDistance)
			theBall.position = hingeJointRb.position + (worldPosition - hingeJointRb.position).normalized * maxDragDistance;
		else
			theBall.position = worldPosition;
	}

	private void launch()
	{
		//theBall.bodyType = RigidbodyType2D.Kinematic;
		theBall.isKinematic = false;
		StartCoroutine(delayRelease());
		Destroy(theBall.gameObject, ballDespawnTime);
		StartCoroutine(respawnBall());
		//ballSpringJoint.enabled = false;
		isFingerDown = false;
	}

	private IEnumerator delayRelease()
	{
		disableTouchInput = true;
		yield return new WaitForSeconds(releaseDelay);
		ballSpringJoint.enabled = false;
		theBall = null;
		ballSpringJoint = null;
		disableTouchInput = false;
	}

	private IEnumerator respawnBall()
	{
		yield return new WaitForSeconds(respawnTime);
		if (ballCount < 3)
			ballSpawn();
		else
		{
			//Enemy.EnemiesAlive = 0;
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
			
	}
}
