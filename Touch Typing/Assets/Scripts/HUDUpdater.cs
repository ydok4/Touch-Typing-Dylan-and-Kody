﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUDUpdater : MonoBehaviour {
	
	public Text scoreText, missedText, timeText;
	public Text rightText, leftText;
	void Start () {
		//ensure is not visible on start, press F5 to activate
		GameObject.Find ("DebugMenu").GetComponentInChildren<Canvas>().enabled = false;
	}

	void Update () {
		//udate HUD score, time and missed values
		if(scoreText!=null)
			scoreText.text = "Score: " +  GameObject.Find ("Main Camera").GetComponent<controllerScript> ().score;
		if(missedText!=null)
			missedText.text = "Missed: " + GameObject.Find ("Main Camera").GetComponent<controllerScript> ().missed;
		if (timeText != null) {
			timeText.text = "Time: " + GameObject.Find ("Main Camera").GetComponent<controllerScript> ().time.ToString ("F2");
			if(GameObject.Find ("Main Camera").GetComponent<controllerScript> ().time < 0)
				timeText.text = "Time: 0";
		}
		//toggle pause menu
		if (GameObject.Find ("Main Camera").GetComponent<controllerScript> ().paused == true)
			GameObject.Find ("PauseMenu").GetComponentInChildren<Canvas>().enabled = true;
		 else 
			GameObject.Find ("PauseMenu").GetComponentInChildren<Canvas>().enabled = false;
		
		//toggle debug log
		if (Input.GetKeyDown (KeyCode.F5)) {
			if(GameObject.Find ("DebugMenu").GetComponentInChildren<Canvas>().enabled == true)
				GameObject.Find ("DebugMenu").GetComponentInChildren<Canvas>().enabled = false;
			else
				GameObject.Find ("DebugMenu").GetComponentInChildren<Canvas>().enabled = true;
		}
		if (rightText != null)
			rightText.text = "Right Palm x: " + GameObject.Find ("DebugMenu").GetComponent<PalmPosition>().right.x + "\nRight Palm y: " + GameObject.Find ("DebugMenu").GetComponent<PalmPosition>().right.y + "\nRight Palm z: " + GameObject.Find ("DebugMenu").GetComponent<PalmPosition>().right.z;
		if (leftText != null)
			leftText.text = "Left Palm x: " + GameObject.Find ("DebugMenu").GetComponent<PalmPosition>().left.x + "\nLeft Palm y: " + GameObject.Find ("DebugMenu").GetComponent<PalmPosition>().left.y + "\nLeft Palm z: " + GameObject.Find ("DebugMenu").GetComponent<PalmPosition>().left.z;
	}

	public void PauseMenu(int button)
	{
		switch (button) {
			case 0: //back to Main Menu
				Application.LoadLevel(1);
				break;
			case 1: //Calibrate
				Application.LoadLevel(0);
				break;
		}
	}

}
