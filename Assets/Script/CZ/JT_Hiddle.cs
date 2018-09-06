using UnityEngine;
using System.Collections;
using com.ootii.Messages;
public class JT_Hiddle : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (JT_Core.instance.index == 3)
		{
			MessageDispatcher.AddListener("ON_MESSAGE_HiddenObject_EVENT", HiddenObject);
			HiddenRenderer();
		}
		else
			HiddenObject(null);
	}
	
	void HiddenRenderer()
	{
		foreach (Transform child in gameObject.transform)
		{
			Object [] renderers = child.gameObject.GetComponents<Renderer>();
			for (int i = 0; i < renderers.Length; i++)
			{
				((Renderer)renderers[i]).enabled = false;
			}
		}
	}
	
	void HiddenObject(IMessage rMessage)
	{
		foreach (Transform child in gameObject.transform)
		{
			child.gameObject.SetActive(false);
		}
	}
	
	
}
