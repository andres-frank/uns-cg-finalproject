using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour {

 	[Header("Game Objects Linking")]
	public GameObject helpPanel;
	public GameObject infoPanel;

	[Space]

	[Header("Information Panel")]

	[Range(0f, 0.1f)]
	public float typingTextSpeed = 0.017f;

	[Range(0f, 0.2f)]
	public float typingNumberSpeed = 0.03f;

	private Animator helpPanelAnimator;
	private Animator infoPanelAnimator;

	private TextMeshProUGUI info_name;
	private TextMeshProUGUI info_posCoordX;
	private TextMeshProUGUI info_posCoordY;
	private TextMeshProUGUI info_posCoordZ;
	private TextMeshProUGUI info_rotCoordX;
	private TextMeshProUGUI info_rotCoordY;
	private TextMeshProUGUI info_rotCoordZ;

	void Start () {
	    // helpPanel = GameObject.Find("Canvas/HelpPanel");
	    // helpPanel.SetActive(false);
	    helpPanelAnimator = helpPanel.GetComponent<Animator>();
	    helpPanelAnimator.SetBool("isOpen", false);

	    // infoPanel = GameObject.Find("Canvas/MainInfoPanel");
	    // infoPanel.SetActive(false);
	    infoPanelAnimator = infoPanel.GetComponent<Animator>();
	    infoPanelAnimator.SetBool("isOpen", false);

	    info_name = GameObject.Find("Canvas/MainInfoPanel/NameTag").GetComponent<TextMeshProUGUI>();
	    info_posCoordX = GameObject.Find("Canvas/MainInfoPanel/PositionCoordX").GetComponent<TextMeshProUGUI>();
	    info_posCoordY = GameObject.Find("Canvas/MainInfoPanel/PositionCoordY").GetComponent<TextMeshProUGUI>();
	    info_posCoordZ = GameObject.Find("Canvas/MainInfoPanel/PositionCoordZ").GetComponent<TextMeshProUGUI>();
	    info_rotCoordX = GameObject.Find("Canvas/MainInfoPanel/RotationCoordX").GetComponent<TextMeshProUGUI>();
	    info_rotCoordY = GameObject.Find("Canvas/MainInfoPanel/RotationCoordY").GetComponent<TextMeshProUGUI>();
	    info_rotCoordZ = GameObject.Find("Canvas/MainInfoPanel/RotationCoordZ").GetComponent<TextMeshProUGUI>();
	}


	public void ToggleHelpPanel(){
		helpPanelAnimator.SetBool("isOpen", !helpPanelAnimator.GetBool("isOpen"));
		// helpPanel.SetActive(!helpPanel.activeSelf);
	}

	public void ToggleInfoPanel(){
		infoPanelAnimator.SetBool("isOpen", !infoPanelAnimator.GetBool("isOpen"));
		// infoPanel.SetActive(!infoPanel.activeSelf);
	}

	public void UpdateInfoPanel(Transform model){

		if (model == null) {
			infoPanelAnimator.SetBool("isOpen", false);

		} else {
			infoPanelAnimator.SetBool("isOpen", true);
			StopAllCoroutines(); // in case the user clicks a new object before the previous one finished writing

			StartCoroutine(TypeSentence(info_name, model.name));

			StartCoroutine(TypeNumber(info_posCoordX, model.position.x.ToString("#0.00")));
			StartCoroutine(TypeNumber(info_posCoordY, model.position.y.ToString("#0.00")));
			StartCoroutine(TypeNumber(info_posCoordZ, model.position.z.ToString("#0.00")));

			StartCoroutine(TypeNumber(info_rotCoordX, model.rotation.x.ToString("#0.00")));
			StartCoroutine(TypeNumber(info_rotCoordY, model.rotation.y.ToString("#0.00")));
			StartCoroutine(TypeNumber(info_rotCoordZ, model.rotation.z.ToString("#0.00")));
		}

	}

	// Animate the text by typing one letter at a time
	IEnumerator TypeSentence (TextMeshProUGUI textfield, string newtext) {
		textfield.text = "";

		foreach (char letter in newtext.ToCharArray()) {
			textfield.text += letter;
			yield return new WaitForSeconds(typingTextSpeed);
		}
	}

	// Animate the numbers by typing a few random ones before the real one
	IEnumerator TypeNumber (TextMeshProUGUI textfield, string newtext) {
		
		// TODO random start-end time and random character generation
		
		textfield.text = Random.Range(-100.0f, 100.0f).ToString("#0.00");
		yield return new WaitForSeconds(typingNumberSpeed + Random.Range(0.0f, 0.15f));
		textfield.text = Random.Range(-100.0f, 100.0f).ToString("#0.00");
		yield return new WaitForSeconds(typingNumberSpeed + Random.Range(0.0f, 0.15f));
		textfield.text = Random.Range(-100.0f, 100.0f).ToString("#0.00");
		yield return new WaitForSeconds(typingNumberSpeed + Random.Range(0.0f, 0.15f));

		textfield.text = newtext;
	}

}
