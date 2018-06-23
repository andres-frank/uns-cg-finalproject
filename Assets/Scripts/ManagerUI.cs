using UnityEngine.UI;
using UnityEngine;

public class ManagerUI : MonoBehaviour {

	private GameObject helpMenuPanel;

	void Start () {
	    helpMenuPanel = GameObject.Find("HelpPanel");
		ToggleHelpMenu();
	}

	public void ToggleHelpMenu(){
		helpMenuPanel.SetActive(!helpMenuPanel.activeSelf);
	}

}
