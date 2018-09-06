using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {
	public Vector3 rotationSpeed;
	public Space space;

	private void Update () {
		transform.Rotate(rotationSpeed*Time.deltaTime,space);	
	}
}
