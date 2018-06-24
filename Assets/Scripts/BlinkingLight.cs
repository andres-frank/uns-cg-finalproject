using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingLight : MonoBehaviour {

	[Range(0, 3)]
	public float blinkfrequency = 1.7f;

	Light blinklight;

	void Start () {
		blinklight = GetComponent<Light>();
		StartCoroutine(Blinking());
	}

	IEnumerator Blinking() {
		while (true) {
			yield return new WaitForSeconds(blinkfrequency);
			blinklight.enabled = !blinklight.enabled;
		}
	}	

}
