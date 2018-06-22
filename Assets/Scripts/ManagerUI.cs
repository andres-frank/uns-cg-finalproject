using UnityEngine.UI;
using UnityEngine;

public class ManagerUI : MonoBehaviour {

	private GameObject[] helpMenuObjects;

	// Use this for initialization
	void Start () {
	    helpMenuObjects = GameObject.FindGameObjectsWithTag("HelpMenu");
		ToggleHelpMenu();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ToggleHelpMenu(){
		foreach (GameObject helpMenuObject in helpMenuObjects) {
		    helpMenuObject.SetActive(!helpMenuObject.activeSelf);
		}
	}

}
