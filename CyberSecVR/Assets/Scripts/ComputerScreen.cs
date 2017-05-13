using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ComputerScreen
{
    public class ComputerScreen : MonoBehaviour
    {

        public UsbProgram.Program m_virus;

        public List<Sprite> m_sprites;

        private Canvas m_Canvas;
        private UnityEngine.UI.Image m_Image;

        // Use this for initialization
        void Start()
        {
            m_virus = UsbProgram.Program.NONE;

            m_Canvas = GetComponentInChildren<Canvas>();
            m_Image = GetComponentInChildren<UnityEngine.UI.Image>();

        }

        // Update is called once per frame
        void Update()
        {
            // if (m_virus == UsbProgram.Program.PhishingAttack)
            if ( m_virus != UsbProgram.Program.NONE)
            {
                m_Image.color = Color.white;
            }
          
            switch (m_virus)
            {
                case UsbProgram.Program.PhishingAttack:
                    
                    m_Canvas.enabled = true;
                    m_Image.sprite = m_sprites[0];
                    break;
                case UsbProgram.Program.TrojanHorse:
                    m_Canvas.enabled = true;
                    m_Image.sprite = m_sprites[1];
                    break;
                case UsbProgram.Program.Worms:
                    m_Canvas.enabled = true;
                    m_Image.sprite = m_sprites[2];
                    break;
                default:
                    m_Canvas.enabled = false;
                    m_Image.color = Color.black;
                    break;
            }
        }


        public void ChangeScreen(UsbProgram.Program _Virus)
        {
            m_virus = _Virus;
        }



    }
}
