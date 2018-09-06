using UnityEngine;
using System.Collections;
using com.ootii.Messages;

public class JT_CZInit : MonoBehaviour {
	public AudioClip[]  sound;
	public GameObject Player;
	public GameObject[] obj;
	public GameObject PWY;
	public GameObject jiantou;
	AudioClip  CnterSound;
	AudioSource audio ;
	
	void Awake()
	{
		if (JT_Core.instance.index == 1)
		{
			Player.transform.position = new Vector3(54.79f,0f,6.32f);
		}
		if (JT_Core.instance.index == 3)
		{
			Player.transform.position = new Vector3(47.54f,0f,-11.07f);
			MessageDispatcher.AddListener("ON_MESSAGE_PORTAL1_EVENT", OnPortal1Received);
			MessageDispatcher.AddListener("ON_MESSAGE_PORTAL2_EVENT", OnPortal2Received);
			MessageDispatcher.AddListener("ON_MESSAGE_PORTAL3_EVENT", OnPortal3Received);
			MessageDispatcher.AddListener("ON_MESSAGE_PORTAL4_EVENT", OnPortal4Received);
			audio = gameObject.GetComponent<AudioSource>();
			CnterSound = sound[0];
		}
	}
	

	void Start () {
		if (JT_Core.instance.index == 3)
		{
			InvokeRepeating("Timer", 3f,5f);
			obj[0].SetActive(true);
		}
	}
	
	void Timer() {
		audio.Stop();
		audio.PlayOneShot(CnterSound,1f);
	}
	
	
	void OnPortal1Received(IMessage rMessage)
	{	
		obj[1].SetActive(true);
		obj[0].SetActive(false);
		PWY.GetComponent<Animator>().SetBool("PWY",true);
		CnterSound = sound[1];
		jiantou.SetActive(true);
	}
	
	void OnPortal2Received(IMessage rMessage)
	{	
		obj[1].SetActive(false);
		CnterSound = sound[2];
		obj[2].SetActive(true);
		jiantou.SetActive(false);
	}
	
	void OnPortal3Received(IMessage rMessage)
	{	
		obj[2].SetActive(false);
		CancelInvoke("Timer");
		PWY.GetComponent<Animator>().SetBool("PWY",false);
		audio.PlayOneShot(sound[3],1f);
	}
	
	void OnPortal4Received(IMessage rMessage)
	{	
		Debug.Log("OnPortal4Received");
		CnterSound = sound[2];
	}
}
