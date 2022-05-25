using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spear : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private LayerMask mask;
    [SerializeField] private float distance;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics2D.Raycast(rb.position, Vector2.up, distance, mask))
        {
            rb.velocity = Vector2.up * speed;
        }
        //Destroy(gameObject, 20f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);            
        }
    }
}
