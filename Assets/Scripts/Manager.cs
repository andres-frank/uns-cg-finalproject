using UnityEngine;

public class Manager : MonoBehaviour {

	public UIManager managerUI;
	public Transform[] Models;
	
	private Transform ActiveModel;
	private ObjectClicker objectClicker;
	private GlowObject glowObject;

	void Start () {
		objectClicker = FindObjectOfType<ObjectClicker>();
		glowObject = FindObjectOfType<GlowObject>();

		ActiveModel = Models[0];
		ActiveModel.GetComponent<DisassembleObject>().Enable();
	}
	

	void Update () {

		if (Input.GetMouseButtonDown(0)) {
			Transform objectClicked = objectClicker.ObtainObjectClicked(Input.mousePosition);
			managerUI.UpdateInfoPanel(objectClicked);
			glowObject.StartGlowing(objectClicked);
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

		// The Hercules Model has its origin broken, and we couldn't fix it in Blender... so this is a hardcoded hack just so it looks good. 
		if (ActiveModel == Models[3]) FindObjectOfType<Transition>().setNewPos(new Vector3(-8, -13, 6)); 
		else FindObjectOfType<Transition>().setNewPos(ActiveModel.position);
	}
}
