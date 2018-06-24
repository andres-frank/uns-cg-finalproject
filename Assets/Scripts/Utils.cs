using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils{
	public static void TwoSideSurface(GameObject obj) {
		//Duplica cada Mesh de 'obj' e invierte sus normales.
		//Como resultado todas las Meshes son visibles de ambos lados (por dentro y por fuera).
		Renderer[] array = obj.gameObject.GetComponentsInChildren<Renderer>();
		GameObject aux;
		MeshCollider mc;
		foreach(Renderer r in array){
			aux = GameObject.Instantiate(r.gameObject, r.transform.parent, true);
			aux.name = r.gameObject.name;
			invertirNormales(aux);
			mc = aux.GetComponent<MeshCollider>();
			//if(mc != null)
				mc.sharedMesh = aux.GetComponent<MeshFilter>().mesh;
		}
	}
	
	public static void invertirNormales(GameObject obj){
		//Invierte las normales de 'obj' y tambien el sentido de recorrido de cada triangulo.
		MeshFilter filter = obj.GetComponent(typeof (MeshFilter)) as MeshFilter;
		if (filter != null)
		{
			Mesh mesh = filter.mesh;
 
			Vector3[] normals = mesh.normals;
			for (int i=0;i<normals.Length;i++)
				normals[i] = -normals[i];
			mesh.normals = normals;
 
			for (int m=0;m<mesh.subMeshCount;m++)
			{
				int[] triangles = mesh.GetTriangles(m);
				for (int i=0;i<triangles.Length;i+=3)
				{
					int temp = triangles[i + 0];
					triangles[i + 0] = triangles[i + 1];
					triangles[i + 1] = temp;
				}
				mesh.SetTriangles(triangles, m);
			}
		}		
	}

	public static Vector3 CartesianToSpherical(Vector3 cartCoords){
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

	public static Vector3 sphericalToCartesian(Vector3 sphCoords){
		Vector3 cartesians = new Vector3(); 
    	float aux = Mathf.Sin(sphCoords.z);
		cartesians.x= sphCoords.x * aux * Mathf.Cos(sphCoords.y);
		cartesians.y= sphCoords.x * Mathf.Cos(sphCoords.z);
		cartesians.z= sphCoords.x * aux * Mathf.Sin(sphCoords.y);
		return cartesians;
	}
}
