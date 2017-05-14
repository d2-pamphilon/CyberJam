using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Virus
{
    public class Trojen : MonoBehaviour
    {
        public Transform m_target;
        private float m_speed;


        void Start()
        {
            //GameObject m_GM =  GameObject.FindGameObjectWithTag("DartTarget");
            //m_target = m_GM.transform;
            transform.LookAt(m_target);
            m_speed = 5f;
        }

        // Update is called once per frame
        void Update()
        {
            float m_step = m_speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, m_target.position, m_step);
            //Debug.DrawLine(transform.position, m_target.position, Color.black);
        }
    }
}
