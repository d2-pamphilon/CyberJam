using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NewtonVR;

public class LightsaberController : MonoBehaviour {

    public void OnGrabbed()
    {
        GetComponent<lightsaber>().on = true;
        transform.FindChild("centerBeam").GetComponent<lightsaber>().on = true;
    }

    public void OnReleased()
    {
        GetComponent<lightsaber>().on = false;
        transform.FindChild("centerBeam").GetComponent<lightsaber>().on = false;
    }

    public void OnUseButton()
    {
        GetComponent<lightsaber>().on = !GetComponent<lightsaber>().on;
        transform.FindChild("centerBeam").GetComponent<lightsaber>().on = GetComponent<lightsaber>().on;
    }
}
