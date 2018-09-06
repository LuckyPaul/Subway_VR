using UnityEngine;
using System.Collections;
using HighlightingSystem;
using com.ootii.Messages;

public class JT_CARD : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		Debug.Log("OnTriggerEnter="+other.gameObject.tag +"   "+other.gameObject.name);
		if (other.gameObject.name.Equals("Body"))
		{
			MessageDispatcher.SendMessage(this, "ON_MESSAGE_PORTAL4_EVENT", "", EnumMessageDelay.IMMEDIATE);
			Highlighter h = gameObject.GetComponent<Highlighter>();
			if (h == null) { 
				h = gameObject.AddComponent<Highlighter>(); 
			}
			h.FlashingOff();
			other.GetComponent<MeshCollider>().isTrigger=false;
			
			
		}
	}
}
