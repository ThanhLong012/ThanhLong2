using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class door : MonoBehaviour
{
    private PlayerController playerController;
    public SpriteRenderer spriteRenderer;
    public Sprite doorOpenSprite;
    public bool doorOpen, waitingToOpen;

    // Start is called before the first frame update
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        waitingToOpen = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (waitingToOpen)
        {
            if(Vector2.Distance(playerController.followingKey.transform.position, transform.position) < 0.1f)
            {
                waitingToOpen=false;
                doorOpen = true;
                spriteRenderer.sprite = doorOpenSprite;
                playerController.followingKey.gameObject.SetActive(false);
                playerController.followingKey = null;
            }
        }
        if(doorOpen && Vector2.Distance(playerController.transform.position, transform.position) <1f 
            && Input.GetAxis("Vertical") >0.1f)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(playerController.followingKey != null)
            {
                playerController.followingKey.target = transform;
            }
        }
    }
}
