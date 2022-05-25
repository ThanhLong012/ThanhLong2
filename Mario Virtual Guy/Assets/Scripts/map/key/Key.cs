using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private float speedFollowing;
    public Transform target;
    private bool isFollowing;   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isFollowing)
        {
            transform.position = Vector3.Lerp(transform.position, target.position, speedFollowing * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PlayerController thePlayer = FindObjectOfType<PlayerController>();
            target = thePlayer.keyFollowPoint;
            isFollowing = true;
            thePlayer.followingKey = this;
        }
    }
}
