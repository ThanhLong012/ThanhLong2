using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    [SerializeField] private GameObject PlantPrefab;
    [SerializeField] private GameObject boomEffect;
    [SerializeField] private Transform firePoint;
    float timebetween;
    public float startTimebetween;
    // Start is called before the first frame update
    void Start()
    {
        timebetween = startTimebetween;
    }

    // Update is called once per frame
    void Update()
    {
        if(timebetween <= 0)
        {
            Instantiate(boomEffect, firePoint.position, firePoint.rotation);
            Instantiate(PlantPrefab, firePoint.position , firePoint.rotation);
            timebetween = startTimebetween;
        }
        else
        {
            timebetween -= Time.deltaTime;
        }
    }
}
