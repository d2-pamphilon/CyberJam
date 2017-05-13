using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyCollider : MonoBehaviour {

    private bool stuck;

    void Update()
    {

    }

    void OnCollisionEnter (Collision col)
    {
        stuck = true;
        GetComponent<Rigidbody>().useGravity = false;
        //GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
    void OnCollisionStay(Collision col)
    {

        stuck = true;
    }

    void OnCollisionExit(Collision col)
    {
        stuck = false;
        GetComponent<Rigidbody>().useGravity = true;

    }
}
