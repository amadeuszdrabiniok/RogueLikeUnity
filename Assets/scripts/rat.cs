using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class rat : MonoBehaviour
{
    private Rigidbody2D rb;
    public Animator animator;
    public AudioSource ratScream;
    public float speed;
    public float speedknock;
    public float stoppingDistance;

    private Transform target;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        ratScream = GetComponent<AudioSource> ();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Player")
        {
            ratScream.Play();
            Destroy(gameObject);
            
        }

        if (other.transform.tag == "weapon")
        {
            
            Destroy(gameObject);
        }

    }

    

    void Update()
    {
        
        if (Vector2.Distance(transform.position, target.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            Vector3 direction = target.position - transform.position;
            animator.SetFloat("moveX", direction.x);
            animator.SetFloat("moveY", direction.y);
            animator.SetBool("moving", true);
        }

    }

    
}
