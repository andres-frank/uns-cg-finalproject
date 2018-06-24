using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour {

	private GameObject helpPanel;
	private GameObject infoPanel;

	void Start () {
	    helpPanel = GameObject.Find("Canvas/HelpPanel");
	    helpPanel.SetActive(false);

	    infoPanel = GameObject.Find("Canvas/MainInfoPanel");
	    infoPanel.SetActive(false);
	}

	public void ToggleHelpPanel(){
		helpPanel.SetActive(!helpPanel.activeSelf);
	}

	public void ToggleInfoPanel(){
		infoPanel.SetActive(!infoPanel.activeSelf);
	}

	public void UpdateInfoPanel(Transform model){

		if (model == null) {
			infoPanel.SetActive(false);

		} else {
			infoPanel.SetActive(true);

			TextMeshProUGUI name = GameObject.Find("Canvas/MainInfoPanel/NameTag").GetComponent<TextMeshProUGUI>();
			name.text = model.name;

			TextMeshProUGUI posCoordX = GameObject.Find("Canvas/MainInfoPanel/PositionCoordX").GetComponent<TextMeshProUGUI>();
			posCoordX.text = model.position.x.ToString("#0.00");
			TextMeshProUGUI posCoordY = GameObject.Find("Canvas/MainInfoPanel/PositionCoordY").GetComponent<TextMeshProUGUI>();
			posCoordY.text = model.position.y.ToString("#0.00");
			TextMeshProUGUI posCoordZ = GameObject.Find("Canvas/MainInfoPanel/PositionCoordZ").GetComponent<TextMeshProUGUI>();
			posCoordZ.text = model.position.z.ToString("#0.00");

			TextMeshProUGUI rotCoordX = GameObject.Find("Canvas/MainInfoPanel/RotationCoordX").GetComponent<TextMeshProUGUI>();
			rotCoordX.text = model.rotation.x.ToString("#0.00");
			TextMeshProUGUI rotCoordY = GameObject.Find("Canvas/MainInfoPanel/RotationCoordY").GetComponent<TextMeshProUGUI>();
			rotCoordY.text = model.rotation.y.ToString("#0.00");
			TextMeshProUGUI rotCoordZ = GameObject.Find("Canvas/MainInfoPanel/RotationCoordZ").GetComponent<TextMeshProUGUI>();
			rotCoordZ.text = model.rotation.z.ToString("#0.00");
		}

	}

}
