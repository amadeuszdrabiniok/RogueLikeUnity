using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public Animator bullet1;
    public float velX = 5f;
    public float velY = 0f;
    Rigidbody2D rb;

    



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

     void Update()
    {
        rb.velocity = new Vector2(velX, velY);
        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "enemy")
        {
            
            bullet1.SetBool("destroyed", true);
            velX = 0f;
            velY = 0f;
            Destroy(gameObject, bullet1.GetCurrentAnimatorStateInfo(0).length);






        }

        if (other.transform.tag == "wall")
        {
            bullet1.SetBool("destroyed", true);
            velX = 0f;
            velY = 0f;
            Destroy(gameObject, bullet1.GetCurrentAnimatorStateInfo(0).length); ;

        }

    }

}
