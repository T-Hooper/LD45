using UnityEngine;
using System.Collections;
public class player_movement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpSpeed = 8f;
    private float movement = 0f;
    private Rigidbody2D rigidBody;
    public Transform groundCheckPoint;
    public Transform boxCheckPoint;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    public LayerMask boxLayer;
    private bool isTouchingGround = false;
    private bool isTouchingBox = false;
    public Animator animator;
    private bool jumping = false;
    private bool flipAllowed = true;



    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isTouchingGround = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);


        isTouchingBox = Physics2D.OverlapCircle(boxCheckPoint.position, groundCheckRadius, boxLayer);


        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            movement = speed;
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            movement = -speed;
        }
        else
        {
            movement = 0;
        }



        if (movement > 0f)
        {
            rigidBody.velocity = new Vector2(movement * speed * Time.deltaTime, rigidBody.velocity.y);
        }
        else if (movement < 0f)
        {
            rigidBody.velocity = new Vector2(movement * speed * Time.deltaTime, rigidBody.velocity.y);
        }
        else
        {
            rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);
        }



        if (transform.position.y < -6.85)
        {
            SoundManagerScript.PlaySound("Death1");
            transform.position = GetComponent<CharacterGamePlay>().tempPos;
        }


        Vector3 characterScale = transform.localScale;
        if ((Input.GetKey("a") || Input.GetKey("left")) && flipAllowed)
        {
            characterScale.x = -0.5f;
        }
        if ((Input.GetKey("d") || Input.GetKey("right")) && flipAllowed)
        {
            characterScale.x = 0.5f;
        }
        transform.localScale = characterScale;


        if (GetComponent<playerPush>().pushing == true)
        {
            flipAllowed = false;
        }
        else
        {
            flipAllowed = true;
        }







        animator.SetFloat("Speed", Mathf.Abs(movement));




        if (Input.GetKey("space") || Input.GetKey("up") || Input.GetKey("w"))  //input from button to jump
        {
            if ((jumping == false) && isTouchingGround)     // if not jumping, and is on the ground
            {
                SoundManagerScript.PlaySound("Jump1");
                jumping = true;
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpSpeed); //then jump
                animator.SetTrigger("Jumping");
                StartCoroutine(until());

            }

        }





    }



    IEnumerator until()
    {
        yield return new WaitUntil(() => isTouchingGround == true && rigidBody.velocity.y < 0.01);   // if the character is comming up through the platform the sound will not trigger when they touch
        jumping = false;
        animator.SetTrigger("Landed");
        SoundManagerScript.PlaySound("Land1");
    }
    


}