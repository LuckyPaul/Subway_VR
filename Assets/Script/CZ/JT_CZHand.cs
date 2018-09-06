using UnityEngine;
using System.Collections;
using VRTK;
public class JT_CZHand : MonoBehaviour {
	Animator animator;
	
	void Awake()
	{
		GetComponentInParent<VRTK_ControllerEvents>().AliasGrabOn += new   ControllerInteractionEventHandler(DoUseOn);
		GetComponentInParent<VRTK_ControllerEvents>().AliasGrabOff += new  ControllerInteractionEventHandler(DoUseOff);
		animator = gameObject.GetComponent<Animator>();
	}
	
	private void DoUseOn(object sender, ControllerInteractionEventArgs e)
	{
		animator.SetBool("Hand",true);
	}
	
	private void DoUseOff(object sender, ControllerInteractionEventArgs e)
	{
		animator.SetBool("Hand",false);
	}
}
