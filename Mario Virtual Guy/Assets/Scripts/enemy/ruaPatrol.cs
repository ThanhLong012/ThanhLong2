using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ruaPatrol : MonoBehaviour
{
    [SerializeField] private Transform rightEdge;
    [SerializeField] private Transform leftEdge;

    [SerializeField] private Transform enemy;
    [SerializeField] private float speed;

    private bool movingLeft;

    [Header("Hanh vi idle")]
    [SerializeField] private float ildeDuration; // duration khoang thoi gian
    private float ildeTimer; // hen gio

    private Vector3 initScale;

    private void Awake()
    {
        initScale = enemy.localScale;
    }

    private void Update()
    {
        if (movingLeft)
        {
            if (enemy.position.x <= rightEdge.position.x)
            {
                MoveInDirection(1);
            }
            else
            {
                //change direction
                ChangeDirection();
            }
        }
        else
        {
            if (enemy.position.x >= leftEdge.position.x)
            {
                MoveInDirection(-1);
            }
            else
            {
                //change direction
                ChangeDirection();
            }
        }
    }

    private void ChangeDirection()
    {
        //animator khong chuyen dong
        ildeTimer = ildeTimer + Time.deltaTime;
        if (ildeTimer > ildeDuration)
        {
            movingLeft = !movingLeft;
        }
    }

    private void MoveInDirection(int direction)
    {
        ildeTimer = 0;
        //animator chuyen dong
        //face move
        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * direction, initScale.y, initScale.z);
        //move in direction
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * direction * speed
            , enemy.position.y, enemy.position.z);
    }
}
