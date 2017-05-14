﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NewtonVR;

public class Blender : MonoBehaviour {

	public enum CombinableObjectType
	{
		NULL,
		Sword,
		Cube,
		Banana,
        Ball,
        Doll,
        Armour,
        Fish,
        TrophyHead,
        LightSaber,
        Knife,
        BoxingGloves,
        BlackHoodie,
        Money,
        Gold,
        PC,
        Needle,
        FullBucket,
        Keyboard,
        PianoKeyboard,
        WoodChip,
        Spider,
        Worm,
        TinyDoor,
        SpinalCord,
        Broom,
        KnightPieceChess,
        Horse
	}

    [SerializeField]
    NVRLever activationLever;

    [SerializeField]
    GameObject USBObject;

	[System.Serializable]
	public struct objectPairWithOutput
	{
		public List<CombinableObjectType> collectedObjects;
		public UsbProgram.Program output;
	}

	List<CombinableObjectType> collectedObjects;

	[SerializeField]
	List<objectPairWithOutput> outputs = new List<objectPairWithOutput>();

    // Use this for initialization
    void Start () {
        collectedObjects = new List<CombinableObjectType>();
	}
	
	// Update is called once per frame
	void Update () {
        if (activationLever.CurrentLeverPosition == NVRLever.LeverPosition.On
            && activationLever.LastLeverPosition != NVRLever.LeverPosition.On)
        {
            activate();
        }
	}

    public void activate()
    {
        GetComponentInChildren<ObjectInputCombiner>().activate();
        if (collectedObjects.Count >= 2)
        {
            GameObject newGO = canObjectsCombine();
            if (newGO)
            {
                newGO.transform.position = transform.FindChild("OutputPoint").transform.position;
            }
        }
        collectedObjects.Clear();
    }

	public void addObject(CombinableObjectType objType)
	{
        collectedObjects.Add(objType);
	}


	GameObject canObjectsCombine()
	{
		for (int i = 0; i < outputs.Count; i++)
		{
            int sameCount = 0;
            for (int j = 0; j < collectedObjects.Count; j++)
            {
                for (int k = 0; k < outputs[i].collectedObjects.Count; k++)
                {
                    if (outputs[i].collectedObjects[k] == collectedObjects[j])
                    {
                        sameCount++;
                    }
                }
            }
			if (sameCount == collectedObjects.Count)
			{
                print("USB");
                GameObject usb = Instantiate(USBObject);
                usb.GetComponent<UsbProgram>().program = outputs[i].output;
                return usb;
			}
		}
		return null;
	}
}
