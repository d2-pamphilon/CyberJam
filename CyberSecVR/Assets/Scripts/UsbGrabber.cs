using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsbGrabber : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<UsbProgram>())
        {
            other.gameObject.transform.position = transform.FindChild("USB WAYPOINT").transform.position;
            other.gameObject.transform.rotation = transform.FindChild("USB WAYPOINT").transform.rotation;
        }

    }
}
