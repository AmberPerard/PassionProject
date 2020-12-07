using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFood : MonoBehaviour
{
    public bool moving;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        moving = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (moving)
        {
            rb.useGravity = true;
            rb.velocity = -transform.up * 2;
        }
    }
}
