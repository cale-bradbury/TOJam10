using UnityEngine;
using System.Collections;

public class ccCreateRing : ccCreateGroup {

	public enum Direction{
		XY,
		XZ,
		YZ
	}

	public Direction direction;
	private Direction _direction;

	public float radius;
	private float _radius;

	public float phase;
	private float _phase;

	public override Vector3 place (int i){
		float a = (float)i/count*Mathf.PI*2+phase;
		if(direction==Direction.XY)
			return new Vector3(Mathf.Cos(a)*radius,Mathf.Sin(a)*radius,0);
		else if(direction==Direction.XZ)
			return new Vector3(Mathf.Cos(a)*radius,0,Mathf.Sin(a)*radius);
		return new Vector3(0,Mathf.Cos(a)*radius,Mathf.Sin(a)*radius);
	}

	// Use this for initialization
	void Start () {
		base.Start();
		_radius = radius;
		_phase = phase;
		_direction = direction;
	}
	
	// Update is called once per frame
	void Update () {
		base.Update();
		if(_radius!=radius){
			_radius = radius;
			refresh();
		}
		if(_phase!=phase){
			_phase = phase;
			refresh();
		}
		if(_direction!=direction){
			_direction = direction;
			refresh();
		}
	}
}
