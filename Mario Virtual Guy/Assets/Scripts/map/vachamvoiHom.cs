using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vachamvoiHom : MonoBehaviour
{
    public SpriteRenderer sprite;
    public Sprite Open;
    [SerializeField] private GameObject gold;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            sprite.sprite = Open;
            Instantiate(gold, transform.position, transform.rotation);
        }
    }
}
