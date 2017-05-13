using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinScript : MonoBehaviour {

	void OnTriggerStay(Collider col)
	{
        if (col.gameObject.GetComponent<CombinableObject>())
        {
            Destroy(col.gameObject);
        }
        else if (col.gameObject.GetComponentInChildren<CombinableObject>())
        {
            Destroy(col.gameObject);
        }
        else if (col.gameObject.GetComponentInParent<CombinableObject>())
        {
            Destroy(col.gameObject);
        }
    }
}
