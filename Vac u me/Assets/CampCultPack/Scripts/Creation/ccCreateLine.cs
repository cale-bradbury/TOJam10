﻿using UnityEngine;
using System.Collections;

public class ccCreateLine : ccCreateGroup {

	private Vector3 _offset;
	public Vector3 offsetPerObject;

	override public Vector3 place(int i){
		return offsetPerObject*i;
	}

	protected void Start(){
		base.Start();
		_offset = offsetPerObject;
	}

	protected void Update(){
		base.Update();
		if(_offset!=offsetPerObject){
			_offset = offsetPerObject;
			refresh();
		}
	}
}
