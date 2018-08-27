using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rating : MonoBehaviour {

	public Text text;

	void Start(){
		int score = PlayerPrefs.GetInt ("score");
		if (PlayerPrefs.GetString ("lastGameMode") == "infinite") {

			if (score <= 20) {
				text.text = "You are a Recycling Newbie!";
			} else if (score > 20 && score <= 50) {
				text.text = "You are an Average Recycler!";
			} else if (score > 50 && score <= 75) {
				text.text = "You are a Recycling Champ!";
			} else if (score > 75 && score < 100) {
				text.text = "You are the King of Recycling!";
			} else if (score >= 100) {
				text.text = "You are a Recycling GOD!";
			}
		} else if (PlayerPrefs.GetString ("lastGameMode") == "countDown") {
			if (score <= 10) {
				text.text = "You are a Recycling Newbie!";
			} else if (score > 10 && score <= 20) {
				text.text = "You are an Average Recycler!";
			} else if (score > 20 && score <= 30) {
				text.text = "You are a Recycling Champ!";
			} else if (score > 30 && score < 35) {
				text.text = "You are the King of Recycling!";
			} else if (score >= 35) {
				text.text = "You are a Recycling GOD!";
			}
		}
	}
}
