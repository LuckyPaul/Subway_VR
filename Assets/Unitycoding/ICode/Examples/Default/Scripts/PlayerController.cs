using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public string parameter="Damage";
	public float damageDistance=2.0f;
	public LayerMask mask;
	public void SendDamage(int damage){
		RaycastHit hit;
		//Send a ray from players transform with his forward direction
		if (Physics.Raycast (transform.position + Vector3.up, transform.forward, out hit, damageDistance, mask)) {
			hit.transform.SendMessage("SetParameter",new object[]{parameter,damage});
		}
	}
}
