using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light : MonoBehaviour
{
    public float range;
    public Transform target;
    bool detected = false;
    public SpriteRenderer sprite;
    public Sprite lightOn;
    public Sprite lightOff;
    Vector2 distance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 targetPos = target.position;
        distance = targetPos - (Vector2)transform.position;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, distance, range);

        if (hit)
        {
            if(hit.collider.gameObject.tag == "Player")
            {
                if(detected == false)
                {
                    detected = true;
                    sprite.sprite = lightOn;
                }
            }
            else
            {
                if(detected == true)
                {
                    detected = false;
                    sprite.sprite = lightOff;
                }
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
