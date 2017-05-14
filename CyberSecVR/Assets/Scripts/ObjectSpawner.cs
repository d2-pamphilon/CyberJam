using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{

    public List<GameObject> m_object;
    // Use this for initialization
    void Start()
    {
        GameObject m_GO = GameObject.FindGameObjectWithTag("MainCamera");
        Transform t_transform = m_GO.GetComponent<Transform>();
        Quaternion m_rot = Quaternion.LookRotation(transform.position);
        Instantiate(m_object[Random.Range(0, m_object.Count)], transform.position, m_rot);
    }


}
