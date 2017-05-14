using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsbGrabber : MonoBehaviour
{

    public GameObject usb;
    public bool free = true;


    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<UsbProgram>())
        {
            usb = other.gameObject;
            other.gameObject.transform.position = transform.FindChild("USB WAYPOINT").transform.position;
            other.gameObject.transform.rotation = transform.FindChild("USB WAYPOINT").transform.rotation;

            GetComponentInParent<ComputerController>().runProgram();

            other.GetComponent<Rigidbody>().velocity = Vector3.zero;
            other.GetComponent<UsbProgram>().inSlot = true;
            free = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<UsbProgram>())
        {
            other.gameObject.GetComponent<UsbProgram>().inSlot = false;
            free = true;
            GetComponentInParent<ComputerController>().exitProgram();
            GetComponentInParent<Virus.ParticleManager>().stopFire();
        }

    }

}
