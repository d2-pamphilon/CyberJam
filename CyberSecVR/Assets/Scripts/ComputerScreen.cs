﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ComputerScreen
{
    public class ComputerScreen : MonoBehaviour
    {

        private UsbProgram.Program m_virus;
        private PrefabSprites m_Sprite;

        private Canvas m_Canvas;
        private UnityEngine.UI.Image m_Image;

        // Use this for initialization
        void Start()
        {
            m_virus = UsbProgram.Program.NONE;
            m_Canvas = GetComponentInChildren<Canvas>();
            m_Image = GetComponentInChildren<UnityEngine.UI.Image>();
            m_Sprite = GetComponentInParent<PrefabSprites>();
        }

        // Update is called once per frame
        void Update()
        {
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
               
            }
        }


        public void ChangeScreen(UsbProgram.Program _Virus)
        {
            m_virus = _Virus;
        }



    }
}
