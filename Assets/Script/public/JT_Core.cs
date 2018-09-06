using UnityEngine;
using System.Collections;

public class JT_Core : MonoBehaviour {
	public  static JT_Core instance;
	[HideInInspector]
	public  int  index;
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this);
		instance = this;
		index = 0;
	}
	
}
