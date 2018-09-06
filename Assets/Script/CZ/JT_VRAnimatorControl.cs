using UnityEngine;
using System.Collections;
using com.ootii.Messages;
using HighlightingSystem;

public class JT_VRAnimatorControl : MonoBehaviour {
	public GameObject[]  obj;
	AudioSource oldmusic;
	Animator animator;
	bool _open_door_down = false;
	bool _open_door_up = false;
	bool _GameOver =false;
	
	void Awake()
	{
		animator = gameObject.GetComponent<Animator>();
		MessageDispatcher.AddListener("ON_MESSAGE_EVENT", OnMessageReceived);
	}
	
	void init()
	{
		animator.SetBool("open_door_down",false);
		animator.SetBool("close_door_down",false);
		animator.SetBool("open_door_up",false);
		animator.SetBool("close_door_up",false);
		animator.SetBool("Action1",false);
		animator.SetBool("Action2",false);
		animator.SetBool("Action3",false);
		animator.SetBool("Action4",false);
	}
	
	void SetFlashing(JT_VRControl _JT_VRControl,bool bl)
	{
		_JT_VRControl.flashing = bl;
		
		switch(bl)
		{
		case true:
			_JT_VRControl.h.FlashingOn();
			break;
			
		case false:
			_JT_VRControl.h.FlashingOff();
			break;
		}
	}
	
	void OnMessageReceived(IMessage rMessage)
	{	
		JT_MsgEvent msg = ((JT_MsgEvent) rMessage.Data);
		PlaySound(msg.audio);
		if (obj[msg.index]!=null){
			if (_open_door_up &&  msg.index == 2)
			{
				gameObject.GetComponent<AudioSource>().Play();
				SetFlashing(obj[0].GetComponent<JT_VRControl>(),true);
			}else
				if (_open_door_down &&  msg.index == 1)
				{
					_GameOver = true;
				}
				else{
					SetFlashing(obj[msg.index].GetComponent<JT_VRControl>(),true);
				}			
		}
		if (!_GameOver){
			SetFlashing(msg.jt_MsgEvent,false);
		}
			
		init();
		switch(msg.index)
		{
		case 1:
			if (_open_door_down == false)
				open_door_down();
			else{
				_GameOver = false;
				close_door_down();
			}			
			break;
			
		case 2:
			if (_open_door_up == false)
				open_door_up();
			else
				close_door_up();
			break;
			
		case 3:
			break;
			
		case 4:
			break;
			
		case 5:
			Action1();
			break;
			
		case 6:
			Action2();
			break;
			
		case 7:
			Action3();
			break;
			
		case 8:
			Action4();
			break;
		}
	}
	
	
	void PlaySound(AudioSource music)
	{
		if (oldmusic==null)
			oldmusic = music;
		else
			oldmusic.Stop();
		oldmusic = music;
		if (music.isPlaying){
			music.Stop();
		}
		music.Play();
	}
	
	// This function is called when the MonoBehaviour will be destroyed.
	protected void OnDestroy()
	{
		MessageDispatcher.RemoveListener("ON_MESSAGE_EVENT", OnMessageReceived);
	}
	
	
	void open_door_down()
	{
		_open_door_down = true;
		AnimatorStateInfo stateinfo = animator.GetCurrentAnimatorStateInfo(0);
		if(stateinfo.IsName("Base Layer.open_door_down"))
			return;
	
		if (animator!=null)
			animator.SetBool("open_door_down",true);
	}
	
	
	public void close_door_down()
	{
		_open_door_down = false;
		AnimatorStateInfo stateinfo = animator.GetCurrentAnimatorStateInfo(0);
		if(stateinfo.IsName("Base Layer.close_door_down"))
			return;
		
		if (animator!=null)
			animator.SetBool("close_door_down",true);
	}
	
	void open_door_up()
	{
		_open_door_up  = true;
		AnimatorStateInfo stateinfo = animator.GetCurrentAnimatorStateInfo(0);
		if(stateinfo.IsName("Base Layer.open_door_up"))
			return;
		
		if (animator!=null)
			animator.SetBool("open_door_up",true);
	}
	
	public void close_door_up()
	{
		_open_door_up  = false;
		AnimatorStateInfo stateinfo = animator.GetCurrentAnimatorStateInfo(0);
		if(stateinfo.IsName("Base Layer.close_door_up"))
			return;
		
		if (animator!=null)
			animator.SetBool("close_door_up",true);
	}
	
	void Action1()
	{	
		AnimatorStateInfo stateinfo = animator.GetCurrentAnimatorStateInfo(0);
		if(stateinfo.IsName("Base Layer.Action1"))
			return;
		
		if (animator!=null)
			animator.SetBool("Action1",true);
	}
	
	void Action2()
	{
		AnimatorStateInfo stateinfo = animator.GetCurrentAnimatorStateInfo(0);
		if(stateinfo.IsName("Base Layer.Action2"))
			return;
		
		if (animator!=null)
			animator.SetBool("Action2",true);
	}
	
	void Action3()
	{
		AnimatorStateInfo stateinfo = animator.GetCurrentAnimatorStateInfo(0);
		if(stateinfo.IsName("Base Layer.Action3"))
				return;
		
			if (animator!=null)
			animator.SetBool("Action3",true);
	}
	
	void Action4()
	{
			AnimatorStateInfo stateinfo = animator.GetCurrentAnimatorStateInfo(0);
			if(stateinfo.IsName("Base Layer.Action4"))
				return;
		
			if (animator!=null)
			animator.SetBool("Action4",true);
	}
}
