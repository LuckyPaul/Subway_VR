using UnityEngine;
using System.Collections;
using VRTK;

public class JT_GETOBJECT : VRTK_InteractableObject {

	public override void Grabbed(GameObject currentGrabbingObject)
	{
		base.Grabbed(currentGrabbingObject);
		JT_Hand.handObject = gameObject;
		Debug.Log("Grabbed="+currentGrabbingObject.name);
	}
	
	public override void Ungrabbed(GameObject currentGrabbingObject)
	{
		base.Ungrabbed(currentGrabbingObject);
		JT_Hand.handObject = null;
		Debug.Log("Ungrabbed="+currentGrabbingObject.name);
	}
}
