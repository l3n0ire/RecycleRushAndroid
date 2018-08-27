using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class gameControler : MonoBehaviour {

	public Camera cam;
	public GameObject []ball;
	public Renderer[] rend;
	private float maxWidth;
	public float timeLeft;

	public Text timerText;
	public Text timesUp;

	private int index;
	private float ballWidth;

	public int size;

	public AudioSource alarm;

	private bool isPlaying;

	private float time=0;
	private float speed=0.5f;
	private float threshHold=20f;
	private float increment=10f;

	// Use this for initialization
	void Start () {
		isPlaying = false;
		index = Random.Range(0,size);
		timesUp.enabled=false;
		PlayerPrefs.SetString ("lastGameMode", "countDown");
		PlayerPrefs.SetInt ("timeLeft", 1);

		if (cam == null) {
			cam = Camera.main;
		}
		Vector3 upperCorner = new Vector3 (Screen.width, Screen.height, 0);
		Vector3 targetWidth = cam.ScreenToWorldPoint (upperCorner);



		 ballWidth = rend[index].bounds.extents.x;


		maxWidth = targetWidth.x-ballWidth;

		StartCoroutine (spawn ());

	}
	void FixedUpdate ()
	{
		if (timeLeft >= 0) {
			timeLeft -= Time.deltaTime;
			timerText.text = "Time Left:\n" + Mathf.RoundToInt (timeLeft);
			if (timeLeft < threshHold) {
				speed -= 0.15f;
				threshHold -= increment;
			}

		} else {
			PlayerPrefs.SetInt ("timeLeft", 0);
			timesUp.enabled=true;

			if (!isPlaying) {
				alarm.Play ();
				isPlaying = true;
			}
			Invoke ("Restart", 2);
		}

	}
	void Restart(){

		if (PlayerPrefs.HasKey ("countDownHighScore")) {
			if (PlayerPrefs.GetInt ("score") > PlayerPrefs.GetInt ("countDownHighScore")) {
				PlayerPrefs.SetInt ("countDownHighScore", PlayerPrefs.GetInt ("score"));
			}
		} else {
			PlayerPrefs.SetInt ("countDownHighScore", PlayerPrefs.GetInt("score"));
		}
		SceneManager.LoadScene ("GameOver");


	}
	IEnumerator spawn()
	{
		while (timeLeft>2) {
			Vector3 spawnPosition = new Vector3 (
				                       Random.Range (-maxWidth, maxWidth), 
				                       10f,
				                       0.0f);
		
			GameObject ob = Instantiate (ball[index], spawnPosition, transform.rotation);
			if (index % 2 == 0 || index ==0) {
				ob.name = "recycleable";
			} else {
				ob.name = "notRecycleable";
			}
				
			index = Random.Range(0,size);
			ballWidth = rend[index].bounds.extents.x;
			yield return new WaitForSeconds(Random.Range(speed,speed+0.1f));

		}
	}
}
