using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace Virus
{

    public class ParticleManager : MonoBehaviour
    {
        public enum Attack
        {

            TOJAN,
            FISHING,
            ROUGE,
            DOS,
            RANSOM,
            KEYBOARD,
            WORMS,
            BRUTE_FORCE,
            BACK_DOOR,
            DNS,
            MIM,
            NULL
        }

        public Dictionary<Attack, GameObject> m_ParticleObjects;

        public Attack m_Type;
        public List<GameObject> m_Particles;

        public int m_SphereSize;

        public GameObject m_FishSpawn;

        private float m_Timer;
        private float m_Time;
   

        // Use this for initialization
        void Start()
        {
            m_Time = 0;
           // m_Particles = new List<GameObject>();
            m_ParticleObjects = new Dictionary<Attack, GameObject>();
            m_SphereSize = 10;

            DictionarySetUp();
        }

        public void DictionarySetUp()
        {
            m_ParticleObjects.Add(Attack.TOJAN, m_Particles[0]);
           /* m_ParticleObjects.Add(Attack.FISHING, m_Particles[1]);
            m_ParticleObjects.Add(Attack.ROUGE, m_Particles[2]);
            m_ParticleObjects.Add(Attack.DOS, m_Particles[3]);
            m_ParticleObjects.Add(Attack.RANSOM, m_Particles[4]);
            m_ParticleObjects.Add(Attack.KEYBOARD, m_Particles[5]);
            m_ParticleObjects.Add(Attack.WORMS, m_Particles[6]);
            m_ParticleObjects.Add(Attack.BRUTE_FORCE, m_Particles[7]);
            m_ParticleObjects.Add(Attack.BACK_DOOR, m_Particles[8]);
            m_ParticleObjects.Add(Attack.DNS, m_Particles[9]);
            m_ParticleObjects.Add(Attack.MIM, m_Particles[10]);*/
        }

        // Update is called once per frame
        void Update()
        {
            m_Timer += Time.deltaTime;
            if (m_Timer >= m_Time)
            {
                switch (m_Type)
                {
                    case Attack.NULL:
                        break;
                    case Attack.BACK_DOOR:
                        break;
                    case Attack.BRUTE_FORCE:
                        break;
                    case Attack.DNS:
                        break;
                    case Attack.DOS: //fire particles
                        break;
                    case Attack.FISHING: // All the fish
                        m_Time = 0.0f;
                        Vector3 t_pos = m_FishSpawn.transform.position;
                        t_pos.z +=  UnityEngine.Random.Range(-1.0f, 1.0f);
                        Instantiate(m_Particles[2], t_pos, Quaternion.identity);
                        break;
                    case Attack.KEYBOARD: // UI Text says no
                        break;
                    case Attack.MIM:
                        break;
                    case Attack.RANSOM: //Money
                        break;
                    case Attack.ROUGE: //Tia Fighter
                        break;
                    case Attack.TOJAN: //Arrow fired into the PC
                        m_Time = 1.5f;
                        Instantiate(m_Particles[0], RandLoc(), Quaternion.LookRotation(gameObject.transform.position, Vector3.up));
                        break;
                    case Attack.WORMS:
                        m_Time = 0.5f;
                        Instantiate(m_Particles[1], transform.position, Quaternion.identity);//Worms everywhere
                        break;

                }
                m_Timer = 0.0f;
            }
        }

        public Vector3 RandLoc()
        {
            Vector3 m_randLoc;

            m_randLoc = UnityEngine.Random.onUnitSphere * m_SphereSize;


            return m_randLoc;
        }


        private void OnCollisionEnter(Collision collision)
        {
            CombinableObject m_CObject = collision.gameObject.GetComponentInChildren<CombinableObject>();


            switch (m_CObject.type)
            {

                case Blender.CombinableObjectType.Banana:
                    break;
                case Blender.CombinableObjectType.Cube:
                    break;
                case Blender.CombinableObjectType.Sword:
                    break;

            }

        }

        private void OnCollisionExit(Collision collision)
        {
            m_Type = Attack.NULL;
        }

    }
}