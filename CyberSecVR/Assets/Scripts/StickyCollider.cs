using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyCollider : MonoBehaviour {

    public void OnGrabbed()
    {
        FixedJoint[] joints = GetComponents<FixedJoint>();
        foreach (var joint in joints)
        {
            DestroyImmediate(joint);
        }
    }

    void OnCollisionEnter (Collision col)
    {
        var joint = gameObject.AddComponent<FixedJoint>();
        joint.connectedBody = col.rigidbody;
    }
}
