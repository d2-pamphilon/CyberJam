using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NewtonVR;

public class Stuck : MonoBehaviour {

    public StickyCollider coll;

    void Update()
    {
        if (GetComponent<NVRInteractableItem>())
        {
            if (GetComponent<NVRInteractableItem>().IsAttached)
            {
                coll.OnGrabbed();
            }
        }
    }

}
