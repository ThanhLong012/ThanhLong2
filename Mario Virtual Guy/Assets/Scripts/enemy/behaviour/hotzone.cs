using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hotzone : MonoBehaviour
{
    private behaviour enemyBehaviour;
    private bool inRange;
    private Animator animator;
    // Start is called before the first frame update
    private void Awake()
    {
        animator = GetComponentInParent<Animator>();
        enemyBehaviour = GetComponentInParent<behaviour>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (inRange && !animator.GetCurrentAnimatorStateInfo(0).IsName("ilde"))
        {
            enemyBehaviour.Flip();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            inRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            inRange = false;
            gameObject.SetActive(false);
            enemyBehaviour.trigger.SetActive(true);
            enemyBehaviour.inRange = false;
            enemyBehaviour.SelectTarger();
        }
    }
}
