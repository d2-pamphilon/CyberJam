using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsbGrabber : MonoBehaviour {

    public GameObject usb;


    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<UsbProgram>())
        {
            usb = other.gameObject;
            other.gameObject.transform.position = transform.FindChild("USB WAYPOINT").transform.position;
            other.gameObject.transform.rotation = transform.FindChild("USB WAYPOINT").transform.rotation;

            other.GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }
}
