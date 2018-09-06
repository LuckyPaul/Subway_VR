using UnityEngine;
using System.Collections;
using com.ootii.Messages;

public class JT_Tight : MonoBehaviour {
	
	void OnTriggerEnter(Collider other)
	{
		Debug.Log(gameObject.tag);
		if (gameObject.tag.Equals("portal1"))
		{
			MessageDispatcher.SendMessage(this, "ON_MESSAGE_PORTAL1_EVENT", "", EnumMessageDelay.IMMEDIATE);
		}
		
		if (gameObject.tag.Equals("portal2"))
		{
			MessageDispatcher.SendMessage(this, "ON_MESSAGE_PORTAL2_EVENT", "", EnumMessageDelay.IMMEDIATE);
			MessageDispatcher.SendMessage(this, "ON_MESSAGE_ZhaJiON_EVENT", "", EnumMessageDelay.IMMEDIATE);
		}
		
		if (gameObject.tag.Equals("portal3"))
		{
			MessageDispatcher.SendMessage(this, "ON_MESSAGE_PORTAL3_EVENT", "", EnumMessageDelay.IMMEDIATE);
			MessageDispatcher.SendMessage(this, "ON_MESSAGE_ZhaJiOFF_EVENT", "", EnumMessageDelay.IMMEDIATE);
		}
	}
	
}
