using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterGamePlay : MonoBehaviour
{
    private bool collected = false;

    public GameObject body;
    public GameObject arm1;
    public GameObject arm2;
    public GameObject leg1;
    public GameObject leg2;
    public GameObject head;

    public ParticleSystem Deathparticle;
    public ParticleSystem DeathparticlePolice;
    public Vector3 tempPos;


    public int Coins = 0;

    public Sprite outfit1Head;
    public Sprite outfit2Head;

    public Sprite outfit1Body;
    public Sprite outfit1Arm;
    public Sprite outfit1Leg;

    public Sprite outfit2Body;
    public Sprite outfit2Arm;
    public Sprite outfit2Leg;

    public Sprite outfit3Body;
    public Sprite outfit3Arm;
    public Sprite outfit3Leg;

    public Sprite outfit4Body;
    public Sprite outfit4Arm;
    public Sprite outfit4Leg;


    public GameObject UI1;



    // Start is called before the first frame update
    void Start()
    {
        tempPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Coins == 1)
        {
            body.GetComponent<SpriteRenderer>().sprite = outfit1Body;
            arm1.GetComponent<SpriteRenderer>().sprite = outfit1Arm;
            arm2.GetComponent<SpriteRenderer>().sprite = outfit1Arm;
            leg1.GetComponent<SpriteRenderer>().sprite = outfit1Leg;
            leg2.GetComponent<SpriteRenderer>().sprite = outfit1Leg;
        }
        else if (Coins == 2)
        {
            body.GetComponent<SpriteRenderer>().sprite = outfit2Body;
            arm1.GetComponent<SpriteRenderer>().sprite = outfit2Arm;
            arm2.GetComponent<SpriteRenderer>().sprite = outfit2Arm;
            leg1.GetComponent<SpriteRenderer>().sprite = outfit2Leg;
            leg2.GetComponent<SpriteRenderer>().sprite = outfit2Leg;
            head.GetComponent<SpriteRenderer>().sprite = outfit2Head;
        }
        else if (Coins == 3)
        {
            body.GetComponent<SpriteRenderer>().sprite = outfit3Body;
            arm1.GetComponent<SpriteRenderer>().sprite = outfit3Arm;
            arm2.GetComponent<SpriteRenderer>().sprite = outfit3Arm;
            leg1.GetComponent<SpriteRenderer>().sprite = outfit3Leg;
            leg2.GetComponent<SpriteRenderer>().sprite = outfit3Leg;
            head.GetComponent<SpriteRenderer>().sprite = outfit1Head;
        }
        else if (Coins == 4)
        {
            body.GetComponent<SpriteRenderer>().sprite = outfit4Body;
            arm1.GetComponent<SpriteRenderer>().sprite = outfit4Arm;
            arm2.GetComponent<SpriteRenderer>().sprite = outfit4Arm;
            leg1.GetComponent<SpriteRenderer>().sprite = outfit4Leg;
            leg2.GetComponent<SpriteRenderer>().sprite = outfit4Leg;
        }


        if (transform.position == tempPos)
        {
            gameObject.SetActive(true);
        }

    }


    

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Coin" && !collected)
        {
            Coins = Coins + 1;

            tempPos = transform.position;


            collected = true;
            StartCoroutine(oneSec());
        }
        if (collision.tag == "Wire")
        {
            Instantiate(Deathparticle, transform.position, transform.rotation);
            SoundManagerScript.PlaySound("Death1");
            transform.position = tempPos;

        }
        if (collision.tag == "Police")
        {
            Instantiate(DeathparticlePolice, transform.position, transform.rotation);
            SoundManagerScript.PlaySound("Death1");
            transform.position = tempPos;

        }
        if (collision.tag == "Chair")
        {
            UI1.SetActive(true);
        }



    }




    IEnumerator oneSec()
    {
        yield return new WaitForSeconds(0.1f);
        collected = false;
    }
}


