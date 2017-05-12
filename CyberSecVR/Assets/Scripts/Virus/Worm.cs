using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Virus
{
    public class Worm : MonoBehaviour
    {

        public float m_Timer;
        public float m_TimerDestroy;

        public Rigidbody m_WormRB;
        

        // Use this for initialization
        void Start()
        {
            transform.rotation = Random.rotation;
            m_WormRB = GetComponent<Rigidbody>();

            m_TimerDestroy = 10.0f;
        }

        // Update is called once per frame
        void Update()
        {
            m_Timer += Time.deltaTime;
            if (m_Timer >= m_TimerDestroy)
            {
                ByeBye();
            }

            m_WormRB.AddForce(Random.insideUnitSphere*1);
        }

       public void ByeBye()
        {
            Destroy(gameObject);
        }
    }
}
