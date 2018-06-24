using UnityEngine;

public class ObjectClicker : MonoBehaviour {

	private RaycastHit hit;
	private	Ray ray;

	/**
	 * Based on a mouse click, return the first object found in the trajectory, if any.
	 * 
	 * @param {Vector3} mPos The position of the click.
	 * @return {Transform} The clicked object. Null if no object was found in the click.
	 */
	public Transform ObtainObjectClicked (Vector3 mPos) {

		ray = Camera.main.ScreenPointToRay(mPos);
		
		if (Physics.Raycast(ray, out hit, 100.0f)){

			return hit.transform;

		} else return null;
	}

}