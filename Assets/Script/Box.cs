﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{

    public int currentHealth, maxHealth;
    public GameObject deathEffect;

    public Transform itemPosition;

    public GameObject collectible;

    private SpriteRenderer theSR;

    public float hitLength;
    private float hitCounter;


    [Range(0, 100)]public float chanceToDrop;

    // Start is called before the first frame update
    void Start()
    {
        theSR = GetComponent<SpriteRenderer>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(hitCounter > 0)
        {
            hitCounter -= Time.deltaTime;

            if(hitCounter <= 0)
            {
                theSR.color =  new Color(1f,1f,1f,1f);
            }   
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (hitCounter <= 0 )
        {
        
            if(other.tag == "Bullet")
            {
                currentHealth --;
                theSR.color =  new Color(1f,1f,1f,0.6f);
                hitCounter = hitLength;
                AudioManeger.instance.PlaySFX(18);
                if (currentHealth <= 0)
                {
                    AudioManeger.instance.PlaySFX(7);
                    Destroy(gameObject);
                    Instantiate(deathEffect, transform.position, transform.rotation);

                    float dropSelect = Random.Range(0, 100f);

                    if(dropSelect <= chanceToDrop)
                    {
                        Instantiate(collectible, itemPosition.position, transform.rotation);
                    }
                }

            }
            if(other.tag == "Charge Bullet")
            {
                currentHealth -= 5;
                theSR.color =  new Color(1f,1f,1f,0.6f);
                hitCounter = hitLength;
                AudioManeger.instance.PlaySFX(8);
                if (currentHealth <= 0)
                {
                    AudioManeger.instance.PlaySFX(3);
                    Destroy(gameObject);
                    Instantiate(deathEffect, transform.position, transform.rotation);

                    float dropSelect = Random.Range(0, 100f);

                    if(dropSelect <= chanceToDrop)
                    {
                        Instantiate(collectible, itemPosition.position, transform.rotation);
                    }
                }

            }
            
            if(other.tag == "Weapon1")
            {
                currentHealth -= 3;
                theSR.color =  new Color(1f,1f,1f,0.6f);
                AudioManeger.instance.PlaySFX(16);
                if (currentHealth <= 0)
                {
                    AudioManeger.instance.PlaySFX(3);
                    Destroy(gameObject);
                    Instantiate(deathEffect, transform.position, transform.rotation);

                    float dropSelect = Random.Range(0, 100f);

                    if(dropSelect <= chanceToDrop)
                    {
                        Instantiate(collectible, itemPosition.position, transform.rotation);
                    }
                }

            }
        }
    }


}
