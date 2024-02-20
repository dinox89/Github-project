using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particule : MonoBehaviour
{
    [SerializeField] ParticleSystem movementparticule;
    [SerializeField] ParticleSystem fallparticule;

    [Range(0, 10)]

    [SerializeField] int occurAfterVelocity;

    [Range(0, 0.2f)]
    [SerializeField] float dust;

    [SerializeField] Rigidbody2D rb;

    float counter;
    bool isOnGround;



    void Update()
    {
        counter += Time.deltaTime;

        if(isOnGround && Mathf.Abs(rb.velocity.x) > occurAfterVelocity)
        {
            if(counter > dust)
            {
                movementparticule.Play();
                counter = 0;    
            }
        }

        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Ground"))
        {
            fallparticule.Play();
            isOnGround = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            isOnGround = false;
        }
    }
}
