using UnityEngine;
using System.Collections;
using HighlightingSystem;
using com.ootii.Messages;
using VRTK;

public class JT_Init : MonoBehaviour {

	// Use this for initialization
	public GameObject[] obj;
	public GameObject exit;
	Animator animator;
	void Awake()
	{
		animator = gameObject.GetComponent<Animator>();
		MessageDispatcher.AddListener("ON_MESSAGE_EVENT", OnMessageReceived);
	}
	

	
	void OnMessageReceived(IMessage rMessage)
	{	
		SetupComponent(int.Parse(((string) rMessage.Data)));
	}
	
	void Start () {
		HiddenAll();
		SetupComponent(0);
	}
	
	void HiddenAll()
	{
		foreach (Transform child in gameObject.transform)
		{
			Object [] renderers = child.gameObject.GetComponents<Renderer>();
			for (int i = 0; i < renderers.Length; i++)
			{
				Material[] materials = ((Renderer)renderers[i]).materials;
				for (int j = 0; j < materials.Length; j++)
				{
					if (materials[j].shader.name == "Standard")
					{
						materials[j].shader = Shader.Find("UI/Default");
					}
				}
			}
		}
	}

	void SetupComponent(int num)
	{
		num =  (num>22)?-1:num;
		if (num==-1)
		{
			exit.SetActive(true);
			return;
		}
	
		
		//if (num>3)
		//	animator.SetBool(string.Format("Action1{0}",num),true);
		
		Highlighter h = gameObject.GetComponent<Highlighter>();
		if (h == null) { 
			h = obj[num].AddComponent<Highlighter>(); 
		}
		h.FlashingOn();
		BoxCollider b = GetComponent<BoxCollider>();
		if (b == null) { 
			b = obj[num].AddComponent<BoxCollider>();
			b.isTrigger = true;
		}
	}
	
	protected void OnDestroy()
	{
		MessageDispatcher.RemoveListener("ON_MESSAGE_EVENT", OnMessageReceived);
	}
}
