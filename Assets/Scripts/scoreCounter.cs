using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class scoreCounter : MonoBehaviour {

	public Text scoreText;
	public Text pointText;
	public int bottleValue;
	private int score;

	public GameObject[] hearts;
	private int heartIndex;

	public GameObject plusAudio;
	public GameObject minusAudio;

	public AudioSource plusOne;
	public AudioSource minusOne;


	// Use this for initialization
	void Start () {
		heartIndex = 0;
		score = 0;
		UpdateScore ();
		pointText.enabled = false;

		plusOne = plusAudio.GetComponent<AudioSource> ();
		minusOne = minusAudio.GetComponent<AudioSource> ();


	}
	void OnTriggerEnter2D(Collider2D col){
		if((PlayerPrefs.GetString("lastGameMode")=="infinite" && PlayerPrefs.GetInt("lives")>0)
			|| PlayerPrefs.GetString("lastGameMode")=="countDown" && PlayerPrefs.GetInt("timeLeft")>0){
			if (col.gameObject.name == "recycleable") {
				score += bottleValue;
				pointText.text = "+" + bottleValue;
				pointText.color = Color.blue;
				pointText.enabled = true;
				plusOne.Play();

				Invoke ("Disappear", 0.3f);

			} else {
				score -= bottleValue;
				pointText.text = "-" + bottleValue;
				if (PlayerPrefs.GetString ("lastGameMode") == "infinite") {
					PlayerPrefs.SetInt ("lives", PlayerPrefs.GetInt ("lives") - 1);
					Destroy (hearts [heartIndex].gameObject);
					if (heartIndex < 2) {
						heartIndex++;
					}
				}
				pointText.color = Color.red;
				pointText.enabled = true;
				minusOne.Play();
				Invoke ("Disappear", 0.3f);

			}

		}
		UpdateScore ();
	}
	void Disappear(){
		pointText.enabled = false;

	}
	void UpdateScore(){
		scoreText.text = "Score:\n" + score;
		PlayerPrefs.SetInt ("score", score);

	}


}
