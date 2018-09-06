using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SwitchScene : MonoBehaviour {
	public List<Entry> scenes;
	public Texture2D left;
	public Texture2D right;

	[System.Serializable]
	public class Entry{
		public string scene;
		public string description;
	}

	private void OnGUI(){
		Entry entry = scenes.Find (x => x.scene == Application.loadedLevelName);
		int index = scenes.FindIndex (x => x.scene == Application.loadedLevelName);
		GUILayout.BeginArea (new Rect (Screen.width * 0.5f-200, 5, 400, 100), "", "box");

		GUILayout.Label(entry.scene);
		GUILayout.BeginHorizontal ();
		Rect rect=GUILayoutUtility.GetRect (50, 50);
		GUI.color = rect.Contains (Event.current.mousePosition) ? Color.green : Color.white;
		if (GUI.Button (rect,left, "label")) {
			if(index<=0){
				index=scenes.Count;
			}
			Application.LoadLevel(scenes[index-1].scene);
		}
		GUI.color = Color.white;
		GUIStyle style = new GUIStyle (GUI.skin.label);
		style.alignment = TextAnchor.LowerCenter;
		GUILayout.Label(entry.description,style);
		rect=GUILayoutUtility.GetRect (50, 50);
		GUI.color = rect.Contains (Event.current.mousePosition) ? Color.green : Color.white;
		if (GUI.Button (rect,right, "label")) {
			if(index>=scenes.Count-1){
				index=-1;
			}
			Debug.Log(index+1);
			Application.LoadLevel(scenes[index+1].scene);
		}
		GUI.color = Color.white;
		GUILayout.EndHorizontal ();
		GUILayout.EndArea ();
	}
}
