using UnityEngine;
using System.Collections;

public class SpawnOnDestroy : MonoBehaviour {

	public GameObject obj;
	public Transform objParent;

	void OnDestroy(){
		GameObject g = Instantiate<GameObject>(obj);
		if (objParent == null)
			objParent = transform.parent;
		g.transform.parent = objParent;
		g.transform.position = transform.position;
	}
}
