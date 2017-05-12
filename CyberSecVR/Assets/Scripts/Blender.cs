using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blender : MonoBehaviour {

	public enum CombinableObjectType
	{
		NULL,
		Sword,
		Cube,
		Banana,
        Ball,
        Doll,
        Armour,
        Fish,
        TrophyHead,
        LightSaber,
        Knife,
        BoxingGloves,
        BlackHoodie,
        Money,
        PC,
        Needle,
        FullBucket,
        Keyboard,
        PianoKeyboard,
        WoodChip,
        Spider,
        Worm,
        TinyDoor,
        SpinalCord,
        Broom,
        KnightPieceChess
	}

	[System.Serializable]
	public struct objectPairWithOutput
	{
		public List<CombinableObjectType> collectedObjects;
		public GameObject output;
	}

	List<CombinableObjectType> collectedObjects;

	[SerializeField]
	List<objectPairWithOutput> outputs = new List<objectPairWithOutput>();

    //public int hello;

    // Use this for initialization
    void Start () {
        collectedObjects = new List<CombinableObjectType>();
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
				instance.transform.position = transform.FindChild("OutputPoint").transform.position;
				collectedObjects.Clear();
			}
		}
	}


	GameObject canObjectsCombine()
	{
		for (int i = 0; i < outputs.Count; i++)
		{
            int sameCount = 0;
            for (int j = 0; j < collectedObjects.Count; j++)
            {
                for (int k = 0; k < outputs[i].collectedObjects.Count; k++)
                {
                    if (outputs[i].collectedObjects[k] == collectedObjects[j])
                    {
                        sameCount++;
                    }
                }
            }
			if (sameCount == collectedObjects.Count)
			{
				return outputs[i].output;
			}
		}
		return null;
	}
}
