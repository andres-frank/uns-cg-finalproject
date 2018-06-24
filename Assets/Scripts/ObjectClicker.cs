using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClicker : MonoBehaviour {

	private RaycastHit hit;
	private	Ray ray;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)){
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(ray, out hit, 100.0f)){
				if(hit.transform != null){
					
					print(hit.transform.gameObject.name);
					
				}
			}
		}	
	}

}
