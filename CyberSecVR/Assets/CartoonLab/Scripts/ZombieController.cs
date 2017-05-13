using UnityEngine;
using System.Collections;

public class ZombieController : MonoBehaviour {
	private string _tag;
	private float move;
	private bool up;
	// Use this for initialization
	void Start () {
		move = 0.001f;
		up = true;
		_tag = gameObject.tag;
		if (_tag == "Brainy") {
			GetComponent<Animator> ().SetFloat ("Blend", 0.18f);
		}
		if (_tag == "Burnt") {
			GetComponent<Animator> ().SetFloat ("Speed", 0.1f);
		}
		if (_tag == "Electro") {
			GetComponent<Animator> ().SetFloat ("Blend", 1f);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
		if (_tag == "Brainy") {
			if (up) {				
				transform.Translate (0, 0.0005f, 0);
				move += 0.0005f;
				if (move > 0.05f) {
					up = false;
				}
			}
			else {
				transform.Translate (0, -0.0005f, 0);
				move -= 0.0005f;
					if (move < -0.05f) {
						up = true;
					}
			}
				
		}
	}
}