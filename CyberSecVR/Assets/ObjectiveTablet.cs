using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectiveTablet : MonoBehaviour {

    UsbProgram.Program program;

    [SerializeField]
    Text text;
    [SerializeField]
    Text hintText;
    [SerializeField]
    Image hintImage;

	// Use this for initialization
	void Start () {
        //text = transform.FindChild("Canvas").gameObject.transform.FindChild("Name").GetComponent<Text>();
        //hintText = transform.FindChild("Canvas").gameObject.transform.FindChild("Hint").GetComponent<Text>();
        //hintImage = transform.FindChild("Canvas").gameObject.transform.FindChild("HintImage").GetComponent<GUITexture>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void setProgram(UsbProgram.Program _program, bool hint)
    {
        hintText.enabled = hint;
        hintImage.enabled = hint;
        switch(_program)
        {
            case UsbProgram.Program.NONE:
                _program = UsbProgram.Program.RansomVirus;
                text.text = "Ransom Virus";
                break;
            case UsbProgram.Program.BackDoor:
                text.text = "BackDoor";
                break;
            case UsbProgram.Program.BruteForce:
                text.text = "Brute Force";
                break;
            case UsbProgram.Program.DDOS: //fire particles
                text.text = "DDOS";
                break;
            case UsbProgram.Program.PhishingAttack: // All the fish
                text.text = "Phishing Attack";
                break;
            case UsbProgram.Program.KeyLogger:
                text.text = "KeyLogger";
                break;
            case UsbProgram.Program.RansomVirus: //Money
                text.text = "Ransom Virus";
                break;
            case UsbProgram.Program.RogueSoftware:
                text.text = "Rogue Software";
                break;
            case UsbProgram.Program.TrojanHorse: //Arrow fired into the PC
                text.text = "Trojan Horse";
                break;
            case UsbProgram.Program.Worms:
                text.text = "Worm Virus";
                break;
            case UsbProgram.Program.DNS:
                text.text = "DNS Attack";
                break;
            default:
                int i = 0;
                break;
        }

        if (hint)
        {
            switch (_program)
            {
                case UsbProgram.Program.NONE:
                    break;
                case UsbProgram.Program.BackDoor:
                    hintImage.overrideSprite = Resources.Load<Sprite>("Textures/sprite");
                    hintImage.overrideSprite = Resources.Load<Sprite>("Hints/BackDoor");
                    break;
                case UsbProgram.Program.BruteForce:
                    hintImage.overrideSprite = Resources.Load<Sprite>("Hints/BruteForce");
                    break;
                case UsbProgram.Program.DDOS: //fire particles
                    hintImage.overrideSprite = Resources.Load<Sprite>("Hints/DDOS");
                    break;
                case UsbProgram.Program.PhishingAttack: // All the fish
                    hintImage.overrideSprite = Resources.Load<Sprite>("Hints/Phishing");
                    break;
                case UsbProgram.Program.KeyLogger:
                    hintImage.overrideSprite = Resources.Load<Sprite>("Hints/KeyLogger");
                    break;
                case UsbProgram.Program.RansomVirus: //Money
                    hintImage.overrideSprite = Resources.Load<Sprite>("Hints/Ransom");
                    break;
                case UsbProgram.Program.RogueSoftware:
                    hintImage.overrideSprite = Resources.Load<Sprite>("Hints/Rogue");
                    break;
                case UsbProgram.Program.TrojanHorse: //Arrow fired into the PC
                    hintImage.overrideSprite = Resources.Load<Sprite>("Hints/Trojan");
                    break;
                case UsbProgram.Program.Worms:
                    hintImage.overrideSprite = Resources.Load<Sprite>("Hints/Worm");
                    break;
                case UsbProgram.Program.DNS:
                    hintImage.overrideSprite = Resources.Load<Sprite>("Hints/DNS");
                    break;
            }
        }
    }
}
