using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ScientistController : MonoBehaviour
{

    [SerializeField]
    List<GameObject> waypoints;
    int currentWaypoint;
    private GameObject m_usbToGrab;
    [SerializeField]
    private bool m_seesUSB;
    private NavMeshAgent m_navMesh;
    [SerializeField]
    private bool m_parented;
    public float m_lookRadius;

    private GameObject t_hand;
    // Use this for initialization
    void Start()
    {
        m_seesUSB = false;
        m_parented = false;
        m_navMesh = GetComponent<NavMeshAgent>();
        t_hand = GameObject.FindGameObjectWithTag("rightHand");
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Animator>().SetFloat("Speed", GetComponent<Rigidbody>().velocity.magnitude);
        if (!m_parented)
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, m_lookRadius);

            foreach (Collider C in hitColliders)
            {
                if (C.gameObject.tag == "USB")
                {
                    m_usbToGrab = C.gameObject;
                    m_seesUSB = true;
                    break;
                }
            }


        }

        if (m_seesUSB)
        {
            m_navMesh.destination = m_usbToGrab.transform.position;
            float dist = Vector3.Distance(m_usbToGrab.transform.position, transform.position);
            if (dist <= 0.2f)
            {
                m_seesUSB = false;
                m_parented = true;

                m_usbToGrab.transform.position = t_hand.transform.position;
                m_usbToGrab.transform.rotation = Quaternion.Euler(0, 0, -90);
                m_usbToGrab.transform.localScale = new Vector3(0.1f,0.1f ,0.1f);
                m_usbToGrab.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;

            }
        }
        else
        {
            if (Vector3.Distance(transform.position, waypoints[currentWaypoint].transform.position) < 1.0f)
            {
                currentWaypoint = currentWaypoint < waypoints.Count - 1 ? currentWaypoint + 1 : 0;
            }
            m_navMesh.destination = waypoints[currentWaypoint].transform.position;

            if (m_parented)
            {
                m_usbToGrab.transform.position = t_hand.transform.position;

            }

        }



    }
}
