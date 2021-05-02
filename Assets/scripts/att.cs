using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class att : MonoBehaviour
{
    public Animator att1;
    
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, att1.GetCurrentAnimatorStateInfo(0).length);
    }

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "enemy")
        {

            Destroy(gameObject, att1.GetCurrentAnimatorStateInfo(0).length);
            

        }

        

    }

}
