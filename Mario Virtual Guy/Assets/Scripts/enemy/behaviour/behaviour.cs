using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class behaviour : MonoBehaviour
{
    [Header("Attack")]
    //khoang cach tan cong
    [SerializeField] private float attackDistance; // khoang cach toi thieu de tan cong 
    [SerializeField] private float moveSpeed;
    [SerializeField] private float timer; //thoi gian hoi chieu giua cac don tan cong

    [SerializeField] public GameObject hotzone;
    [SerializeField] public GameObject trigger;
    [HideInInspector] public Transform target;
    [HideInInspector] public bool inRange; //kiem tra nguoi choi co trong pham vi khong

    [SerializeField] private Transform left;
    [SerializeField] private Transform right;

    private RaycastHit2D hit;
    private Animator animator;
    private float distance; //luu tru khoang cach  giua ke thu va nguoi choi
    private bool attackMode; //che do tan cong
    private bool cooling; //kiem tra ke thu co ha nhiet sau khi tan cong khong
    //private float intTimer;

    // Start is called before the first frame update
    private void Awake()
    {
        SelectTarger();
        animator = GetComponent<Animator>();
        //intTimer = timer; // luu tru gia tri ban dau cua bo dem thoi gian
    }
    // Update is called once per frame
    void Update()
    {
        if (!attackMode)
        {
            Move();
        }
        if (!InsideofLimits() && !inRange && !animator.GetCurrentAnimatorStateInfo(0).IsName("attack"))
        {
            SelectTarger();
        }
        //khi nguoi choi bi phat hien       
        if (inRange)
        {
            EnemyLogic();
        }
    }

    void EnemyLogic()
    {
        distance = Vector2.Distance(transform.position, target.position);
        if (distance > attackDistance)
        {
            StopAttack();
        }
        else if (distance <= attackDistance && cooling == false)
        {
            Attack();
        }
        if (cooling)
        {
            //Cooldown();
            animator.SetBool("attack", false);
        }
    }

    void Move()
    {
        animator.SetBool("run", true);
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("attack"))
        {
            Vector2 targetPosition = new Vector2(target.position.x, transform.position.y);
            //di chuyen = vi tri hien tai , vi tri muc tieu , toc do
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }

    void Attack()
    {
        //timer = intTimer; //dat lai bo dem thoi gian khi nguoi choi buoc vao pham vi tan cong
        attackMode = true;//kiem tra xem ke thu con co the tan cong hay khong
        animator.SetBool("run", false);
        animator.SetBool("attack", true);
    }

    public void StopAttack()
    {
        cooling = false;
        attackMode = false;
        animator.SetBool("attack", false);
    }
    /*void Cooldown()
    {
        timer -= Time.deltaTime;

        if(timer <= 0 && cooling && attackMode)
        {
            cooling = false;
            timer = intTimer;
        }
    }*/

    /*public void TriggerCooling()
    {
        cooling = true;
    }*/

    private bool InsideofLimits()
    {
        return transform.position.x > left.position.x && transform.position.x < right.position.x;
    }


    public void SelectTarger()
    {
        float distanceLeft = Vector2.Distance(transform.position, left.position);
        float distanceRight = Vector2.Distance(transform.position, right.position);
        if (distanceLeft > distanceRight)
        {
            target = left;
        }
        else
        {
            target = right;
        }
        Flip();
    }

    public void Flip()
    {
        Vector3 rotation = transform.eulerAngles;
        if (transform.position.x > target.position.x)
        {
            rotation.y = 180f;
        }
        else
        {
            rotation.y = 0;
        }
        transform.eulerAngles = rotation;
    }
}
