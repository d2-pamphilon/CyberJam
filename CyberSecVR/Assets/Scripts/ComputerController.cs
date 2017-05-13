using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerController : MonoBehaviour {

    [SerializeField]
    GameObject UsbPort;
    [SerializeField]
    GameObject screen;

    public void runProgram()
    {
        GetComponent<Virus.ParticleManager>().m_ProgVirus = UsbPort.GetComponent<UsbGrabber>().usb.GetComponent<UsbProgram>().program;
        UsbPort.GetComponent<UsbGrabber>().usb.GetComponent<UsbProgram>().play(screen);
    }
}
