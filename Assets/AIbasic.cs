using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIbasic : MonoBehaviour
{
    public Animator anim;

    public SpriteRenderer spriteRenderer;

    public float speed = 0.5f;


    private float waitTime;

    public Transform[] movespots;


    public float startwaitTime = 1;

    private int i = 0;

    private Vector2 actualPos;

  

    private void Start()
    {
        waitTime = startwaitTime;
        anim.SetBool("Fly", true);

    }


    private void Update()
    {


        StartCoroutine(CheckEnemyMoving());

        transform.position = Vector2.MoveTowards(transform.position, movespots[i].transform.position, speed * Time.deltaTime);


        if(Vector2.Distance(transform.position,movespots[i].transform.position)< 0.1f)

        {
            if(waitTime<0)
            {
                if(movespots[i]!= movespots[movespots.Length-1])
                {
                    i++;
                }
                else
                {
                    i = 0;
                }

                waitTime = startwaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }

    }

    IEnumerator CheckEnemyMoving()
    {
        actualPos = transform.position;

        yield return new WaitForSeconds(0.5f);

        if(transform.position.x>actualPos.x)
        {
            spriteRenderer.flipX = true;
            anim.SetBool("Idle", false);

        }

        else if (transform.position.x<actualPos.x)
        {
            spriteRenderer.flipX = false;
            anim.SetBool("Idle", false);

        }

        else if(transform.position.x==actualPos.x)
        {

            anim.SetBool("Idle", true);



        }


    }



}




