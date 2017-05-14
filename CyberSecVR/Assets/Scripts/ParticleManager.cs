using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace Virus
{

    public class ParticleManager : MonoBehaviour
    {
        public Transform m_topspawner;
        public UsbProgram.Program m_ProgVirus;
        private PrefabSprites m_Prefab;
        private Transform[] ts;
        private Transform t_target;
        private int m_SphereSize;

        private GameObject t_const;
        //private bool deedDone;
        // Use this for initialization
        void Start()
        {
            m_Prefab = GetComponent<PrefabSprites>();
            m_SphereSize = 2;
           // deedDone = false;
            ts = gameObject.GetComponentsInChildren<Transform>();
            foreach (Transform Child in ts)
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
                case UsbProgram.Program.BackDoor:
                    Door();
                    break;
                case UsbProgram.Program.BruteForce:
                    Force();
                    break;
                //case UsbProgram.Program.DNS:
                //DNS();
                //    break;
                case UsbProgram.Program.DDOS: //fire particles


                    t_const = Instantiate(m_Prefab.ConstFire, t_target.position, Quaternion.Euler(-90f, 0f, 0f));
                    GameObject t_burst = (GameObject)Instantiate(m_Prefab.Burst, t_target.position, Quaternion.identity);

                    Destroy(t_burst, 5f);
                    //Destroy(t_const, 10f);


                    break;
                case UsbProgram.Program.PhishingAttack: // All the fish
                    fishspawner();
                    break;
                case UsbProgram.Program.KeyLogger:
                    KeyLogger();// UI Text says no
                    break;
                //case UsbProgram.Program.MIM:
                //    MIM();
                //    break;
                case UsbProgram.Program.RansomVirus: //Money
                    Ransom();
                    break;
                case UsbProgram.Program.RogueSoftware:
                    Rogue(); //Tia Fighter
                    break;
                case UsbProgram.Program.TrojanHorse: //Arrow fired into the PC
                    DartSpawner();
                    break;
                case UsbProgram.Program.Worms:
                    Worm();
                    break;
                case UsbProgram.Program.Garden:
                    Garden();
                    break;

            }
            m_ProgVirus = UsbProgram.Program.NONE;
        }


        public Vector3 RandLoc()
        {
            Vector3 m_randLoc;
            //while (true)
            //{
                m_randLoc = UnityEngine.Random.onUnitSphere * m_SphereSize;

                //if (m_randLoc.x >= 0.0f && m_randLoc.x <= m_SphereSize)
                //{
                //    if (m_randLoc.y >= 0.0f && m_randLoc.y <= 0.0f)
                //    {
                //        if (m_randLoc.z >= -m_SphereSize && m_randLoc.z <= m_SphereSize)
                //        {
                //            print(m_randLoc);
                            return m_randLoc;
                //        }
                //    }
                //}
            //}
        }

        public float RandFloat(float _min, float _max)
        {
            float m_val = UnityEngine.Random.Range(_min, _max);

            return m_val;
        }

        private void fishspawner()
        {
            for (int i = 0; i < 20; i++)
            {

                Vector3 t_pos = transform.position;
                t_pos += UnityEngine.Random.insideUnitSphere * 3;
                t_pos.y = 2f;

                GameObject t_fishParticle;
                t_fishParticle = (GameObject)Instantiate(m_Prefab.Fish, t_pos, Quaternion.identity);
                //Destroy(t_fishParticle, 5f);
            }

        }
        private void DartSpawner()
        {
            for (int i = 0; i < 10; i++)
            {
                Vector3 m_Pos = RandLoc();
                GameObject m_Dart;

                m_Dart = (GameObject)Instantiate(m_Prefab.Dart, m_Pos, Quaternion.identity);
                m_Dart.GetComponent<Trojen>().m_target = t_target;
                Destroy(m_Dart, 4f);
            }
        }
        private void Worm()
        {
            Instantiate(m_Prefab.Worm, transform.position, Quaternion.identity);//Worms everywhere

        }
        private void Ransom()
        {

            foreach (Transform T in transform)
            {
                T.gameObject.SetActive(false);
            }

            Vector3 t_pos = transform.position += new Vector3(0, 0.1f, 0);
            GameObject T_box = (GameObject)Instantiate(m_Prefab.RansomBox, t_pos, Quaternion.identity, transform);

            // T_box.SetActive(true);
            //if gold collides
            //destroy chest & gold 
            //turn children on 
            //clear list


            //   Instantiate(m_Particles[3], transform.position, Quaternion.identity);
        }
        public void ransomOff()
        {
            foreach (Transform T in ts)
            {
                T.gameObject.SetActive(true);
            }

        }
        public void stopFire()
        {
            Destroy(t_const);
        }
        private void Rogue()
        {
            

        }
        private void MIM()
        {

        }
        private void KeyLogger()
        {

        }
        private void DDOS()
        {

        }
        private void DNS()
        {

        }
        private void Force()
        {
            print("force");

        }
        private void Door()
        {

        }
        private void Garden()
        {
            for (int i = 0; i < 50; i++)
            {
                Vector2 t_pos = UnityEngine.Random.insideUnitCircle;

                GameObject t_Grass = (GameObject)Instantiate(m_Prefab.Garden, new Vector3(t_pos.x, m_topspawner.position.y, t_pos.y), Quaternion.identity);
                Destroy(t_Grass, 10f);
            }

        }






    }



}



//{
//       }