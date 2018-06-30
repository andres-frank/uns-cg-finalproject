using UnityEngine;
using System.Collections.Generic;

public class GlowObject : MonoBehaviour{
	public Color GlowColor;

	private Material[] materials = null;
	
	void Start(){
		enabled = false;
	}
	public void StartGlowing(Transform t){
		if(materials != null){
			StopGlowing();
		}
		if(t != null){
			materials = t.GetComponent<Renderer>().materials;
			for (int i = 0; i < materials.Length; i++){
				materials[i].SetColor("_GlowColor", GlowColor);
			}
		}
		enabled = true;
	}

	public void StopGlowing(){
		for (int i = 0; i < materials.Length; i++){
			materials[i].SetColor("_GlowColor", Color.black);
		}
		enabled = true;
	}


	void Update(){
		enabled = false;
	}

}
