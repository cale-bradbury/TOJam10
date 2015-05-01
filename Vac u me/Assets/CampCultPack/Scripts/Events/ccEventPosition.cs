using UnityEngine;
using System.Collections;

public class ccEventPosition : ccEventBase {

	public Vector3[] position;

	protected override void OnEvent (){
		transform.localPosition = position [Mathf.FloorToInt (Random.value * position.Length)];
	}
}
