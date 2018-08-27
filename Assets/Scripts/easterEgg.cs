using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class easterEgg : MonoBehaviour {

	public Text code;
	public Text error;
	public GameObject button;
	public GameObject enterButton;
	public GameObject input;

	void Start(){
		error.enabled = false;
		button.SetActive(false);
	}
	public void secretly(){
		if (code.text == "impossible") {
			PlayerPrefs.SetString ("easterEgg", "enabled");
			SceneManager.LoadScene ("infinite");
		} else {
			error.enabled = true;
			enterButton.SetActive(false);
			button.SetActive(true);
			input.SetActive(false);
		}
	}
}
