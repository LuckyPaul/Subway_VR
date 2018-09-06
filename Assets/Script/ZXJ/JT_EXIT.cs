using UnityEngine;
using System.Collections;

public class JT_EXIT : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		Application.LoadLevel("welcome");
	}
}
