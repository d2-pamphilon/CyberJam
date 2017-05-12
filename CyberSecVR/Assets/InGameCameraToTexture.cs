using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameCameraToTexture : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Renderer>().material.mainTexture = GetComponentInChildren<Camera>().targetTexture;
    }
}
