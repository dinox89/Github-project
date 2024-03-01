using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerMovement : MonoBehaviour


{


    public ParticleSystem dust;
    

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

    [Header("Wall Jumping")]
    [SerializeField] private float wallJumpX;
    [SerializeField] private float wallJumpY;
    public Transform wallCheck;
    bool isWallTouch;
    bool isSliding;
    public float wallSlidingSpeed;

    [Header("Layers")]
    [SerializeField] public LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;

    [Header("Sounds")]
    [SerializeField] private AudioClip jumpSound;

   
        



    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;

    private float horizontalMove;
    public VariableJoystick variableJoystick;
    private float horizontalInput;

    public GameObject panel;
    public GameObject healthObject;
    public GameObject healthbarObject;
    public GameObject coin;
    public GameObject cointext;
    public GameObject joystick;
    public GameObject B;
    public GameObject Y;
    public GameObject textpanel;
    public static Vector2 lastCheckpointposition = new Vector2(17.31f, -7.71f);
    public static Vector2 lastDEB = new Vector2(17.31f, -7.71f);
    public static Vector2 lastDEBLEVEL2 = new Vector2(17.31f, -7.71f);
    public static Vector2 lastDEBLEVEL3 = new Vector2(17.31f, -7.71f);




    public GameObject pause;



    [SerializeField] private AudioClip pausesound;



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




    private void Update()
    {

        horizontalMove = variableJoystick.Horizontal * speed;
        horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalMove != 0 || horizontalInput != 0)
        {
            DUST(); // Appel de la méthode DUST()
        }


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

        isWallTouch = onWall();

        if (isWallTouch && !IsGrounded() && body.velocity.y < 0)
        {
            isSliding = true;
            body.velocity = new Vector2(body.velocity.x, -wallSlidingSpeed);
        }
        else
        {
            isSliding = false;
        }

        if (isSliding)
        {
            body.velocity = new Vector2(body.velocity.x, -wallSlidingSpeed);
        }
    }

    private IEnumerator ResetPlatformEffectorRotation(PlatformEffector2D effector)
    {
        yield return new WaitForSeconds(0.2f);
        effector.rotationalOffset = 0f;
    }

    public void Jump()
    {
        DUST();
        
        if (coyoteCounter <= 0 && !isWallTouch && jumpCounter <= 0) return;

        SoundManager.instance.PlaySound(jumpSound);

        if (isWallTouch)
            WallJump();
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
    }

    private void WallJump()
    {
        // Calcul de la direction du saut en fonction de la direction du mur
        int wallDirection = Mathf.RoundToInt(-Mathf.Sign(transform.localScale.x));

        // Calcul de la hauteur du saut en fonction de la vitesse du personnage et de la direction du mur
        float jumpHeight = Mathf.Sqrt(2 * Mathf.Abs(Physics2D.gravity.y) * jumpPower);

        // Appliquer le saut en utilisant les valeurs calculées
        body.velocity = new Vector2(wallDirection * wallJumpX, jumpHeight);
    }


    private bool onWall()
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(wallCheck.position, new Vector2(0.2f, 0.2f), 0, wallLayer);
        return colliders.Length > 0;
    }

    public bool canAttack()
    {
        return horizontalMove == 0 && IsGrounded() && !isWallTouch;
    }

    public void Pause()
    {
        SoundManager.instance.PlaySound(pausesound);
        Time.timeScale = 0;
        panel.SetActive(true);
        textpanel.SetActive(true);
        healthObject.SetActive(false);
        coin.SetActive(false);
        joystick.SetActive(false);
        B.SetActive(false);
        Y.SetActive(false);
        cointext.SetActive(false);
        healthbarObject.SetActive(false);

        pause.SetActive(false);



    }

    public void Resume()
    {
        SoundManager.instance.PlaySound(pausesound);


        Time.timeScale = 1;
        panel.SetActive(false);
        healthObject.SetActive(true);
        coin.SetActive(true);
        joystick.SetActive(true);
        B.SetActive(true);
        Y.SetActive(true);
        cointext.SetActive(true);
        healthbarObject.SetActive(true);
        pause.SetActive(true);
    }


    void DUST()
    {
        
            
                dust.Play();
               
        }
    }



