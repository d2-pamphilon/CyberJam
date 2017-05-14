using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Worm : MonoBehaviour
{
    private Vector3 direction;
    public GameObject m_worm;
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
    void OnCollisionEnter(Collider col)
    {
        if (col.gameObject.GetComponent<CombinableObject>() != null)
        {
            Destroy(col.gameObject);
            Vector3 t_pos = transform.position += new Vector3(1, 0, 0);
            Instantiate(m_worm, transform.position, Quaternion.identity);

        }

    }

}
