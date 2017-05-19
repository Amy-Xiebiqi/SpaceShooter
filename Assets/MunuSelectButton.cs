using UnityEngine;
using System.Collections;

public class MunuSelectButton : MonoBehaviour {

	public void Easy(){
		Application.LoadLevel ("Main 1");
	}
	public void Hard(){
		Application.LoadLevel ("Main 2");
	}
}
