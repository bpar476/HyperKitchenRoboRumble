using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blowtorch : MonoBehaviour
{
    public GameObject flame;
    public float power;
    public Rigidbody2D attachedBody;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Fire2") != 0)
        {
            flame.SetActive(true);
            attachedBody.AddForce(transform.right.normalized * power);
        }
        else
        {
            flame.SetActive(false);
        }
    }
}
