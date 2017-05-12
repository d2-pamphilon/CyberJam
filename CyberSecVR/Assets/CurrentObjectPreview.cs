using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentObjectPreview : MonoBehaviour {

    public GameObject newObjWaypoint;
    GameObject previewObject;
    public SelectButton SpawnButton;
    [SerializeField]
    Material previewMat;
    int currentDisplayedObj = 0;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        if (!previewObject)
        {
           // DestroyImmediate(previewObject);
            previewObject = Instantiate(SpawnButton.currPrintable);
        }

        if (currentDisplayedObj != SpawnButton.currentNum)
        {
            if (previewObject)
            {
                DestroyImmediate(previewObject);
            }
            previewObject = Instantiate(SpawnButton.currPrintable);
            currentDisplayedObj = SpawnButton.currentNum;
        }

        if (previewObject)
        {
            previewObject.transform.position = newObjWaypoint.transform.position;
            previewObject.transform.Rotate(new Vector3(0.0f, 1.0f, 0.0f));
            previewObject.GetComponent<Renderer>().material = previewMat;
            previewObject.GetComponentInChildren<Renderer>().material = previewMat;
            Collider[] colliders = previewObject.GetComponents<Collider>();
            foreach (Collider coll in colliders)
            {
                coll.isTrigger = true;
            }
            Collider[] colliders2 = previewObject.GetComponentsInChildren<Collider>();
            foreach (Collider coll in colliders2)
            {
                coll.isTrigger = true;
            }
        }
    }
}
