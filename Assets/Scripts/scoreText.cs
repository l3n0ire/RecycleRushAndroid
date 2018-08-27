using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreText : MonoBehaviour {

	public Text highScoreText;
	// Use this for initialization
	void Start () {
		
		highScoreText.text = "Your Score: " + PlayerPrefs.GetInt ("score") 
			+ "\nHigh Score: " + PlayerPrefs.GetInt (PlayerPrefs.GetString("lastGameMode")+"HighScore");

	}
	

}
