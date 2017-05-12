using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

	[SerializeField]
	GameObject spawnable;
	[SerializeField]
	float timeBetweenSpawns;
	float timer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;

		if (timer >= timeBetweenSpawns)
		{
			GameObject go = Instantiate(spawnable);
			go.transform.position = transform.position;
			go.transform.rotation = Random.rotation;
			timer = 0.0f;
		}
	}
}
