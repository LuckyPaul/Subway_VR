using UnityEngine;
using System.Collections;
using HighlightingSystem;
using com.ootii.Messages;

public class JT_Zha : MonoBehaviour {
	Highlighter h;
	void Start () {
		MessageDispatcher.AddListener("ON_MESSAGE_ZhaJiON_EVENT", OnZhaJiONReceived);
		MessageDispatcher.AddListener("ON_MESSAGE_ZhaJiOFF_EVENT", OnZhaJiOFFReceived);
	}
	
	void OnZhaJiONReceived(IMessage rMessage)
	{	
		h = gameObject.GetComponent<Highlighter>();
		if (h == null) { 
			h = gameObject.AddComponent<Highlighter>(); 
		}
		h.FlashingOn();
	}
	
	void OnZhaJiOFFReceived(IMessage rMessage)
	{	
		h.FlashingOff();
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag.Equals("Ditieka"))
		{
			Destroy(other.gameObject);
			MessageDispatcher.SendMessage(this, "ON_MESSAGE_HiddenObject_EVENT", "", EnumMessageDelay.IMMEDIATE);
		}
	}
	
}
