using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class axeDIchChuyen : MonoBehaviour
{
    public Rigidbody2D rb;
    public float left;
    public float right;
    public float velocityThreshold;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.angularVelocity = velocityThreshold;
    }

    // Update is called once per frame
    void Update()
    {
        Push();
    }
    public void Push()
    {
        if(transform.rotation.z > 0 && transform.rotation.z < right
            && (rb.angularVelocity > 0) && rb.angularVelocity < velocityThreshold)
        {
            rb.angularVelocity = velocityThreshold;
        }
        else if (transform.rotation.z < 0 && transform.rotation.z > left
            && (rb.angularVelocity < 0) && rb.angularVelocity > velocityThreshold * -1)
        {
            rb.angularVelocity = velocityThreshold * -1;
        }
    }
}
