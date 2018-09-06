using UnityEngine;
using System.Collections;

public class JT_welcome : MonoBehaviour {
	public void  OnBtnClickCZ () {
		JT_Core.instance.index = 1;
		Application.LoadLevel("CZ");
	}
	
	public void  OnBtnClickZXJ () {
		JT_Core.instance.index = 2;
		Application.LoadLevel("ZXJ");
	}
	
	public void  OnBtnClickCZ2 () {
		JT_Core.instance.index = 3;
		Application.LoadLevel("CZ");
	}
}
