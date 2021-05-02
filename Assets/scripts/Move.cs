using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Vector3 change;
    public Animator animator;
    


    public GameObject bulletR, bulletL, bulletU, bulletD, attD, attL, attP, attU;
    Vector2 bulletPos;
    public float fireRate = 0.5f;
    public float attRate = 0.5f;
    float nextfire = 0.0f;

    bool turnedR = false;
    bool turnedU = false;
    bool turnedD = false;
    bool turnedL = false;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        
    }




    void Update()
    {
        change = Vector2.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        if (Input.GetButtonDown("Fire1") && Time.time > nextfire)
        {
            nextfire = Time.time + attRate;
            fire2();
        }

        if (Input.GetButtonDown("Fire2") && Time.time > nextfire)
        {
            nextfire = Time.time + fireRate;
            fire1();
        }

        if (change.x > 0)
        {
            turnedR = true;
            turnedU = false;
            turnedD = false;
            turnedL = false;
        }

        if (change.x < 0)
        {
            turnedR = false;
            turnedU = false;
            turnedD = false;
            turnedL = true;
        }

        if (change.y > 0)
        {
            turnedR = false;
            turnedU = true;
            turnedD = false;
            turnedL = false;
        }

        if (change.y < 0)
        {
            turnedR = false;
            turnedU = false;
            turnedD = true;
            turnedL = false;
        }
        UpdateAnimationAndMove();





    }

    void UpdateAnimationAndMove()
    {
        if (change != Vector3.zero)
        {
            MoveCharacter();
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }
    }


    void MoveCharacter()
    {
        rb.MovePosition(transform.position + change * speed * Time.fixedDeltaTime);
    }

    void fire1()
    {

        bulletPos = transform.position;
        

        if (turnedR)
        {
            animator.SetTrigger("RzutP");
            bulletPos += new Vector2(+1f, 0.0f);
            Instantiate(bulletR, bulletPos, Quaternion.identity);
        }

        if (turnedL)
        {
            animator.SetTrigger("RzutL");
            bulletPos += new Vector2(-1f, 0.0f);
            Instantiate(bulletL, bulletPos, Quaternion.identity);
        }
        if (turnedU)
        {
            animator.SetTrigger("RzutU");
            bulletPos += new Vector2(0f, 1f);
            Instantiate(bulletU, bulletPos, Quaternion.identity);
        }

        if (turnedD) 
        {
            animator.SetTrigger("RzutD");
            bulletPos += new Vector2(0f, -1f);
            Instantiate(bulletD, bulletPos, Quaternion.identity);

            

            
        }
        
    }

    void fire2()
    {

        bulletPos = transform.position;


        

        if (turnedD)
        {
            
            bulletPos += new Vector2(-0f, -1.3f);
            Instantiate(attD, bulletPos, Quaternion.identity);
           

        }

        if (turnedU)
        {

            bulletPos += new Vector2(-0.3f, 1f);
            Instantiate(attU, bulletPos, Quaternion.identity);


        }
        if (turnedR)
        {

            bulletPos += new Vector2(1f, 0.5f);
            Instantiate(attP, bulletPos, Quaternion.identity);


        }
        if (turnedL)
        {

            bulletPos += new Vector2(-1f, -0.3f);
            Instantiate(attL, bulletPos, Quaternion.identity);


        }
    }

}
