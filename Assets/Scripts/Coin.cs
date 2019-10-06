using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    public ParticleSystem particle;

    private int collectedCoinsNum = 0;
    
    private bool collected = false;

    void Update()
    {
        
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && !collected)
        {
            collected = true;
            Destroy(gameObject);
            Instantiate(particle, transform.position, transform.rotation);
            SoundManagerScript.PlaySound("Coin1");
        }
    }

}
