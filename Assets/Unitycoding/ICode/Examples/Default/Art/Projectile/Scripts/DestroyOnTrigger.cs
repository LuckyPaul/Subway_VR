using UnityEngine;
using System.Collections;

public class DestroyOnTrigger : MonoBehaviour {

	private void OnTriggerEnter(Collider other){
		Debug.Log (other.gameObject);
			Destroy (gameObject);
	}
}
