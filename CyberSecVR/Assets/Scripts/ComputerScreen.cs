using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ComputerScreen
{
    public class ComputerScreen : MonoBehaviour
    {

        public UsbProgram.Program m_virus;
        public PrefabSprites m_Sprite;


        private Canvas m_Canvas;
        private UnityEngine.UI.Image m_Image;

        // Use this for initialization
        void Start()
        {
            m_virus = UsbProgram.Program.NONE;
            m_Sprite = GetComponentInParent<PrefabSprites>();
            m_Canvas = GetComponentInChildren<Canvas>();
            m_Image = GetComponentInChildren<UnityEngine.UI.Image>();

        }

        // Update is called once per frame
        void Update()
        {
            
            // if (m_virus == UsbProgram.Program.PhishingAttack)
            if (m_virus != UsbProgram.Program.NONE)
            {
                m_Image.color = Color.white;
            }
            else
            {
                m_Image.color = Color.black;
            }

            switch (m_virus)
            {
                case UsbProgram.Program.PhishingAttack:
                    m_Canvas.enabled = true;
                    m_Image.sprite = m_Sprite.S_Fishing;
                    break;
                case UsbProgram.Program.TrojanHorse:
                    m_Canvas.enabled = true;
                    m_Image.sprite = m_Sprite.S_Trojan;
                    break;
                case UsbProgram.Program.Worms:
                    m_Canvas.enabled = true;
                    m_Image.sprite = m_Sprite.S_Worm;
                    break;
                case UsbProgram.Program.BruteForce:
                    m_Canvas.enabled = true;
                    m_Image.sprite = m_Sprite.S_BruteForce;
                    break;
                case UsbProgram.Program.BackDoor:
                    m_Canvas.enabled = true;
                    m_Image.sprite = m_Sprite.S_BackDoor;
                    break;
                case UsbProgram.Program.DDOS:
                    m_Canvas.enabled = true;
                    m_Image.sprite = m_Sprite.S_DDOS;
                    break;
                case UsbProgram.Program.KeyLogger:
                    m_Canvas.enabled = true;
                    m_Image.sprite = m_Sprite.S_KeyLog;
                    break;

            }
        }


        public void ChangeScreen(UsbProgram.Program _Virus)
        {
            m_virus = _Virus;
        }



    }
}
