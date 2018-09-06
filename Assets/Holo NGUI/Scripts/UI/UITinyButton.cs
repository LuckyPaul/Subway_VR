using UnityEngine;
using System.Collections;

[ExecuteInEditMode()]
public class UITinyButton : MonoBehaviour {

	public enum UITinyButtonTypes {
		Decline,
		Accept,
		Social,
		Mail,
	}

	public UISprite sprite;
	private UITinyButtonTypes mType;

	public UITinyButtonTypes type { 
		get { return mType; }
		set {
			mType = value;
			OnTypeChanged();
		} 
	}

	void Start()
	{
		if (sprite == null) return;
		
		switch (sprite.spriteName)
		{
		case "tinyButton_Accept":
			mType = UITinyButtonTypes.Accept;
			break;
		case "tinyButton_Decline":
			mType = UITinyButtonTypes.Decline;
			break;
		case "tinyButton_Social":
			mType = UITinyButtonTypes.Social;
			break;
		case "tinyButton_Mail":
			mType = UITinyButtonTypes.Mail;
			break;
		}
	}
	
	private void OnTypeChanged()
	{
		if (sprite == null) return;

		switch (mType)
		{
			case UITinyButtonTypes.Accept:
				sprite.spriteName = "tinyButton_Accept";
				break;
			case UITinyButtonTypes.Decline:
				sprite.spriteName = "tinyButton_Decline";
				break;
			case UITinyButtonTypes.Social:
				sprite.spriteName = "tinyButton_Social";
				break;
			case UITinyButtonTypes.Mail:
				sprite.spriteName = "tinyButton_Mail";
				break;
		}

		sprite.Update();
		sprite.MarkAsChanged();
	}
}
