using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemColllector : MonoBehaviour
{
    [SerializeField] private int cherries = 0;
    [SerializeField] private Text cherriesText;
    [SerializeField] private int gold = 0;
    [SerializeField] private Text goldText;
    [SerializeField] private AudioSource collectionAudioSource;
        
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
        if(collision.gameObject.tag == "item")
        {
            collectionAudioSource.Play();
            Destroy(collision.gameObject);
            cherries++;
            cherriesText.text ="x" + cherries;
        }
        if (collision.gameObject.tag == "coin")
        {
            collectionAudioSource.Play();
            Destroy(collision.gameObject);
            gold++;
            goldText.text = "x" + gold;
        }
    }
}
