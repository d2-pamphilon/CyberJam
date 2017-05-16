using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Worm : MonoBehaviour
{
    private Vector3 direction;
    public float speed;

    [SerializeField]
    GameObject worm;

    void Start()
    {
        direction = Vector3.forward;
    }
    void Update()
    {
        direction.x += 0.01f;
        direction.z += 0.01f;
        transform.position += direction * (speed/100) * Time.deltaTime;
    }

    void OnCollisionEnter(Collision Col)
    {
        if(Col.gameObject.GetComponent<NewtonVR.NVRInteractableItem>()
            && Col.gameObject.GetComponent<Worm>() == null)
        {
            GameObject  newWorm = Instantiate(worm, Col.gameObject.transform.position, Quaternion.identity);
            Destroy(Col.gameObject);
        }
            


    }


}
