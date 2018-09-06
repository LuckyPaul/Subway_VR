using UnityEngine;
using System.Collections;
using VRTK;
using com.ootii.Messages;
using HighlightingSystem;

public class JT_VRControl : VRTK_InteractableObject {
	
	[HideInInspector]
	public Highlighter h;
	[HideInInspector]
	public bool flashing = false;
	
	void Awake()
	{
		if (JT_Core.instance.index ==1)
		{
			h = GetComponent<Highlighter>();
			if (h == null) { 
				h = gameObject.AddComponent<Highlighter>(); 
			}
			h.SeeThroughOff();
			if (transform.tag.Trim().Equals("1"))
			{
				h.FlashingOn();
				flashing = true;
			}
		}
	}
	
	public override void StartUsing(GameObject usingObject)
	{
		base.StartUsing(usingObject);
		if (JT_Core.instance.index ==1)
		{
			if (flashing)
				SendMsgEvent();
		}
	}
	
	void SendMsgEvent() {
		JT_MsgEvent msg = new JT_MsgEvent();
		msg.index = int.Parse(transform.tag);
		msg.jt_MsgEvent = this;
		msg.audio = gameObject.GetComponent<AudioSource>();
		MessageDispatcher.SendMessage(this, "ON_MESSAGE_EVENT", msg, EnumMessageDelay.IMMEDIATE);
	}
}
