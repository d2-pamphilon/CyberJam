using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsbProgram : MonoBehaviour {

    public enum Program
    {
        NONE,
        PhishingAttack,
        TrojanHorse,
        RogueSoftware,
        DDOS,
        RansomVirus,
        KeyLogger,
        Worms,
        BackDoor,
        BruteForce,
        DNS,
        MIM,
        Garden
    }

    public Program program;
    public bool inSlot;
    void Start()
    {
        inSlot = false;
      
    }

    public void play(GameObject _screen)
    {

        return;
    }
}
