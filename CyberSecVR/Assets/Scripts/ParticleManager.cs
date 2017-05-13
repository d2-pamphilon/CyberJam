using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace Virus
{

    public class ParticleManager : MonoBehaviour
    {
        /*public enum Attack
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
        }*/

        // public Dictionary<Attack, GameObject> m_ParticleObjects;

        //public Attack m_Type;
        public List<GameObject> m_Particles;

        public int m_SphereSize;

        // public GameObject m_FishSpawn;
        [SerializeField]
        ComputerController m_comCon;
        public UsbProgram m_program;
        public UsbProgram.Program m_ProgVirus;
        private float m_Timer;
        private float m_Time;
        private float m_TimerDuration;

        private int fishCounter = 1;


        // Use this for initialization
        void Start()
        {

            m_Time = 0;
            // m_Particles = new List<GameObject>();
            //  m_ParticleObjects = new Dictionary<Attack, GameObject>();
            m_SphereSize = 10;

            m_comCon = GetComponent<ComputerController>();
            m_program = m_comCon.GetComponent<UsbProgram>();

            //   m_ProgVirus = m_program.program;
        }

        /*  public void DictionarySetUp()
          {
              m_ParticleObjects.Add(Attack.TOJAN, m_Particles[0]);
              m_ParticleObjects.Add(Attack.FISHING, m_Particles[1]);
              m_ParticleObjects.Add(Attack.ROUGE, m_Particles[2]);
              m_ParticleObjects.Add(Attack.DOS, m_Particles[3]);
              m_ParticleObjects.Add(Attack.RANSOM, m_Particles[4]);
              m_ParticleObjects.Add(Attack.KEYBOARD, m_Particles[5]);
              m_ParticleObjects.Add(Attack.WORMS, m_Particles[6]);
              m_ParticleObjects.Add(Attack.BRUTE_FORCE, m_Particles[7]);
              m_ParticleObjects.Add(Attack.BACK_DOOR, m_Particles[8]);
              m_ParticleObjects.Add(Attack.DNS, m_Particles[9]);
              m_ParticleObjects.Add(Attack.MIM, m_Particles[10]);
          }*/

        // Update is called once per frame
        void Update()
        {
            //m_Timer += Time.deltaTime;
            //m_TimerDuration += Time.deltaTime;

            //if (m_TimerDuration >= 5.0f)
            //{
            //   m_ProgVirus = UsbProgram.Program.NONE;
            //    m_TimerDuration = 0.0f;
            //}
            //if (m_Timer >= m_Time)
            //{

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
                    break;
                case UsbProgram.Program.PhishingAttack: // All the fish
                    fishspawner();                // m_Time = 0.1f;


                    break;
                case UsbProgram.Program.KeyLogger: // UI Text says no
                    break;
                //case UsbProgram.Program.MIM:
                // break;
                case UsbProgram.Program.RansomVirus: //Money
                    m_Time = 0.5f;
                    Instantiate(m_Particles[3], transform.position, Quaternion.identity);
                    break;
                case UsbProgram.Program.RogueSoftware: //Tia Fighter
                    break;
                case UsbProgram.Program.TrojanHorse: //Arrow fired into the PC
                    m_Time = 1.5f;
                    Vector3 m_Pos = RandLoc();
                    Instantiate(m_Particles[0], m_Pos, Quaternion.LookRotation(transform.position));
                    break;
                case UsbProgram.Program.Worms:
                    m_Time = 0.5f;
                    Instantiate(m_Particles[1], transform.position, Quaternion.identity);//Worms everywhere
                    break;

                    m_Timer += Time.deltaTime;
                    if (m_Timer >= m_Time)
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
                                break;
                            case UsbProgram.Program.PhishingAttack: // All the fish
                                m_Time = 0.25f;
                                //Vector3 t_pos = m_FishSpawn.transform.position;
                                //t_pos.z += UnityEngine.Random.Range(-1.0f, 1.0f);
                                //Instantiate(m_Particles[2], t_pos, Quaternion.identity);
                                break;
                            case UsbProgram.Program.KeyLogger: // UI Text says no
                                break;
                            //case UsbProgram.Program.MIM:
                            // break;
                            case UsbProgram.Program.RansomVirus: //Money
                                m_Time = 0.5f;
                                Instantiate(m_Particles[3], transform.position, Quaternion.identity);
                                break;
                            case UsbProgram.Program.RogueSoftware: //Tia Fighter
                                break;
                            case UsbProgram.Program.TrojanHorse: //Arrow fired into the PC
                                m_Time = 1.5f;
                                Instantiate(m_Particles[0], RandLoc(), Quaternion.LookRotation(transform.position));
                                break;
                            case UsbProgram.Program.Worms:
                                m_Time = 0.5f;
                                Instantiate(m_Particles[1], transform.position, Quaternion.identity);//Worms everywhere
                                break;

                        }
                        m_Timer = 0.0f;
                    }

                    m_ProgVirus = UsbProgram.Program.NONE;
                    //    m_Timer = 0.0f;
                    //}
            }
        }

        public Vector3 RandLoc()
        {
            Vector3 m_randLoc;

            m_randLoc = UnityEngine.Random.onUnitSphere * m_SphereSize;


            return m_randLoc;
        }

        private void fishspawner()
        {
            for (int i = 0; i < 20; i++)
            {
                Vector3 t_pos = transform.position;
                t_pos.y = 10f;
                //t_pos.z += UnityEngine.Random.Range(-0.001f, 0.001f);
                //t_pos.x += UnityEngine.Random.Range(-0.001f, 0.001f);
                GameObject t_fishParticle;
                t_fishParticle = (GameObject)Instantiate(m_Particles[2], t_pos, Quaternion.identity);
                Destroy(t_fishParticle, 5f);

            }

        }

    }



}