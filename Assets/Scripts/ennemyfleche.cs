using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ennemyfleche : EnnemyDamage
{

    [SerializeField] private float speed;
    [SerializeField] private float resetTime;
    private float lifetime;





    public void ActivateProjectile()
    {
        lifetime = 0;
        gameObject.SetActive(true);
    }


    private void Update()
    {
        float movementSpeed = speed * Time.deltaTime;
        transform.Translate(movementSpeed, 0, 0);



        lifetime += Time.deltaTime;
        if (lifetime > resetTime)
            gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
