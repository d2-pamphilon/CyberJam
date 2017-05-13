﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace Virus
{

    public class ParticleManager : MonoBehaviour
    {

        public List<GameObject> m_Particles;

        public int m_SphereSize;


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

            m_SphereSize = 10;

            m_comCon = GetComponent<ComputerController>();
            m_program = m_comCon.GetComponent<UsbProgram>();


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
                    DartSpawner();
                    break;
                case UsbProgram.Program.Worms:
                    m_Time = 0.5f;
                    Instantiate(m_Particles[1], transform.position, Quaternion.identity);//Worms everywhere
                    break;

            }
            m_ProgVirus = UsbProgram.Program.NONE;
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
                m_Dart  = (GameObject)Instantiate(m_Particles[0], m_Pos, Quaternion.identity);
                Destroy(m_Dart, 5f);
            }
        }

    }



}