using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyFollow : MonoBehaviour
{
    public float range;
   // Vector2 Get2;
    public GameObject target;
    private Transform targetPos;
    private Vector2 currentPos;
    private float distance;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        targetPos = target.GetComponent<Transform>();
        currentPos = GetComponent<Transform>().position;
        distance = range;
    }

    // Update is called once per frame
    void Update()
    {
        //RaycastHit2D hit = Physics2D.Raycast(transform.position, Get2, range);
        if (Vector2.Distance(transform.position, targetPos.position) < distance)
        {
            Flip();
            transform.position = Vector2.MoveTowards(transform.position, targetPos.position, speed * Time.deltaTime);
        }
        else
        {
            Flip();
            if (Vector2.Distance(transform.position ,currentPos) <= 0)
            {
                
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, currentPos, speed * Time.deltaTime);
            }
        }
    }
    private void Flip()
    {
        if (transform.position.x > target.transform.position.x)
            transform.rotation = Quaternion.Euler(0, 0, 0);
        else
            transform.rotation = Quaternion.Euler(0, 180, 0);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
