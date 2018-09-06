using UnityEngine;
using System.Collections;

public class HealthController : MonoBehaviour {
	public float health=20;
	
	private void Damage(float damage){
		health -= damage;
	}
}
