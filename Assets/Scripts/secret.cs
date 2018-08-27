using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class secret : MonoBehaviour {

	public void restartScene()
	{
		Invoke ("load", 0.3f);
	}
	public void load ()
	{
		SceneManager.LoadScene ("secret");
	}
}
