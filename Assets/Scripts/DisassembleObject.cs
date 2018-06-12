using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisassembleObject : MonoBehaviour {
	/*
	FEATURES
		Buttons:	    Action:
		 Space:			 Start movement
		 P:		  		 Pause movement
		 K:    			 Disassemble object
		 L:	     		 Assemble object
	*/

	// Use this for initialization
	public float velocity = 0.001f; 
	public float separationFactor = 1;

	private Vector3 centro;
	private struct objectMovementData{
		public Vector3 posFin; 
		public Vector3 vPaso; //Vector que contiene la direccion y el paso de avance
		public float distancia; //Desde el centro hasta la posFin
		public Transform t; 
	}
	private List<objectMovementData> listaObjetos = new List<objectMovementData>(); 
	private static bool armar = false;
	private static bool pause = true;

	void Start () {
		//Para varios objetos que vi, la posIni(transform.position) de cada sub objeto es la misma
		// que la del padre (centro). No se si se cumple para todos los objetos. Este algoritmo funciona
		// teniendo en cuenta lo anterior. Cada sub objeto se desplaza desde el "centro" hasta el centro del 
		// bounding box de cada sub objeto (posFin) con un determinado paso. La posFin puede ser ajustada 
		// con "separationFactor" y el paso con "velocity".

		//Centro del objeto en coordenadas del mundo.  
		centro = this.transform.position;
		//Arreglo con la componente Renderer de todos los sub objetos que van a ser renderizados.
		Renderer[] array = this.gameObject.GetComponentsInChildren<Renderer>(); 
		
		foreach(Renderer r in array){
			objectMovementData omd = new objectMovementData();
			omd.posFin = r.bounds.center; //Centro del boundig box del sub objeto
			omd.posFin = centro + (omd.posFin - centro) * separationFactor;
			omd.distancia = Vector3.Magnitude(omd.posFin-centro);
			omd.vPaso = (omd.posFin - centro) * velocity; //Todos los sub objetos llegan al punto final al mismo tiempo. 
			omd.t = r.GetComponent<Transform>();
			listaObjetos.Add(omd);
		}
	}
	
	// FixedUpdate is called every fixed framerate frame.
	void FixedUpdate () {
		if(Input.GetKey(KeyCode.Space)){ pause = false; }
		if(Input.GetKey(KeyCode.P)){ pause = true; }
		if(!pause){
			if(Input.GetKey(KeyCode.K)){ armar = true; }
			if(Input.GetKey(KeyCode.L)){ armar = false; }
			foreach(objectMovementData omd in listaObjetos){
				if(armar){
					if(Vector3.Magnitude(omd.posFin-omd.t.position) < omd.distancia){	
						omd.t.position -= omd.vPaso;
					}
				}
				else{ //Desarmar
					if(Vector3.Magnitude(omd.posFin-omd.t.position) > 0.5f){	
						omd.t.position += omd.vPaso;
					}
				}
			}
		}		
	}

	//Funciones auxiliares
	private Vector3 CartesianToSpherical(Vector3 cartCoords){
		Vector3 sphericals = new Vector3(); //(r,thita,phi) thita[0,2PI] y phi[0,PI]
    	if (cartCoords.x == 0f)
        	cartCoords.x = Mathf.Epsilon; //Valor muy chiquito cercano a 0
		
		sphericals.x = Mathf.Sqrt((cartCoords.x * cartCoords.x)
						+ (cartCoords.y * cartCoords.y)
						+ (cartCoords.z * cartCoords.z));
		sphericals.y = Mathf.Atan(cartCoords.z / cartCoords.x);
		if (cartCoords.x < 0)
			sphericals.y += Mathf.PI;
		sphericals.z = Mathf.Acos(cartCoords.y / sphericals.x);
		return sphericals;
	}

	private Vector3 sphericalToCartesian(Vector3 sphCoords){
		Vector3 cartesians = new Vector3(); 
    	float aux = Mathf.Sin(sphCoords.z);
		cartesians.x= sphCoords.x * aux * Mathf.Cos(sphCoords.y);
		cartesians.y= sphCoords.x * Mathf.Cos(sphCoords.z);
		cartesians.z= sphCoords.x * aux * Mathf.Sin(sphCoords.y);
		return cartesians;
	}

}
