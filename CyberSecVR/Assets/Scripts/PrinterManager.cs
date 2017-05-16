using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NewtonVR;

public class PrinterManager : MonoBehaviour {

    [SerializeField]
    NVRButton SpawnButton;
    [SerializeField]
    NVRButton IncreaseButton;
    [SerializeField]
    NVRButton DecreaseButton;
    [SerializeField]
    List<GameObject> Printables;
    [SerializeField]
    GameObject newObjWaypoint;

    public int currentNum = 0;

    [SerializeField]
    Material previewMat;
    GameObject preview;

    void Update()
    {
        if (preview)
        {
            preview.transform.position = newObjWaypoint.transform.position;
            preview.transform.Rotate(new Vector3(0.0f, 1.0f, 0.0f));
            
        }

        if (SpawnButton.ButtonDown)
        {
            //Spawn current object
            GameObject newObj = GameObject.Instantiate(Printables[currentNum]);
            newObj.transform.position = newObjWaypoint.transform.position;
        }

        if (IncreaseButton.ButtonDown)
        {
            currentNum = currentNum < Printables.Count-1 ? currentNum+1 : 0;
            changePreview();
        }

        if (DecreaseButton.ButtonDown)
        {
            currentNum = currentNum > 0 ? currentNum - 1 : Printables.Count-1;
            changePreview();
        }
    }

    void changePreview()
    {
        if (preview)
        {
            DestroyImmediate(preview);
        }
        preview = Instantiate(Printables[currentNum]);
        Collider[] colliders = preview.GetComponents<Collider>();
        foreach (Collider coll in colliders)
        {
            coll.enabled = false;
        }
        Collider[] colliders2 = preview.GetComponentsInChildren<Collider>();
        foreach (Collider coll in colliders2)
        {
            coll.enabled = false;
        }

        Renderer[] renders = preview.GetComponents<Renderer>();
        foreach (Renderer rend in renders)
        {
            rend.material = previewMat;
        }
        Renderer[] renders2 = preview.GetComponentsInChildren<Renderer>();
        foreach (Renderer rend in renders2)
        {
            rend.material = previewMat;
        }
    }
}