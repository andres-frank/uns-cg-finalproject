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
	
	// Update is called once per frame
	void Update () {
		
		// if (Input.GetKeyDown(KeyCode.Alpha1)) {
		// 	ActiveModel = Model1;
		// 	Model1.GetComponent<DisassembleObject>().Enable();
		// 	// Model2.GetComponent<DisassembleObject>().Disable();
		// }
		// if (Input.GetKeyDown(KeyCode.Alpha2)) {
		// 	ActiveModel = Model2;
		// 	// Model2.GetComponent<DisassembleObject>().Enable();
		// 	// Model1.GetComponent<DisassembleObject>().Disable();
		// }
		
	}

	void LateUpdate() {
		transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * transitionSpeed);
	}

	public void setNewPos(Vector3 position){
		newPos = position;
	}
}
