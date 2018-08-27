using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicManager : MonoBehaviour {

	void Awake(){
		GameObject[] obj = GameObject.FindGameObjectsWithTag ("music");
		if (obj.Length > 1) {
			// destroys gameobject if there is more than one 
			Destroy (this.gameObject);

		}
		// dont destroy this game object when loading a new scene
		DontDestroyOnLoad(this.gameObject);
	}
}
