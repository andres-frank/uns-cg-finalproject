using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition : MonoBehaviour {

	[Range(1, 10)]
	public int transitionSpeed = 2;

	private Vector3 newPos;

	void Start () {
		newPos = transform.position;
	}
	
	void Update () {
		
	}

	void LateUpdate() {
		transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * transitionSpeed);
	}

	public void setNewPos(Vector3 position){
		newPos = position;
	}
}
