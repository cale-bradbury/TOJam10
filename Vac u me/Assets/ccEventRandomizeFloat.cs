using UnityEngine;
using System.Collections;

public class ccEventRandomizeFloat : ccEventReflection {

	public float minValue = -1;
	public float maxValue = 1;

	protected override object GetValue (){
		return Random.Range (minValue, maxValue);
	}
}
