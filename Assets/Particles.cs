using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour
{
    [SerializeField] ParticleSystem movementParticle;



    [Range(0, 10)]
    [SerializeField] int occurAfterVelocity;

    [Range(0, 0.2f)]
    [SerializeField] float dustFormation;


    [SerializeField] Rigidbody2D playerb;

    float counter;




    private void Update()
    {
        counter += Time.deltaTime;

        if(Mathf.Abs(playerb.velocity.x) > occurAfterVelocity)
        {

            if(counter > dustFormation)
            {
                movementParticle.Play();
                counter = 0;
            }
        }
    }

   

   
}
