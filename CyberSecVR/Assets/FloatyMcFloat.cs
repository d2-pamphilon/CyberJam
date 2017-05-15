using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NewtonVR;
using System;
using System.Linq;

public class FloatyMcFloat : MonoBehaviour {

    GameObject leftHand;
    private Vector3/*[]*/ LastPositionsLeft;
    GameObject rightHand;
    private float/*[]*/ LastDeltas;
    private Vector3/*[]*/ LastPositionsRight;

    int EstimationSampleIndex = 0;

    // Use this for initialization
    void Start () {
        leftHand = transform.FindChild("LeftHand").gameObject;
        rightHand = transform.FindChild("RightHand").gameObject;
        //LastDeltas = new float[120];
        //LastPositionsLeft = new Vector3[120];
        //LastPositionsRight = new Vector3[120];
    }

    Vector3 getHandVelocityLeft()
    {
        Vector3 vel =  LastPositionsLeft - leftHand.transform.localPosition;
        vel.x = -vel.x;
        vel.z = -vel.z;
        return vel;
        //float delta = LastDeltas.Sum();
        //Vector3 distance = Vector3.zero;

        //for (int index = 0; index < LastPositionsLeft.Length - 1; index++)
        //{
        //    Vector3 diff = LastPositionsLeft[index + 1] - LastPositionsLeft[index];
        //    distance += diff;
        //}

        //return distance / delta;

    }

    Vector3 getHandVelocityRight()
    {
        Vector3 vel = LastPositionsRight - rightHand.transform.localPosition;
        vel.x = -vel.x;
        vel.z = -vel.z;
        return vel;
        //float delta = LastDeltas.Sum();
        //Vector3 distance = Vector3.zero;

        //for (int index = 0; index < LastPositionsRight.Length - 1; index++)
        //{
        //    Vector3 diff = LastPositionsRight[index + 1] - LastPositionsRight[index];
        //    distance += diff;
        //}

        //return distance / delta;

    }

    void FixedUpdate()
    {

        LastPositionsLeft = leftHand.transform.localPosition;
        LastPositionsRight = rightHand.transform.localPosition;
        //LastPositionsLeft[EstimationSampleIndex] = leftHand.transform.localPosition;
        //LastPositionsRight[EstimationSampleIndex] = rightHand.transform.localPosition;
        //LastDeltas[EstimationSampleIndex] = Time.deltaTime;
        //EstimationSampleIndex++;

        //if (EstimationSampleIndex >= LastPositionsLeft.Length)
        //    EstimationSampleIndex = 0;
    }

    // Update is called once per frame
    void Update () {

        Vector3 vel = Vector3.zero;
        if (leftHand.GetComponent<NVRHand>().UseButtonPressed)
        {
            GetComponent<Rigidbody>().velocity += getHandVelocityLeft();
        }
        if (rightHand.GetComponent<NVRHand>().UseButtonPressed)
        {
            GetComponent<Rigidbody>().velocity += getHandVelocityRight();
        }

        //vel.Normalize();
        //vel *= 100.0f;

        //transform.position += /*Vector3.Lerp(transform.position, transform.position +*/ vel/*, Time.deltaTime)*/;
    }
}
