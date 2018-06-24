using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingLight : MonoBehaviour {

	[Range(0, 3)]
	public float blinkFrequency = 1.7f;
	
	private Light blinklight;

	void Start () {
		blinklight = GetComponent<Light>();
		StartCoroutine(Blinking());
	}

	IEnumerator Blinking() {

		// TODO random start time

		while (true) {
			yield return new WaitForSeconds(blinkFrequency);
			blinklight.enabled = !blinklight.enabled;
		}
	}	

}
