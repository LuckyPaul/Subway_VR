using UnityEngine;
using System.Collections;

public class JT_LookAt : MonoBehaviour {

	protected void FixedUpdate()
	{
		if (transform != null && Camera.main != null) {
			this.transform.forward = new Vector3 (transform.position.x - Camera.main.transform.position.x, 0, transform.position.z - Camera.main.transform.position.z);
		}
	}
}
