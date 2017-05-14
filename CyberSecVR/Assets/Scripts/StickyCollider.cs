using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyCollider : MonoBehaviour {

    void Update()
    {

    }

    public void OnGrabbed()
    {
        FixedJoint[] joints = GetComponents<FixedJoint>();
        foreach (var joint in joints)
        {
            if (joint.connectedBody)
            {
                if (joint.connectedBody.gameObject.GetComponent<Stuck>())
                {
                    DestroyImmediate(joint.connectedBody.gameObject.GetComponent<Stuck>());
                }
            }
            DestroyImmediate(joint);
        }
    }

    void OnCollisionEnter (Collision col)
    {
        var joint = gameObject.AddComponent<FixedJoint>();
        joint.connectedBody = col.rigidbody;
        joint.connectedBody.gameObject.AddComponent<Stuck>();
        joint.connectedBody.gameObject.GetComponent<Stuck>().coll = this;
    }
}
