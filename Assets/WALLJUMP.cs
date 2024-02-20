using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class WALLJUMP : MonoBehaviour
{
    [Header("Movement Parameters")]
    [SerializeField] private float speed;
    [SerializeField] private float jumpPower;


    [Header("Moving Platform")]
    private Transform _originalParent;


    [Header("Coyote Time")]
    [SerializeField] private float coyoteTime;
    private float coyoteCounter;

    [Header("Multiple Jumps")]
    [SerializeField] private int extraJumps;
    private int jumpCounter;

    [Header("WALLLJUMP")]
    private bool isWallJumping;
    private float walljumpingDirection;
    private float walljumpingTime = 0.2f;

    private bool isWallSliding;
    private float wallSlidindSpeed = 5f;
    [SerializeField] private LayerMask wallLayer;
    [SerializeField] private Transform wallcheck;       




    [Header("Layers")]
    [SerializeField] public LayerMask groundLayer;

    [Header("Sounds")]
    [SerializeField] private AudioClip jumpSound;


    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;

    private float horizontalMove;
    public VariableJoystick variableJoystick;
    private float horizontalInput;

    public static Vector2 lastCheckpointposition = new Vector2(17.31f, -7.71f);
  



    private bool markedForPlatformRemoval = false;
    private Transform currentPlatform; // Stocke la plateforme actuelle sur laquelle le joueur est


    private void Start()
    {


        transform.position = lastCheckpointposition;


    }



    private void Awake()
    {

        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();

    }

    public bool IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);

        if (raycastHit.collider != null)
        {
            // Si le joueur est sur une plateforme, stocker la référence à la plateforme actuelle
            if (raycastHit.collider.CompareTag("MovingPlatform"))
            {
                currentPlatform = raycastHit.collider.transform;
            }
            else
            {
                currentPlatform = null; // Réinitialiser la référence si le joueur n'est pas sur une plateforme mobile
            }

            return true;
        }
        else
        {
            currentPlatform = null; // Réinitialiser la référence si le joueur n'est pas sur une plateforme
            return false;
        }
    }


    private bool IsWalled()
    {
        return Physics2D.OverlapCircle(wallcheck.position, 0.2f, wallLayer);
    }

    private void WallSlide()
    {
        if(IsWalled() && !IsGrounded() && horizontalMove !=0f)
        {
            isWallSliding = true;
            body.velocity = new Vector2(body.velocity.x, Mathf.Clamp(body.velocity.y, -wallSlidindSpeed, float.MaxValue));  
        }
        else
        {
            isWallSliding = false;
        }
    }

    private void Update()
    {

        horizontalMove = variableJoystick.Horizontal * speed;
        horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalMove > 0.01f || horizontalInput > 0.01f)


            transform.localScale = Vector3.one;



        else if (horizontalMove < -0.01f || horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);

        anim.SetBool("run", horizontalMove != 0 || horizontalInput != 0);

        anim.SetBool("grounded", IsGrounded());



        if (Input.GetKeyDown(KeyCode.Space))
            Jump();

        if (IsGrounded() && variableJoystick.Vertical < -0.5f)
        {
            Collider2D[] colliders = Physics2D.OverlapBoxAll(boxCollider.bounds.center, boxCollider.bounds.size, 0);
            foreach (Collider2D collider in colliders)
            {
                if (collider.CompareTag("OneWayPlatform"))
                {
                    PlatformEffector2D effector = collider.GetComponent<PlatformEffector2D>();
                    effector.rotationalOffset = 180f;
                    StartCoroutine(ResetPlatformEffectorRotation(effector));
                    break;
                }
            }
        }
        if (IsGrounded() && currentPlatform != null && currentPlatform.CompareTag("MovingPlatform"))
        {
            // Mettre à jour la position du joueur pour correspondre à la plateforme
            Vector3 newPosition = transform.position;
            newPosition.x += horizontalMove * Time.deltaTime;
            transform.position = newPosition;
        }



        if (Input.GetKeyUp(KeyCode.Space) && body.velocity.y > 0)
            body.velocity = new Vector2(body.velocity.x, body.velocity.y / 2);

        else
        {
            body.gravityScale = 7;
            body.velocity = new Vector2((horizontalMove + horizontalInput * speed) * speed, body.velocity.y);

            if (IsGrounded())
            {
                coyoteCounter = coyoteTime;
                jumpCounter = extraJumps;
            }
            else
            {
                coyoteCounter -= Time.deltaTime;

                if (variableJoystick.Vertical < -0.5f)
                {
                    body.velocity = new Vector2(body.velocity.x, -speed);
                }
            }
        }

       
    }

    private IEnumerator ResetPlatformEffectorRotation(PlatformEffector2D effector)
    {
        yield return new WaitForSeconds(0.2f);
        effector.rotationalOffset = 0f;
    }

    private void Jump()
    {
        if (coyoteCounter <= 0 && jumpCounter <= 0) return;

    
      
        else
        {
            if (IsGrounded())
            {
                body.velocity = new Vector2(body.velocity.x, jumpPower);
            }
            else
            {
                if (coyoteCounter > 0)
                {
                    body.velocity = new Vector2(body.velocity.x, jumpPower);
                }
                else
                {
                    if (jumpCounter > 0)
                    {
                        body.velocity = new Vector2(body.velocity.x, jumpPower);
                        jumpCounter--;
                    }
                }
            }

            coyoteCounter = 0;
        }


    }



    public void JumpButtonPressed()
    {
        Jump();
        WallSlide();


    }





    public bool canAttack()
    {
        return horizontalMove == 0 && IsGrounded() ;
    }

   
    }

   








