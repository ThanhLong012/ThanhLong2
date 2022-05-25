using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour
{
    private behaviour enemyBehaviour;
    // Start is called before the first frame update
    private void Awake()
    {
        enemyBehaviour = GetComponentInParent<behaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
            enemyBehaviour.target = collision.transform;
            enemyBehaviour.inRange = true;
            enemyBehaviour.hotzone.SetActive(true);
        }
    }
}
