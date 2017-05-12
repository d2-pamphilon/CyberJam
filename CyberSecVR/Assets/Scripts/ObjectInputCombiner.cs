using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInputCombiner : MonoBehaviour {

	void OnCollisionEnter (Collision other)
	{
		CombinableObject cObj = other.gameObject.GetComponentInChildren<CombinableObject>();
		if (cObj)
		{
			GetComponentInParent<Blender>().addObject(cObj.type);
			Destroy(other.gameObject);
		}
	}
}
