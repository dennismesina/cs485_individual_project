using UnityEngine;
using System.Collections;

public class onClickButtons : MonoBehaviour {

	public void onClickButton1(){
		Application.LoadLevel("MiniGame");
	}

	public void onClickButton2(){
		Application.LoadLevel("Assignment1_scene2");
	}

	public void onClickButton3(){
		Application.LoadLevel("Menu");
	}
}