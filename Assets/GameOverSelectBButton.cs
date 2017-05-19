using UnityEngine;
using System.Collections;

public class GameOverSelectBButton : MonoBehaviour {

	public void ReStart(){
		Application.LoadLevel (Application.loadedLevel);
	}
	public void BackMenu(){
		Application.LoadLevel ("Start");
	}
}
