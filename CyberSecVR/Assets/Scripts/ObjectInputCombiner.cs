using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInputCombiner : MonoBehaviour {

    List<GameObject> inputObjects = new List<GameObject>();


    void OnTriggerStay(Collider other)
    {
        bool found = false;
        foreach (GameObject go in inputObjects)
        {
            if (go == other.gameObject)
            {
                found = true;
            }
        }

        if (!found)
        {
            CombinableObject cObj = other.gameObject.GetComponentInChildren<CombinableObject>();
            CombinableObject cObj2 = other.gameObject.GetComponent<CombinableObject>();
            CombinableObject cObj3 = other.gameObject.GetComponentInParent<CombinableObject>();
            if (cObj)
            {
                inputObjects.Add(other.gameObject);
            }
            else if (cObj2)
            {
                inputObjects.Add(other.gameObject);
            }
            else if (cObj3)
            {
                inputObjects.Add(other.gameObject);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        CombinableObject cObj = other.gameObject.GetComponentInChildren<CombinableObject>();
        CombinableObject cObj2 = other.gameObject.GetComponent<CombinableObject>();
        CombinableObject cObj3 = other.gameObject.GetComponentInParent<CombinableObject>();
        if (cObj)
        {
            inputObjects.Remove(other.gameObject);
        }
        else if (cObj2)
        {
            inputObjects.Remove(other.gameObject);
        }
        else if (cObj3)
        {
            inputObjects.Remove(other.gameObject);
        }
    }


    public void activate()
    {
        foreach (GameObject go in inputObjects)
        {
            CombinableObject cObj = go.gameObject.GetComponentInChildren<CombinableObject>();
            CombinableObject cObj2 = go.gameObject.GetComponent<CombinableObject>();
            CombinableObject cObj3 = go.gameObject.GetComponentInParent<CombinableObject>();

            if (cObj)
            {
                GetComponentInParent<Blender>().addObject(cObj.type);
            }
            else if (cObj2)
            {
                GetComponentInParent<Blender>().addObject(cObj2.type);
            }
            else if (cObj3)
            {
                GetComponentInParent<Blender>().addObject(cObj3.type);
            }
            Destroy(go);
        }
        inputObjects.Clear();
    }
}
