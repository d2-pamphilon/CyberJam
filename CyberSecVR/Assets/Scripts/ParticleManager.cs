using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace Virus
{

    public class ParticleManager : MonoBehaviour
    {      
        public List<GameObject> m_Particles;

        public GameObject constFire;
        public GameObject BurstFire;
        public UsbProgram.Program m_ProgVirus;

        private Transform t_target;
        public int m_SphereSize;
        // Use this for initialization
        void Start()
        {
            m_SphereSize = 2;

            foreach (Transform Child in transform)
            {
                if (Child.gameObject.tag == "DartTarget")
                {
                    t_target = Child;
                    break;
                }
            }
        
        }



        // Update is called once per frame
        void Update()
        {


            switch (m_ProgVirus)
            {
                case UsbProgram.Program.NONE:
                    break;
                //case UsbProgram.Program.BackDoor:
                //    break;
                //case UsbProgram.Program.BruteForce:
                //    break;
                //case UsbProgram.Program.DNS:
                //  break;
                case UsbProgram.Program.DDOS: //fire particles
                   
                    GameObject t_const = (GameObject)Instantiate(constFire, t_target.position, Quaternion.Euler(-90f, 0f, 0f));
                    GameObject t_burst = (GameObject)Instantiate(BurstFire, t_target.position, Quaternion.identity);

                    Destroy(t_burst, 5f);
                    Destroy(t_const, 10f);

                    break;
                case UsbProgram.Program.PhishingAttack: // All the fish
                    fishspawner();                // m_Time = 0.1f;


                    break;
                case UsbProgram.Program.KeyLogger: // UI Text says no
                    break;
                //case UsbProgram.Program.MIM:
                // break;
                case UsbProgram.Program.RansomVirus: //Money
                    Instantiate(m_Particles[3], transform.position, Quaternion.identity);
                    break;
                case UsbProgram.Program.RogueSoftware: //Tia Fighter
                    break;
                case UsbProgram.Program.TrojanHorse: //Arrow fired into the PC

                    DartSpawner();
                    break;
                case UsbProgram.Program.Worms:

                    Instantiate(m_Particles[1], transform.position, Quaternion.identity);//Worms everywhere
                    break;

            }
            m_ProgVirus = UsbProgram.Program.NONE;
        }


        public Vector3 RandLoc()
        {
            Vector3 m_randLoc;
            while(true)
            {
                m_randLoc = UnityEngine.Random.onUnitSphere * m_SphereSize;

                if (m_randLoc.x >= 0.0f && m_randLoc.x <= m_SphereSize)
                {
                    if (m_randLoc.y >= -m_SphereSize && m_randLoc.y <= 0.0f)
                    {
                        if (m_randLoc.z >= 0.0f && m_randLoc.z <= m_SphereSize)
                        {
                            print(m_randLoc);
                            return m_randLoc;
                        }
                    }
                }
            }
        }

        private void fishspawner()
        {
            for (int i = 0; i < 20; i++)
            {
                Vector3 t_pos = transform.position;
                t_pos.y = 10f;
                GameObject t_fishParticle;
                t_fishParticle = (GameObject)Instantiate(m_Particles[2], t_pos, Quaternion.identity);
                Destroy(t_fishParticle, 5f);
            }

        }

        private void DartSpawner()
        {
            for (int i = 0; i < 10; i++)
            {
                Vector3 m_Pos = RandLoc();
                GameObject m_Dart;

                m_Dart = (GameObject)Instantiate(m_Particles[0], m_Pos, Quaternion.identity);
                m_Dart.GetComponent<Trojen>().m_target = t_target;
                Destroy(m_Dart, 4f);
            }
        }

        public float RandFloat(float _min, float _max)
        {
            float m_val = UnityEngine.Random.Range(_min, _max);

            return m_val;

        }
}



}