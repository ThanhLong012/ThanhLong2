using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boomController : MonoBehaviour
{
    public float bomSpeedHight;
    public float bomSpeedLow;
    public float bomAngle;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Start()
    {
        rb.AddForce(new Vector2(Random.Range(-bomAngle, bomAngle),
            Random.Range(bomSpeedLow, bomSpeedHight)), ForceMode2D.Impulse);
        Destroy(gameObject, 3f);    
    }
}
