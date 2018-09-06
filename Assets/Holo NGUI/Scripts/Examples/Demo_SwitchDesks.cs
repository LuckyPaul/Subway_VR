using UnityEngine;
using System.Collections;

public class Demo_SwitchDesks : MonoBehaviour {

	// Activate standrad windows
	public void OnActivate0(bool check)
	{
		if (check)
		{
			if (UIWindow.GetWindow(1)) UIWindow.GetWindow(1).Show();
			if (UIWindow.GetWindow(2)) UIWindow.GetWindow(2).Show();
			if (UIWindow.GetWindow(3)) UIWindow.GetWindow(3).Show();
		}
		else
		{
			if (UIWindow.GetWindow(1)) UIWindow.GetWindow(1).Hide();
			if (UIWindow.GetWindow(2)) UIWindow.GetWindow(2).Hide();
			if (UIWindow.GetWindow(3)) UIWindow.GetWindow(3).Hide();
		}
	}

	// Activate login window
	public void OnActivate1(bool check)
	{
		if (UIWindow.GetWindow(4) == null)
			return;

		if (check)
		{
			UIWindow.GetWindow(4).Show();
		}
		else
		{
			UIWindow.GetWindow(4).Hide();
		}
	}

	// Activate table window
	public void OnActivate2(bool check)
	{
		if (UIWindow.GetWindow(5) == null)
			return;

		if (check)
		{
			UIWindow.GetWindow(5).Show();
		}
		else
		{
			UIWindow.GetWindow(5).Hide();
		}
	}

	// Activate loading bar
	public void OnActivate3(bool check)
	{
		if (UIWindow.GetWindow(6) == null)
			return;

		if (check)
		{
			UIWindow.GetWindow(6).Show();
		}
		else
		{
			UIWindow.GetWindow(6).Hide();
		}
	}
}
