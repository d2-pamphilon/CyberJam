using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Audio;

public class ScientistController : MonoBehaviour
{

    enum state
    {
        partoling,
        gettingUsb,
        seekingPC
    }

    public float usbPlaceDist;
    [SerializeField]
    List<GameObject> waypoints;
    int currentWaypoint;
    private GameObject m_usbToGrab;
    //[SerializeField]
    //private bool m_seesUSB;
    private NavMeshAgent m_navMesh;
    [SerializeField]
    // private bool m_parented;
    public float m_lookRadius;
    
    public AudioClip[] pickupSounds;
    public AudioClip[] activateSounds;

    private GameObject t_hand;

    public GameObject[] usbSlots;
    [SerializeField]
    private state movmentState;
    private bool foundslot;
    public float pickUpDistance;

    private Transform usbWaypoint;
    // Use this for initialization
    void Start()
    {
        foundslot = false;
        movmentState = state.partoling;
        // m_seesUSB = false;
        //  m_parented = false;

        m_navMesh = GetComponent<NavMeshAgent>();

        foreach (Transform Child in transform)
        {
            if (Child.gameObject.tag == "Head")
            {
                t_hand = Child.gameObject;
                break;
            }
        }
       
    }

    // Update is called once per frame
    void Update()
    {


        GetComponent<Animator>().SetFloat("Speed", GetComponent<Rigidbody>().velocity.magnitude);

        switch (movmentState)
        {
            case state.partoling:
                if (Vector3.Distance(transform.position, waypoints[currentWaypoint].transform.position) < 1.0f)
                {
                    currentWaypoint = currentWaypoint < waypoints.Count - 1 ? currentWaypoint + 1 : 0;
                }
                m_navMesh.destination = waypoints[currentWaypoint].transform.position;

                Collider[] hitColliders = Physics.OverlapSphere(transform.position, m_lookRadius);

                foreach (Collider C in hitColliders)
                {
                    if (C.gameObject.tag == "USB" && C.gameObject.GetComponent<UsbProgram>().inSlot == false)
                    {

                        m_usbToGrab = C.gameObject;
                        movmentState = state.gettingUsb;
                        break;
                    }
                }
                
                for(int i=0;i<hitColliders.Length;i++)
                {
                    hitColliders[i] = null;

                }
        break;
            case state.gettingUsb:

                m_navMesh.destination = m_usbToGrab.transform.position;

                float dist = Vector3.Distance(m_usbToGrab.transform.position, transform.position);

                if (dist <= pickUpDistance)
                {
                    // m_seesUSB = false;
                    //m_parented = true;

                    m_usbToGrab.transform.position = t_hand.transform.position;
                    m_usbToGrab.transform.rotation = Quaternion.Euler(0, 0, -90);
                    m_usbToGrab.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                    m_usbToGrab.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
                    AudioSource.PlayClipAtPoint(pickupSounds[Random.Range(0, pickupSounds.Length)], transform.position);
                    movmentState = state.seekingPC;
                    foundslot = false;
                }

                break;
            case state.seekingPC:
                if (!foundslot)
                {
                    foreach (GameObject G in usbSlots)
                    {
                        if (G.gameObject.GetComponent<UsbGrabber>().free == true)
                        {
                            usbWaypoint = G.gameObject.transform;
                            m_usbToGrab.GetComponent<UsbProgram>().inSlot = true;
                            
                            foundslot = true;
                            break;
                        }
                    }
                }

                m_navMesh.destination = usbWaypoint.position;
                m_usbToGrab.transform.position = t_hand.transform.position;
                float distance = Vector3.Distance(usbWaypoint.position, transform.position);

                if (distance <= usbPlaceDist)
                {
                    m_usbToGrab.transform.localScale = new Vector3(0.023f, 0.023f, 0.023f);
                    m_usbToGrab.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                    m_usbToGrab.transform.position = usbWaypoint.position;// += new Vector3(0f, 0.1f, 0f);
                    AudioSource.PlayClipAtPoint(activateSounds[Random.Range(0, activateSounds.Length)], transform.position);
                    movmentState = state.partoling;
                }
                break;

        }
    }




}
