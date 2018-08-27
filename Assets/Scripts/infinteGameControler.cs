using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class infinteGameControler : MonoBehaviour {

	public Camera cam;
	public GameObject []ball;
	public Renderer[] rend;
	private float maxWidth;

	public Text outOfLives;

	private int index;
	private float ballWidth;

	public int size;

	public AudioSource alarm;

	private bool isPlaying;

	private float time=0;
	private float speed=0.5f;
	private float threshHold=10f;
	private float increment=10f;

	// Use this for initialization
	void Start () {
		isPlaying = false;
		index = Random.Range(0,size);
		outOfLives.enabled=false;
		PlayerPrefs.SetInt ("lives", 3);
		PlayerPrefs.SetString ("lastGameMode", "infinite");

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
		time += Time.deltaTime;
		if (PlayerPrefs.GetString ("easterEgg") == "enabled") {
			speed = 0f;
		}
		else if (time > threshHold && speed>0.1) {
			speed-=0.05f;
			threshHold += increment;
		}
		if (PlayerPrefs.GetInt("lives") == 0) {

			outOfLives.enabled=true;
			if (!isPlaying) {
				alarm.Play ();
				isPlaying = true;
				PlayerPrefs.SetString ("easterEgg", "disabled");

			}
			Invoke ("Restart", 1.5f);
		}

	}
	void Restart(){

		if (PlayerPrefs.HasKey ("infiniteHighScore")) {
			if (PlayerPrefs.GetInt ("score") > PlayerPrefs.GetInt ("infiniteHighScore")) {
				PlayerPrefs.SetInt ("infiniteHighScore", PlayerPrefs.GetInt ("score"));
			}
		} else {
			PlayerPrefs.SetInt ("infiniteHighScore", PlayerPrefs.GetInt("score"));
		}
		SceneManager.LoadScene ("GameOver");


	}
	IEnumerator spawn()
	{
		while (PlayerPrefs.GetInt("lives")>0) {
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
