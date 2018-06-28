using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingLight : MonoBehaviour {

	[Range(0, 3)]
	public float blinkFrequency = 1.7f;
	
	public GameObject shareTimingWith;

	private Light blinklight;

	void Start () {
		blinklight = GetComponent<Light>();

		if (shareTimingWith == null) {return;}

		StartCoroutine(Blinking());
	}

	IEnumerator Blinking() {

		// wait a random amount at first to de-sync between the other planes
		yield return new WaitForSeconds(Random.Range(0.0f, 3.5f));

		while (true) {
			blinklight.enabled = !blinklight.enabled;
			shareTimingWith.GetComponent<BlinkingLight>().ToggleLight();
			yield return new WaitForSeconds(blinkFrequency);
		}
	}	

	void ToggleLight() {
		blinklight.enabled = !blinklight.enabled;
	}

}
