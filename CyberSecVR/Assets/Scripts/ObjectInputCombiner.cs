using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInputCombiner : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        CombinableObject cObj = other.gameObject.GetComponentInChildren<CombinableObject>();
        CombinableObject cObj2 = other.gameObject.GetComponent<CombinableObject>();
        CombinableObject cObj3 = other.gameObject.GetComponentInParent<CombinableObject>();
        if (cObj)
        {
            GetComponentInParent<Blender>().addObject(cObj.type);
            Destroy(other.gameObject);
        }
        else if (cObj2)
        {
            GetComponentInParent<Blender>().addObject(cObj2.type);
            Destroy(other.gameObject);
        }
        else if (cObj3)
        {
            GetComponentInParent<Blender>().addObject(cObj3.type);
            Destroy(other.gameObject);
        }
    }
}
