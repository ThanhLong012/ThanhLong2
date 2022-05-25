using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    [Header("Move")]
    [SerializeField] private float speed;
    [SerializeField] private float jumpHeight;
    [SerializeField] float move;

    [Header("Key")]
    public Transform keyFollowPoint;
    public Key followingKey;

    [Header("Collider/Flip")]
    [SerializeField] LayerMask jumpableGround;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Rigidbody2D rb;
    private Animator animator;

    private enum MovementState { idle, walk, jump, fall};

    [Header("AudioSource")]
    [SerializeField] private AudioSource jumpSoundEffect;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //move = CrossPlatformInputManager.GetAxis("Horizontal");
        move = Input.GetAxis("Horizontal");
        //rb.velocity = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal") * speed , rb.velocity.y);
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed , rb.velocity.y);
        if (Input.GetButtonDown("Jump") && isGround())
        {
            jumpSoundEffect.Play();
            rb.velocity = new Vector2 (rb.velocity.x , jumpHeight);
        }
        UpdateAnimationState();
    }
    private void UpdateAnimationState()
    {
        MovementState state;
        if ( move > 0)
        {
            state = MovementState.walk;
            sprite.flipX = false;
        }
        else if (move < 0)
        {
            state = MovementState.walk;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }
        if (rb.velocity.y > 0.1f)
        {
            state = MovementState.jump;
        }
        else if (rb.velocity.y < -0.1f)
        {
            state = MovementState.fall;
        }
        animator.SetInteger("state" , (int)state);
    }
    private bool isGround()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);
    }
}
