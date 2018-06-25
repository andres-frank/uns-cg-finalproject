using UnityEngine;

public class Manager : MonoBehaviour {

	public UIManager managerUI;
	public Transform[] Models;
	
	private Transform ActiveModel;
	private ObjectClicker objectClicker;

	void Start () {
		objectClicker = FindObjectOfType<ObjectClicker>();

		ActiveModel = Models[0];
		ActiveModel.GetComponent<DisassembleObject>().Enable();
	}
	

	void Update () {

		if (Input.GetMouseButtonDown(0)) {
			Transform objectClicked = objectClicker.ObtainObjectClicked(Input.mousePosition);
			managerUI.UpdateInfoPanel(objectClicked);
		}
		
		if (Input.GetKeyDown(KeyCode.P)) {
			ActiveModel.GetComponent<DisassembleObject>().togglePause();
		}

		if (Input.GetKeyDown(KeyCode.R)) {
			FindObjectOfType<CameraOrbit>().toggleAutoRotation();
		}

		if (Input.GetKeyDown(KeyCode.H)) {
			managerUI.ToggleHelpPanel();
		}

		if (Input.GetKeyDown(KeyCode.Space)) { 
			ActiveModel.GetComponent<DisassembleObject>().toggleArmar();
		}

		if (Input.GetKeyDown(KeyCode.Alpha1)) {
			this.setActive(Models[0]);
		}

		if (Input.GetKeyDown(KeyCode.Alpha2)) {
			this.setActive(Models[1]);
		}

		if (Input.GetKeyDown(KeyCode.Alpha3)) {
			this.setActive(Models[2]);
		}

		if (Input.GetKeyDown(KeyCode.Alpha4)) {
			this.setActive(Models[3]);
		}

	}


	private void setActive(Transform NewActiveModel){

		ActiveModel.GetComponent<DisassembleObject>().Disable();

		ActiveModel = NewActiveModel;
		ActiveModel.GetComponent<DisassembleObject>().Enable();		

		FindObjectOfType<Transition>().setNewPos(ActiveModel.position);
	}
}
