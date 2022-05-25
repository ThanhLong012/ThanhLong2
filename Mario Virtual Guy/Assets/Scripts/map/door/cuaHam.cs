using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cuaHam : MonoBehaviour
{
    public float speed =2;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }
    public void dichuyen()
    {
        rb.AddForce(Vector2.up * speed);
    }
}
