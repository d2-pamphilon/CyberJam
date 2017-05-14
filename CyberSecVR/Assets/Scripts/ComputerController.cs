using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerController : MonoBehaviour {

    [SerializeField]
    GameObject UsbPort;
    [SerializeField]
    GameObject screen;
    //private GameObject USB;

    //void Start()
    //{

    //    USB = UsbPort.GetComponent<UsbGrabber>().usb;
    //}

    public void runProgram()
    {
        GetComponentInChildren<ComputerScreen.ComputerScreen>().m_virus = UsbPort.GetComponent<UsbGrabber>().usb.GetComponent<UsbProgram>().program;
        GetComponent<Virus.ParticleManager>().m_ProgVirus = UsbPort.GetComponent<UsbGrabber>().usb.GetComponent<UsbProgram>().program;
        UsbPort.GetComponent<UsbGrabber>().usb.GetComponent<UsbProgram>().play(screen);

        if (UsbPort.GetComponent<UsbGrabber>().usb.GetComponent<UsbProgram>().program==UsbProgram.Program.RansomVirus)
        {
            Destroy(UsbPort.GetComponent<UsbGrabber>().usb);

        }
        //UsbPort.GetComponent<UsbGrabber>().usb.GetComponent<Rigidbody>().AddForce()
    }

    public void exitProgram()
    {
        GetComponentInChildren<ComputerScreen.ComputerScreen>().m_virus = UsbProgram.Program.NONE;
    }
}
