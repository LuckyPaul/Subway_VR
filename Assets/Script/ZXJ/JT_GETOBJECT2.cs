using UnityEngine;
using System.Collections;
public class JT_GETOBJECT2 : MonoBehaviour {
	void OnTriggerEnter(Collider other)
	{
		JT_Hand.otherObject = gameObject;
		Debug.Log("otherObject="+gameObject.tag);
	}
	
	void OnTriggerExit(Collider other) {
		JT_Hand.otherObject = null;
	}
	
}
