﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
public class AsteroidKeyboard : MonoBehaviour {
	
	protected GameObject text;
	public Mesh asteroidMesh;
	public Material asteroidMaterial;
	static public List <GameObject> characterList = new List<GameObject>();
	protected string alpha = "qwertyuiop[]asdfghjkl;'zxcvbnm,./";
	/*Index of Key and KeyPos*/
	static public int index = 0;
	static public List <int> Pos = new List<int>();
	// Use this for initialization
	void Start () {
		Pos.Add (0);
		Pos.Add (11);
		Pos.Add (23);
		Pos.Add (32);
		for (int i=1; i<34; i++){
			GameObject charObj;
			charObj = new GameObject ();
			charObj.name = alpha[i-1].ToString();
			charObj.AddComponent<MeshFilter> ();
			charObj.AddComponent<MeshRenderer> ();
			charObj.GetComponent<MeshFilter> ().mesh = asteroidMesh;
			charObj.GetComponent<MeshRenderer> ().material = asteroidMaterial;
			if(i<=12)
				charObj.transform.position = new Vector3 (-5.0f + i, 1.5f, 15f);
			else if(i<=23)
				charObj.transform.position = new Vector3 (-4.5f + i-12, 0.0f, 15f);
			else
				charObj.transform.position = new Vector3 (-4.0f + i-23, -1.5f, 15f);
			charObj.transform.localScale = new Vector3 (0.1f, 0.1f, 0.1f);
			Vector3 rotate=charObj.transform.localRotation.eulerAngles;
			rotate += new Vector3 (0.0f, 180.0f, 0.0f);
			charObj.transform.localRotation= Quaternion.Euler(rotate);
			text = new GameObject ();
			
			text.transform.parent=charObj.transform;
			//Adds components to text
			text.AddComponent<Canvas>();
			text.AddComponent<Text>();
			text.AddComponent<CanvasScaler> ();
			
			//Sets up components
			text.transform.localPosition = Vector3.zero;
			Font myFont = Resources.Load<Font> ("Neuton-Regular");
			text.GetComponent<Text> ().font = myFont;
			text.GetComponent<Text> ().horizontalOverflow = HorizontalWrapMode.Overflow;
			text.GetComponent<Text> ().verticalOverflow = VerticalWrapMode.Overflow;
			text.GetComponent<Text>().text=charObj.name;
			text.GetComponent<Text> ().fontSize = 3;
			text.GetComponent<CanvasScaler> ().dynamicPixelsPerUnit = 80;
			text.GetComponent<Text> ().alignment = TextAnchor.MiddleCenter;
			text.GetComponent<Text> ().name="Character Text";
			text.GetComponent<RectTransform> ().localPosition += new Vector3 (0.0f, 0.0f, 6.501f);
			rotate=text.GetComponent<RectTransform> ().localRotation.eulerAngles;
			text.GetComponent<RectTransform> ().localRotation=Quaternion.Euler(rotate);
			text.GetComponent<RectTransform> ().localScale=new Vector3(1,1,1);
			text.GetComponent<RectTransform> ().sizeDelta = new Vector2 (1.0f, 1.0f);
			
			charObj.transform.LookAt (Camera.main.transform.position);
			
			characterList.Add(charObj);
			
		}
	}
	static public void Exit(){
		characterList.Clear();
		Pos.Clear ();
		index = 0;
	}
}
