using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisassembleObject : MonoBehaviour {
	/*
	FEATURES
		Buttons:	    Action:
		 P:			 	 Start/Pause movement
		 Space:    		 Assemble/Disassemble mode
	*/

	// Use this for initialization
	public float velocity = 0.01f; 
	public float separationFactor = 2;

	private Vector3 centro;
	private struct objectMovementData{
		public Vector3 posIni, posFin; 
		public Vector3 vPaso; //Vector que contiene la direccion y el paso de avance
		public float distancia; //Distancia entre posIni y posFin
		public Transform t; 
	}
	private List<objectMovementData> listaObjetos = new List<objectMovementData>(); 
	private bool armar = true;
	private static bool pause = false;

	public bool isEnabled = false;

	void Start () {
		// Cada sub objeto se desplaza desde su posIni hasta una posFin con un determinado paso.
		// Dicha posFin se encuetra sobre la recta que se forma entre el 'centro' y posIni. 
		// La posFin puede ser ajustada con "separationFactor" y el paso con "velocity".

		//Para poder ver ambos lados de cada mesh.
		Utils.TwoSideSurface(this.gameObject);

		//Centro del objeto en coordenadas del mundo. 
		//Se puede mejorar calculando el centro del objeto. 
		centro = this.transform.position;

		//Arreglo con la componente Renderer de todos los sub objetos que van a ser renderizados.
		//Es decir, todos los hijos hoja del objeto.
		Renderer[] array = this.gameObject.GetComponentsInChildren<Renderer>(); 
		
		foreach(Renderer r in array){
			objectMovementData omd = new objectMovementData();
			omd.t = r.GetComponent<Transform>();
			omd.posIni = omd.t.position;
			
			//posFin depende de si posIni coincide con el 'centro'.
			if(Vector3.Magnitude(omd.t.position-centro) < 0.001f){
				omd.posFin = r.bounds.center; //Centro del boundig box del sub objeto
			}
			else{
				omd.posFin = omd.t.position; 
			}
			//posFin segun el separationFactor 
			omd.posFin = centro + (omd.posFin - centro) * separationFactor;
			//vPaso para que todos los sub objetos llegen al punto final al mismo tiempo. 
			omd.vPaso = (omd.posFin - centro) * velocity;
			omd.distancia = Vector3.Magnitude(omd.posFin - omd.posIni);
			listaObjetos.Add(omd);
		}
	}
	
	// FixedUpdate is called every fixed framerate frame.
	void FixedUpdate () {

		if (!isEnabled) return;

		// if(Input.GetKeyDown(KeyCode.R)){ pause = !pause; }
		if(!pause){
			// if(Input.GetKeyDown(KeyCode.Space)){ armar = !armar; }
			foreach(objectMovementData omd in listaObjetos){
				if(armar){
					if(Vector3.Magnitude(omd.posFin-omd.t.position) < omd.distancia){
						if(Vector3.Magnitude(omd.posFin-(omd.t.position-omd.vPaso)) > omd.distancia){
							omd.t.position = omd.posIni;
						}
						else
							omd.t.position -= omd.vPaso;
					}
				}
				else{ //Desarmar
					if(Vector3.Magnitude(omd.posIni-omd.t.position) < omd.distancia){	
						omd.t.position += omd.vPaso;
					}
				}
			}
		}		
	}

	public void togglePause(){
		pause = !pause;
	}

	public void toggleArmar(){
		armar = !armar;
	}

	public void Enable(){
		isEnabled = true;
	}

	public void Disable(){
		isEnabled = false;
	}

}
