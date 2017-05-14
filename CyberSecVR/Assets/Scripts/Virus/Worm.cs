using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Worm : MonoBehaviour
{
    private Vector3 direction;
    public float speed;
    void Start()
    {
        direction = Vector3.forward;
    }
    void Update()
    {
        direction.x += 0.01f;
        direction.z += 0.01f;
        transform.position += direction * (speed/100) * Time.deltaTime;
    }

}
