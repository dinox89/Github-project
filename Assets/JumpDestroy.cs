using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpDestroy : MonoBehaviour
{
    public Collider2D col2D;

    public Animator anim;

    public SpriteRenderer spriteRenderer;


    public GameObject destroyParticule;

    public float jumpForce = 2f;

    public int lifes = 2;




    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = (Vector2.up * jumpForce);
            LosseLifeandHit();
            CheckLife();
        }
    }

    public void LosseLifeandHit()
    {
        lifes--;
        anim.Play("Hit");
    }


    public void CheckLife()
    {
        if(lifes==0)
        {
            destroyParticule.SetActive(true);
            spriteRenderer.enabled = false;
            Invoke("EnemyDie", 0.2f);
        }
    }

    public void EnemyDie()
    {
        Destroy(gameObject);
    }

}
