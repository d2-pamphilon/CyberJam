using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInputCombiner : MonoBehaviour {

	void OnTriggerEnter (Collider other)
	{
		CombinableObject cObj = other.gameObject.GetComponent<CombinableObject>();
		if (cObj)
		{
			GetComponentInParent<Blender>().addObject(cObj.type);
			Destroy(other.gameObject);
		}
	}
}
