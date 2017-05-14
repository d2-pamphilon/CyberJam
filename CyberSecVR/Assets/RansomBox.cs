using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RansomBox : MonoBehaviour {

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Gold")
        {
            GetComponentInParent<Virus.ParticleManager>().ransomOff();
            Destroy(gameObject);
        }

    }
}
