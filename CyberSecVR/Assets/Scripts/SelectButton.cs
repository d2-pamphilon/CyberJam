using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NewtonVR;

public class SelectButton : MonoBehaviour {

	NVRButton Button;
    public SelectButton SpawnButton;

    public GameObject newObjWaypoint;

    public List<GameObject> Printables;
    public bool increaseList = true;
    public bool isPrintButton = false;
    public int currentNum = 0;
    public GameObject currPrintable;

    private void Start()
    {
        Button = GetComponent<NVRButton>();
    }


    private void Update()
    {
        if (isPrintButton)
        {
            if (Button.ButtonDown)
            {
                GameObject newObj = GameObject.Instantiate(currPrintable);
                newObj.transform.position = newObjWaypoint.transform.position;
            }
        }
        else
        {
            if (increaseList)
            {
                if (Button.ButtonDown)
                {
                    if (SpawnButton.currentNum >= Printables.Count)
                    {
                        SpawnButton.currentNum = 0;
                    }
                    else
                    {
                        SpawnButton.currentNum++;
                    }
                }
            }
            else if (!increaseList)
            {

                if (Button.ButtonDown)
                {
                    if (SpawnButton.currentNum <= 0)
                    {
                        SpawnButton.currentNum = Printables.Count;
                    }
                    else
                    {
                        SpawnButton.currentNum--;
                    }
                }
            }

            SpawnButton.currPrintable = Printables[SpawnButton.currentNum];
        }
    }
}
