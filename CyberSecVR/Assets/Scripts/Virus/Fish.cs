using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Virus
{
    public class Fish : MonoBehaviour
    {

        private float m_Timer;
        public float m_TimerDestroy;

        public Rigidbody m_FishRB;


        // Use this for initialization
        void Start()
        {
            transform.rotation = Random.rotation;
            m_FishRB = GetComponent<Rigidbody>();

            m_TimerDestroy = 2.5f;
        }

        // Update is called once per frame
        void Update()
        {
            m_Timer += Time.deltaTime;
            if (m_Timer >= m_TimerDestroy)
            {
                ByeBye();
            }
        }

        public void ByeBye()
        {
            Destroy(gameObject);
        }
    }
}