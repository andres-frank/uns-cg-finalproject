using UnityEngine;

public class Manager : MonoBehaviour {

	public Transform[] Models;
	
	private Transform ActiveModel;
	private Transform NewActiveModel;

	// Use this for initialization
	void Start () {
		ActiveModel = Models[0];
		ActiveModel.GetComponent<DisassembleObject>().Enable();

	}
	
	// Update is called once per frame
	void Update () {
		
		if(Input.GetKeyDown(KeyCode.P)){
			ActiveModel.GetComponent<DisassembleObject>().togglePause();
		}

		if(Input.GetKeyDown(KeyCode.Space)){ 
			ActiveModel.GetComponent<DisassembleObject>().toggleArmar();
		}

		if (Input.GetKeyDown(KeyCode.Alpha1)) {
			NewActiveModel = Models[0];
			setActive();
		}

		if (Input.GetKeyDown(KeyCode.Alpha2)) {
			NewActiveModel = Models[1];
			setActive();
		}

		if (Input.GetKeyDown(KeyCode.Alpha3)) {
			NewActiveModel = Models[2];
			setActive();
		}

		if (Input.GetKeyDown(KeyCode.Alpha4)) {
			NewActiveModel = Models[3];
			setActive();
		}

	}

	private void setActive(){
		
		ActiveModel.GetComponent<DisassembleObject>().Disable();
		ActiveModel = NewActiveModel;
		ActiveModel.GetComponent<DisassembleObject>().Enable();		

		FindObjectOfType<Transition>().setNewPos(ActiveModel.position);
	}
}
