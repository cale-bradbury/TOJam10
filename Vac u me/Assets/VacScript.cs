using UnityEngine;
using System.Collections;

public class VacScript : MonoBehaviour {

	public string suckInput;
	public string blowInput;
	public string horiAxis;
	public string vertAxis;

	public float suctionPower = 1;

	public float moveDistancePerSecond = 10;
	public float positionLerp = .1f;
	Vector3 targetPosition;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		MoveVac ();
		Suck ();
	}

	void MoveVac(){
			
		targetPosition.x += Input.GetAxis (horiAxis) * moveDistancePerSecond * Time.deltaTime;
		targetPosition.z += Input.GetAxis (vertAxis) * moveDistancePerSecond * Time.deltaTime;
		transform.position = Vector3.Lerp (transform.position, targetPosition, positionLerp);
	}

	void Suck(){
		float dir = 0;
		if (Input.GetButton (suckInput))
			dir += 1;
		if (Input.GetButton (blowInput))
			dir -= 1;
		foreach (ObjectScript o in ObjectScript.all) {
			float d = Vector3.Distance(transform.position,o.transform.position);
			d = Mathf.Max(suctionPower-d,0)*dir;
			o.body.AddForce((transform.position-o.transform.position)*d);
		}
	}
}
