using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Virus
{

    public class Trojen : MonoBehaviour
    {
        public float m_Timer;
        public float m_TimeStart;
        public float m_TimerDestroy;
        public bool m_MoveArrow;

        public Rigidbody m_ArrowRb;
        //public GameObject m_Target;
        // Use this for initialization
        void Start()
        {
            m_TimeStart = Random.Range(2, 5);
            m_TimerDestroy = 10.0f;
            m_Timer = 0.0f;

            m_MoveArrow = false;
           // gameObject.transform.LookAt(m_Target.transform);

            m_ArrowRb = GetComponent<Rigidbody>();
            m_ArrowRb.useGravity = false;
        }

        // Update is called once per frame
        void Update()
        {
            m_Timer += Time.deltaTime;

            if (m_Timer >= m_TimeStart)
            {
                m_MoveArrow = true;
            }

            if (m_MoveArrow)
            {
                print("Forward");
                //move arrow with add force
                m_ArrowRb.AddForce(Vector3.forward);
            }

            if (m_Timer >= m_TimerDestroy)
            {
                ByeBye();
            }
        }

        public void ByeBye()
        {
            Destroy(gameObject);
        }

        private void OnCollisionEnter(Collision collision)
        {
            m_ArrowRb.velocity = new Vector3(0, 0, 0);
            m_MoveArrow = false;
        }

        //timer
        //add force
        //deletion
    }
}
