using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantBullet : MonoBehaviour
{
    [SerializeField] private float speed;
    Rigidbody2D rb;
    [SerializeField] private GameObject boomEffect;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.left * speed;
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject,5f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy (gameObject);
            Instantiate(boomEffect,transform.position,transform.rotation);
        }
        if (collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
            Instantiate(boomEffect, transform.position, transform.rotation);
        }
    }
}
