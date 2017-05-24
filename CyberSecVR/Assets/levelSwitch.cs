using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NewtonVR;
using UnityEngine.SceneManagement;


public class levelSwitch : MonoBehaviour
{

    [SerializeField]
    NVRSwitch nvr_switch;

    void Update()
    {
        if (nvr_switch.CurrentState==false)
        {
            SceneManager.LoadScene(1); 
        }
        //if (nvr_switch.OnButton)
        //{
        //    SceneManager.LoadScene(0);
        //}

    }

}
