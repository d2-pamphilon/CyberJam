using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Worm : MonoBehaviour
{
    private Vector3 direction;
    public float speed;

    [SerializeField]
    GameObject worm;

    float AvoidDistance = 10.0f;

    void Start()
    {
        direction = Vector3.forward;
        direction.x = Random.value - 0.5f;
        direction.z = Random.value - 0.5f;
    }
    void Update()
    {
        ////direction.Normalize();
        //GetComponent<Rigidbody>().velocity = direction.normalized * (speed) * Time.deltaTime;

        //transform.LookAt(transform.position + direction, Vector3.up);
        if (Vector3.Distance(GetComponent<NavMeshAgent>().destination, transform.position) < 2.0f)
        {
            GetComponent<NavMeshAgent>().destination = new Vector3(Random.Range(10.0f, -10.0f), 0.0f, Random.Range(10.0f, -10.0f));
        }
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

    //private void FlockWithBuddies()
    //{
    //    Vector3 align = Vector3.zero;
    //    Vector3 cohesion = Vector3.zero;
    //    Vector3 avoid = Vector3.zero;

    //    Worm[] mCurrentBuddies = GameObject.FindObjectsOfType<Worm>();

    //    for (int count = 0; count < mCurrentBuddies.Length; ++count)
    //    {
    //        Rigidbody body = mCurrentBuddies[count].GetComponent<Rigidbody>();
    //        align += body.velocity;
    //        cohesion += mCurrentBuddies[count].transform.position;
    //        if ((mCurrentBuddies[count].transform.position - transform.position).magnitude < 0.1f)
    //        {
    //            avoid += mCurrentBuddies[count].transform.position;
    //        }
    //    }

    //    align /= mCurrentBuddies.Length;
    //    cohesion /= mCurrentBuddies.Length;
    //    avoid /= mCurrentBuddies.Length;

    //    align.Normalize();
    //    cohesion = cohesion - transform.position;
    //    cohesion.Normalize();
    //    avoid = transform.position - avoid;
    //    avoid.Normalize();

    //    GetComponent<Rigidbody>().AddForce((align + cohesion + avoid) * speed * Time.deltaTime);
    //}
}
