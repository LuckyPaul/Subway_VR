using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {
	public Vector3 speed;

	private void Update () {
		transform.Translate (speed * Time.deltaTime);
	}
}
