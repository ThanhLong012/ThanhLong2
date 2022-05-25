using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeBoom : MonoBehaviour
{
    public GameObject theBoom;
    public Transform shootForm;
    public float shootTime;
    float nextShoot = 0f;
    private void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && Time.time>nextShoot )
        {
            nextShoot = Time.time + shootTime;
            Instantiate (theBoom, shootForm.position,Quaternion.identity);
        }
    }
}
