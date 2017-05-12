using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BinScript : MonoBehaviour {

	void OnCollisionEnter(Collision col)
	{
        if (col.gameObject.GetComponent<CombinableObject>())
        {
            Destroy(col.gameObject);
        }
	}
}
