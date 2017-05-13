using UnityEngine;
using System.Collections;


public class PlayerController : MonoBehaviour {
	public float speed = 10.0F;
	public float rotationSpeed = 100.0F;
	void Start(){
		GetComponent<Animator> ().SetFloat ("Speed", 0f);
	}
	void Update() {
		float translation = Input.GetAxis("Vertical") * speed;
		float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
		translation *= Time.deltaTime;
		rotation *= Time.deltaTime;
		transform.Translate(0, 0, translation);
		transform.Rotate(0, rotation, 0);

		if (translation != 0) {
			//float dampTime = Mathf.Clamp(input.Vertical + 0.1f - Time.time, 0f, 0.1f);
			GetComponent<Animator> ().SetFloat ("Speed",1f,0.2f,Time.deltaTime);
		} else {
			GetComponent<Animator> ().SetFloat ("Speed",0f,0.5f,Time.deltaTime);
		}
	}
}