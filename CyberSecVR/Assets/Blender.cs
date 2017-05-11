using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blender : MonoBehaviour {

	public enum CombinableObjectType
	{
		Sword,
		Cube,
		Banana
	}

	[System.Serializable]
	public struct objectPairWithOutput
	{
		public List<CombinableObjectType> collectedObjects;
		public GameObject output;
	}

	List<CombinableObjectType> collectedObjects;

	[SerializeField]
	List<objectPairWithOutput> outputs;

	//public int hello;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void addObject(CombinableObjectType objType)
	{
		collectedObjects.Add(objType);
		if (collectedObjects.Count >= 2)
		{
			GameObject newGO = canObjectsCombine();
			if (newGO)
			{
				GameObject instance = Instantiate(newGO);
				instance.transform.position = transform.FindChild("Output").transform.position;
				collectedObjects.Clear();
			}
		}
	}


	GameObject canObjectsCombine()
	{
		for (int i = 0; i < outputs.Count; i++)
		{
			if (outputs[i].collectedObjects == collectedObjects)
			{
				return outputs[i].output;
			}
		}
		return null;
	}
}
