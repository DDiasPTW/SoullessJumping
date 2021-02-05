using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class PlayerMovementJumping : MonoBehaviour
{
    public GameObject player;
    private bool isPlatMove;
    //Botoes e cenas UI
    [Header("Cenas UI")]
    public GameObject[] buttons;
    public Color defaultColor;
    public Color maxColor;
    //JumpingStuff
    [Header("JumpingStuff")]
    public Vector2 jumpDirection = Vector2.up;
    private bool jumpNow = false;
    private bool normalJump = false;
    private bool jumpLeft = false;
    private bool jumpRight = false;
    //Forças
    [Header("Forces")]
    public float chargedPower = 0;
    public float chargeTimeMultiplier;
    public float maxJumpPower;
    public float minimumPower;
    public float totalForce;
    public float Force;
    public float extraGravity;
    public float lowJumpMulti;
    //Deteçao Chao
    [Header("Detecao Chao")]
    public Transform groundCheck;
    private Rigidbody2D rb;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    public float xValue;
    public float yValue;
    //Animbool
    [Header("Animation Stuff")]
    public bool isJumping;
    public bool isHolding;
    public bool isFalling;
    public bool isFallingFast;
    public bool isGrounded;
    Animator anim;
    //CHECKPOINT
    [Header("CheckPoint Stuff")]
    public int numCheck;
    public Transform checkPos;
    public Text checkText;

    [SerializeField] Image scrollBar;


    /// <summary>
    //////////////-----------------------------------------------------------------------------------------------------------------------------------------////////////////----------------------------------------------------------------
    /// </summary>
    void Start()
    {
        //PlayerStuff
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        checkPos.position = player.transform.position;
        //CheckPoints
        numCheck = 1;
        //Variaveis
        totalForce = 0;
        chargedPower = 0;
        chargeTimeMultiplier = 5;
        maxJumpPower = 25;
        minimumPower = 6;
        Force = 5;
        extraGravity = 4.5f;
        lowJumpMulti = 4f;
        jumpLeft = false; normalJump = false; jumpRight = false;
        //Cenas UI
        checkText.text = numCheck.ToString() + " x";
        scrollBar.fillAmount = 0;
    }

    
    void Update()
    {
        //Debug.Log("X: " + rb.velocity.x);
        //Debug.Log("Y: " + rb.velocity.y);
        //--------------------

        if (numCheck == 0 && Advertisement.IsReady("rewardedVideo"))
        {
            checkText.text = "Watch AD        ";
        }
        else if (numCheck > 0)
        {
            checkText.text = numCheck.ToString() + " x ";
        }
        else if (numCheck == 0 && !Advertisement.IsReady("rewardedVideo"))
        {
            checkText.text = "Preparing AD          ";
        }

        //Variáveis
        totalForce = chargedPower * Force;
        //DetetarChao
        isGrounded = Physics2D.BoxCast(groundCheck.position, new Vector2(xValue, yValue), 0, Vector2.down, groundCheckRadius, whatIsGround);
        //Cenas UI
        scrollBar.fillAmount = totalForce / maxJumpPower;
        if (scrollBar.fillAmount == 1)
        {
            scrollBar.color = maxColor;
        }
        else { scrollBar.color = defaultColor; }

        if (!isGrounded)
        {
            jumpNow = false;
            chargedPower = 0;
        }
        else
        {
            isJumping = false;
            isFalling = false;  
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (chargedPower == 0)
        {
            isHolding = false;
            if (isGrounded && !isFallingFast)
            {
                anim.SetBool("isIdle", true);
            }
        }


        //Funcoes 
        Anim();
        Jump();
        Gravity();
    }

    //Animação
    void Anim()
    {
        //Holding
        if (isHolding && !isJumping && !isFalling && !isFallingFast)
        {
            anim.SetBool("isHolding" , true);
            anim.SetBool("isIdle" , false);
            anim.SetBool("isJumping" , false);
            anim.SetBool("isFalling" , false);
            anim.SetBool("isFallingFast" , false);   
        }
        //Jump
        else if (isJumping && !isHolding && !isFalling && !isFallingFast)
        {
            anim.SetBool("isHolding", false);
            anim.SetBool("isIdle", false);
            anim.SetBool("isJumping", true);
            anim.SetBool("isFalling", false);
            anim.SetBool("isFallingFast", false);
        }
        //Falling
        else if (isFalling && !isHolding && !isFallingFast && !isJumping)
        {
            anim.SetBool("isHolding", false);
            anim.SetBool("isIdle", false);
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", true);
            anim.SetBool("isFallingFast", false);
        }
        //Fucinho
        else if (isFallingFast && !isHolding && !isJumping && !isFalling && isGrounded)
        {
            anim.SetBool("isHolding", false);
            anim.SetBool("isIdle", false);
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", false);
            anim.SetBool("isFallingFast", true);
        }
        //Idle
        else
        {
            anim.SetBool("isHolding", false);
            anim.SetBool("isIdle", true);
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", false);
            anim.SetBool("isFallingFast", false);
        }

    }

    void Jump()
    {
        if (Input.touchCount <= 1)
        {
            //Jump
            if (CrossPlatformInputManager.GetButtonDown("Jump") && isGrounded)
            {
                isHolding = true;
                isFallingFast = false;
                
            }
            if (CrossPlatformInputManager.GetButton("Jump") && isGrounded)
            {
                chargedPower += chargeTimeMultiplier * Time.deltaTime;
                isHolding = true;
            }
            if (CrossPlatformInputManager.GetButtonUp("Jump"))
            {
                normalJump = true; jumpLeft = false; jumpRight = false;
                jumpNow = true;
                isHolding = false;
            }
            //JumpL
            if (CrossPlatformInputManager.GetButtonDown("JumpL") && isGrounded)
            {
                isHolding = true;
                isFallingFast = false;
            }
            if (CrossPlatformInputManager.GetButton("JumpL") && isGrounded)
            {
                chargedPower += chargeTimeMultiplier * Time.deltaTime;
                isHolding = true;
            }
            if (CrossPlatformInputManager.GetButtonUp("JumpL"))
            {
                jumpLeft = true; normalJump = false; jumpRight = false;
                jumpNow = true;
                isHolding = false;
            }
            //JumpR
            if (CrossPlatformInputManager.GetButtonDown("JumpR") && isGrounded)
            {
                isHolding = true;
                isFallingFast = false;
            }
            if (CrossPlatformInputManager.GetButton("JumpR") && isGrounded)
            {
                chargedPower += chargeTimeMultiplier * Time.deltaTime;
                isHolding = true;
            }
            if (CrossPlatformInputManager.GetButtonUp("JumpR"))
            {
                jumpRight = true; normalJump = false; jumpLeft = false;
                jumpNow = true;
                isHolding = false;
            }
            //------------------------------------
            if (normalJump)
            {
                jumpDirection = Vector2.up;
            }
            else if (jumpLeft)
            {
                jumpDirection = new Vector2(-0.5f, 1);
            }
            else
            {
                jumpDirection = new Vector2(0.5f, 1);
            }

            if (rb.velocity.x < 0 && !isGrounded)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
            else if(rb.velocity.x > 0 && !isGrounded)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
        }
        else
        {
            totalForce = 0;
            chargedPower = 0;
        }

        //------------------------------------------

        // CHECKPOINTS
        if (CrossPlatformInputManager.GetButtonUp("CheckPoint") && isGrounded && numCheck > 0 && !isPlatMove)
        {
            checkPos.transform.position = player.transform.position;
            checkPos.localRotation = player.transform.localRotation;
            numCheck--;
            checkText.text = numCheck.ToString() + " x ";
        }
        if (CrossPlatformInputManager.GetButtonUp("CheckPointTP") && isGrounded)
        {
            player.transform.parent = null;
            player.transform.position = checkPos.position;
            isFallingFast = false;
            isHolding = false;
            isJumping = false;
            isFalling = false;
        }
    }


    /// <summary>
    /// 
    /// </summary>

    void Gravity()
    {
        if (rb.velocity.y < 0 && !isGrounded) // se tiver a cair/descer
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * extraGravity * Time.deltaTime;
            isFalling = true;
            isJumping = false;
            isFallingFast = false;
            if (rb.velocity.y <= -40)
            {
                isFallingFast = true;
                isFalling = false;
                isJumping = false;
            }
        }
        else if (rb.velocity.y > 0 && !isGrounded) // se tiver a subir/saltar
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * lowJumpMulti * Time.deltaTime;
            isJumping = true;
            isFallingFast = false;
            isFalling = false;
            isHolding = false;
        }
        else if (rb.velocity.y == 0)
        {
            isJumping = false;
            isFalling = false;
        }
    }


    /// <summary>
    /// ////////////////////////////////////////////
    /// </summary>

    private void FixedUpdate()
    {
        if (jumpNow)
        {
            normalJump = false; jumpLeft = false; jumpRight = false;
            if (totalForce >= maxJumpPower)
            {
                totalForce = maxJumpPower;
                rb.AddForce(jumpDirection * totalForce, ForceMode2D.Impulse);
                chargedPower = 0;
                isHolding = false;
                jumpNow = false;
            }
            else if (totalForce <= minimumPower && totalForce != 0)
            {
                totalForce = minimumPower;
                rb.AddForce(jumpDirection * totalForce, ForceMode2D.Impulse);
                chargedPower = 0;
                isHolding = false;
                jumpNow = false;
            }
            else if(totalForce == 0)
            {
                rb.AddForce(jumpDirection * totalForce, ForceMode2D.Impulse);
                chargedPower = 0;
                isHolding = false;
                jumpNow = false;
            }
            else
            {
                rb.AddForce(jumpDirection * totalForce, ForceMode2D.Impulse);
                chargedPower = 0;
                isHolding = false;
                jumpNow = false;             
            }
        }
    }


    /////////////////////////////////////////////////////////////////


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Moving"))
        {
            player.transform.parent = other.gameObject.transform;
            buttons[3].SetActive(false);
            isPlatMove = true;
        }  
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Moving"))
        {
            player.transform.parent = null;
            buttons[3].SetActive(true);
            isPlatMove = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Reset")
        {
            player.transform.position = checkPos.transform.position;
        }

        if (other.gameObject.CompareTag("CP"))
        {
            checkPos.transform.position = player.transform.position;
            checkPos.localRotation = player.transform.localRotation;
            Destroy(other.gameObject);
        }
    }

    /// <summary>
    /// ----------------------------------------
    /// </summary>
    private void OnDrawGizmos()
    {
        //Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        if (isGrounded)
        {
            Gizmos.color = new Color(0, 1, 0, 0.5f);
        }
        else
        {
            Gizmos.color = new Color(1, 0, 0, 0.5f);
        }

        Gizmos.DrawCube(groundCheck.position, new Vector2(xValue, yValue));
    }
}
