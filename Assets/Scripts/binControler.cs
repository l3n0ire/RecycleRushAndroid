using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class binControler : MonoBehaviour {

	public Camera cam;
	private float maxWidth;
	public Renderer rend;
	public Rigidbody2D rigidBody;
	// Use this for initialization
	void Start () {
		if (cam == null) {
			cam = Camera.main;
		}
		Vector3 upperCorner = new Vector3 (Screen.width, Screen.height, 0);
		Vector3 targetWidth = cam.ScreenToWorldPoint (upperCorner);
		rend = GetComponent <Renderer> ();
		rigidBody = GetComponent <Rigidbody2D> ();
		float binWidth = rend.bounds.extents.x;


		maxWidth = targetWidth.x-binWidth;

			

	}
	
	// Update is called once per frame
	void Update () {
		Vector3 rawPosition = cam.ScreenToWorldPoint (Input.mousePosition);
		Vector3 targetPosition = new Vector3 (rawPosition.x, -4f, 0.0f);
		float targetWidth = Mathf.Clamp (targetPosition.x, -maxWidth, maxWidth);
		targetPosition = new Vector3 (targetWidth, targetPosition.y, targetPosition.z);
		rigidBody.MovePosition(targetPosition);
	}
}
