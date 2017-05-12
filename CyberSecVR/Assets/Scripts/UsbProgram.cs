using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsbProgram : MonoBehaviour {

    public enum Program
    {
        NONE,
        PhishingAttack,
        TrojanHorse
    }

    public Program program;
}
