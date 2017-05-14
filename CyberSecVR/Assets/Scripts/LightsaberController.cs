using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NewtonVR;

public class LightsaberController : MonoBehaviour {

    [SerializeField]
    LineRenderer innerGlow;
    [SerializeField]
    LineRenderer outerGlow;

    [SerializeField]
    bool grabbed = false;
    [SerializeField]
    bool lightActive = false;
    [SerializeField]
    float activeSize = 0.4f;

	// Use this for initialization
	void Start () {
        innerGlow = GetComponent<LineRenderer>();
        outerGlow = transform.FindChild("centerBeam").GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update () {

        Vector3[] innerPositions = new Vector3[2];
        innerGlow.GetPositions(innerPositions);
        Vector3[] outerPositions = new Vector3[2];
        outerGlow.GetPositions(outerPositions);


        if (lightActive)
        {
            if (Vector3.Distance(innerPositions[0], innerPositions[1]) < activeSize)
            {
                Vector3 Direction = innerPositions[0] - innerPositions[1];
                //Direction.Normalize();
                //Direction *= 0.1f;
                innerPositions[1] -= Direction;
                innerGlow.SetPosition(1, innerPositions[1]);
            }

            if (Vector3.Distance(outerPositions[0], outerPositions[1]) < activeSize)
            {
                Vector3 Direction = outerPositions[0] - outerPositions[1];
                //Direction.Normalize();
                //Direction *= 0.1f;
                outerPositions[1] -= Direction;
                outerGlow.SetPosition(1, outerPositions[1]);
            }
        }
        else
        {
            if (Vector3.Distance(innerPositions[0], innerPositions[1]) > 0)
            {
                Vector3 Direction = innerPositions[0] - innerPositions[1];
                //Direction.Normalize();
                //Direction *= 0.1f;
                innerPositions[1] += Direction;
                innerGlow.SetPosition(1, innerPositions[1]);
            }

            if (Vector3.Distance(outerPositions[0], outerPositions[1]) > 0)
            {
                Vector3 Direction = outerPositions[0] - outerPositions[1];
                //Direction.Normalize();
                //Direction *= 0.1f;
                outerPositions[1] += Direction;
                outerGlow.SetPosition(1, outerPositions[1]);
            }
        }
	}

    public void OnGrabbed()
    {
        lightActive = true;
        grabbed = true;
    }

    public void OnReleased()
    {
        lightActive = false;
        grabbed = false;
    }

    public void OnUseButton()
    {
        lightActive = !lightActive;
    }
}
