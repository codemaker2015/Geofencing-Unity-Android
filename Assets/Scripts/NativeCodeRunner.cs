﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NativeCodeRunner : MonoBehaviour
{
	void Start(){
		CallNativePlugin();
	}

	//method that calls our native plugin.
	public void CallNativePlugin() {
		// Retrieve the UnityPlayer class.
		AndroidJavaClass unityPlayerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");

		// Retrieve the UnityPlayerActivity object ( a.k.a. the current context )
		AndroidJavaObject unityActivity = unityPlayerClass.GetStatic<AndroidJavaObject>("currentActivity");

		// Retrieve the "Bridge" from our native plugin.
		// ! Notice we define the complete package name.              
		AndroidJavaObject alert = new AndroidJavaObject("io.nlopez.smartlocation.SmartLocationImpl");

		// Setup the parameters we want to send to our native plugin.              
		object[] parameters = new object[1];
		parameters[0] = unityActivity;
//		//parameters[1] = "Hello World!";


		// Call PrintString in bridge, with our parameters.
		alert.Call("startLocation", parameters);
	}
}