using UnityEngine;
using System.Collections;
using VRTK;
using com.ootii.Messages;
using HighlightingSystem;

public class JT_Hand : MonoBehaviour {
	public static GameObject handObject;
	public static GameObject otherObject;
	void Start()
	{
		handObject = null;

		GetComponentInParent<VRTK_ControllerEvents>().AliasUseOn += new   ControllerInteractionEventHandler(DoUseOn);
		GetComponentInParent<VRTK_ControllerEvents>().AliasUseOff += new  ControllerInteractionEventHandler(DoUseOff);
	}
	
	
	private void DoUseOn(object sender, ControllerInteractionEventArgs e)
	{
		if (otherObject ==null)
		{
			Debug.Log("DoUseOn  otherObject is null");
			return;
		}
		
		if (handObject == null)
		{
			Debug.Log("DoUseOn  handObject is null");
			return;
		}
		
		if (handObject.name == otherObject.name)
		{
			if (otherObject.GetComponent<Highlighter>()!=null)
			{
				otherObject.GetComponent<Highlighter>().FlashingOff();
				Destroy(otherObject.GetComponent<Highlighter>());
			}
			
			if (otherObject.GetComponent<BoxCollider>()!=null)
				Destroy(otherObject.GetComponent<BoxCollider>());
			
			Object renderers = otherObject.GetComponent<Renderer>();
			if (renderers!=null)
			{
				Material[] materials = ((Renderer)renderers).materials;
				if (materials!=null)
					materials[0].shader = Shader.Find("Standard");
			}
		}else
		{
			Debug.Log("-------------------error----HandObj.tag="+handObject.tag+"----------gameObject.tag="+otherObject.tag+"---------------");
		}
	}
	
	private void DoUseOff(object sender, ControllerInteractionEventArgs e)
	{
		if (otherObject ==null)
		{
			Debug.Log("DoUseOn  otherObject is null");
			return;
		}
		
		if (handObject == null)
		{
			Debug.Log("DoUseOn  handObject is null");
			return;
		}
		
		if (handObject.name == otherObject.name)
		{
			handObject.SetActive(false);
			MessageDispatcher.SendMessage(this, "ON_MESSAGE_EVENT",otherObject.tag, EnumMessageDelay.IMMEDIATE);
		}	
	}
}
