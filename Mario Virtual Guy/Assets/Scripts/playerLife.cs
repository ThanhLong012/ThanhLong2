using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerLife : MonoBehaviour
{
    float speed = 5;
    Animator animator;
    Rigidbody2D rb;
    [SerializeField] private AudioSource deathAudioSource;
    [SerializeField] private GameObject effectBlood;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag ==  "trap")
        {
            deathAudioSource.Play();
            Die();
        }

        if(collision.gameObject.tag == "Spikes")
        {
            deathAudioSource.Play();
            Die();
        }
        if(collision.gameObject.tag == "boom")
        {
            deathAudioSource.Play();
            Die();
        }
    }
    public void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        //Destroy(gameObject, 1f);
        animator.SetTrigger("death");
    }
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
