using UnityEngine;
using System.Collections;

[ExecuteInEditMode()]
[RequireComponent(typeof(UIButton))]
public class UIIconButton : MonoBehaviour {
	
	public enum UIIconButtonTypes {
		Heart,
		Plus,
		Decline,
		Star,
	}
	
	public UISprite sprite;
	public UIButton button;
	private UIIconButtonTypes mType;
	
	public UIIconButtonTypes type { 
		get { return mType; }
		set {
			mType = value;
			OnTypeChanged();
		} 
	}
	
	void Start()
	{
		if (button == null) button = GetComponent<UIButton>();
		if (sprite == null) return;
		
		switch (sprite.spriteName)
		{
		case "iconButton_Heart_Normal":
			mType = UIIconButtonTypes.Heart;
			break;
		case "iconButton_Plus_Normal":
			mType = UIIconButtonTypes.Plus;
			break;
		case "iconButton_Decline_Normal":
			mType = UIIconButtonTypes.Decline;
			break;
		case "iconButton_Star_Normal":
			mType = UIIconButtonTypes.Star;
			break;
		}
	}
	
	private void OnTypeChanged()
	{
		if (sprite == null) return;
		
		switch (mType)
		{
			case UIIconButtonTypes.Heart:
			{
				sprite.spriteName = "iconButton_Heart_Normal";
				button.normalSprite = "iconButton_Heart_Normal";
				button.hoverSprite = "iconButton_Heart_Hover";
				button.pressedSprite = "iconButton_Heart_Pressed";
				button.disabledSprite = "iconButton_Heart_Normal";
				break;
			}
			case UIIconButtonTypes.Plus:
			{
				sprite.spriteName = "iconButton_Plus_Normal";
				button.normalSprite = "iconButton_Plus_Normal";
				button.hoverSprite = "iconButton_Plus_Hover";
				button.pressedSprite = "iconButton_Plus_Pressed";
				button.disabledSprite = "iconButton_Plus_Normal";
				break;
			}
			case UIIconButtonTypes.Decline:
			{
				sprite.spriteName = "iconButton_Decline_Normal";
				button.normalSprite = "iconButton_Decline_Normal";
				button.hoverSprite = "iconButton_Decline_Hover";
				button.pressedSprite = "iconButton_Decline_Pressed";
				button.disabledSprite = "iconButton_Decline_Normal";
				break;
			}
			case UIIconButtonTypes.Star:
			{
				sprite.spriteName = "iconButton_Star_Normal";
				button.normalSprite = "iconButton_Star_Normal";
				button.hoverSprite = "iconButton_Star_Hover";
				button.pressedSprite = "iconButton_Star_Pressed";
				button.disabledSprite = "iconButton_Star_Normal";
				break;
			}
		}

		sprite.Update();
		sprite.MarkAsChanged();
		sprite.MakePixelPerfect();
	}
}
