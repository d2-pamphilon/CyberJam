using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerController : MonoBehaviour {

    [SerializeField]
    GameObject UsbPort;
    [SerializeField]
    GameObject screen;

    void runProgram()
    {
        UsbPort.GetComponent<UsbGrabber>().usb.GetComponent<UsbProgram>().play(screen);
    }
}
