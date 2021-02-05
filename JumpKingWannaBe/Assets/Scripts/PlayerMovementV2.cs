using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class PlayerMovementV2 : MonoBehaviour
{   
    public GameObject player;
    private bool isPlatMove;
    //Botoes e cenas UI
    [Header("Cenas UI")]
    public Button[] buttons;
    public Color maxColor;
    public Color defaultColor;
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

    void Start()
    {
        //PlayerStuff
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        checkPos.position = rb.transform.position;
        //CheckPoints
        numCheck = 1;
        //Variaveis
        chargedPower = 0;
        chargeTimeMultiplier = 5;
        maxJumpPower = 25;
        minimumPower = 6;
        Force = 5;
        extraGravity = 4.5f;
        lowJumpMulti = 4f;
        //Cenas UI
        checkText.text = numCheck.ToString() + " x";
        scrollBar.fillAmount = 0;
    }
    void Anim()
    {
        if (isGrounded && !isHolding && !isJumping && !isFalling && !isFallingFast)
        {
            anim.SetBool("isIdle", true);
            anim.SetBool("isHolding", false);
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", false);
            anim.SetBool("isFallingFast", false);
        }
        else if (isHolding)
        {
            anim.SetBool("isIdle", false);
            anim.SetBool("isHolding", true);
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", false);
            anim.SetBool("isFallingFast", false);
        }
        else if (isJumping)
        {
            anim.SetBool("isIdle", false);
            anim.SetBool("isHolding", false);
            anim.SetBool("isJumping", true);
            anim.SetBool("isFalling", false);
            anim.SetBool("isFallingFast", false);
        }
        else if (isFalling)
        {
            anim.SetBool("isIdle", false);
            anim.SetBool("isHolding", false);
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", true);
            anim.SetBool("isFallingFast", false);
        }
        else if (isFallingFast && isGrounded)
        {
            anim.SetBool("isIdle", false);
            anim.SetBool("isHolding", false);
            anim.SetBool("isJumping", false);
            anim.SetBool("isFalling", false);
            anim.SetBool("isFallingFast", true);
        }


    }

    void Update()
    {
        //FIX BUG SEGURAR E CAIR
        //if (rb.velocity.y != 0 && isHolding && totalForce > 0)
        //{
        //    totalForce = 0;
        //    //if (jumpRight)
        //    //{

        //    //    jumpRight = false;
        //    //    CrossPlatformInputManager.SetButtonUp("JumpR");
        //    //}else if (jumpLeft)
        //    //{
        //    //    totalForce = 0;
        //    //    jumpLeft = false;
        //    //    CrossPlatformInputManager.SetButtonUp("JumpL");
        //    //}
        //    //else if (normalJump)
        //    //{
        //    //    totalForce = 0;
        //    //    normalJump = false;
        //    //    CrossPlatformInputManager.SetButtonUp("Jump");
        //    //}
        //    //else
        //    //{
        //    //    normalJump = false; jumpLeft = false; jumpRight = false;
        //    //}

        //}
        //Cenas UI
        scrollBar.fillAmount = totalForce / maxJumpPower;
        if (scrollBar.fillAmount == 1)
        {
            scrollBar.color = maxColor;
        }
        else { scrollBar.color = defaultColor; }
        //Detetar Chao
        isGrounded = Physics2D.BoxCast(groundCheck.position, new Vector2(xValue,yValue), 0, Vector2.down,groundCheckRadius,whatIsGround);
        //Carregar em botões de SALTO
        if (Input.touchCount <= 1)
        {
            //Vertical
            if (CrossPlatformInputManager.GetButtonDown("Jump") && isGrounded)
            {
                isHolding = true;

            }
            if (CrossPlatformInputManager.GetButton("Jump") && isGrounded)
            {
                chargedPower += chargeTimeMultiplier * Time.deltaTime;
            }
            if (CrossPlatformInputManager.GetButtonUp("Jump") && isGrounded)
            {
                jumpDirection = Vector2.up;
                jumpNow = true;
                isHolding = false;
                chargedPower = 0;
            }
            //Esquerda
            if (CrossPlatformInputManager.GetButtonDown("JumpL") && isGrounded)
            {
                isHolding = true;
            }
            if (CrossPlatformInputManager.GetButton("JumpL") && isGrounded)
            {
                chargedPower += chargeTimeMultiplier * Time.deltaTime;
            }
            if (CrossPlatformInputManager.GetButtonUp("JumpL") && isGrounded)
            {
                jumpDirection = new Vector2(-0.5f, 1);
                jumpNow = true;
                if (rb.velocity.x != 0)
                {
                    transform.localRotation = Quaternion.Euler(0, 180, 0);
                }
                isHolding = false;
                chargedPower = 0;
            }
            //Direita
            if (CrossPlatformInputManager.GetButtonDown("JumpR") && isGrounded)
            {
                isHolding = true;
            }
            if (CrossPlatformInputManager.GetButton("JumpR") && isGrounded)
            {
                chargedPower += chargeTimeMultiplier * Time.deltaTime;
            }
            if (CrossPlatformInputManager.GetButtonUp("JumpR") && isGrounded)
            {
                jumpDirection = new Vector2(0.5f, 1);
                jumpNow = true;
                if (rb.velocity.x != 0)
                {
                    transform.localRotation = Quaternion.Euler(0, 0, 0);
                }
                isHolding = false;
                chargedPower = 0;
            }
        }
        else
        {
            totalForce = 0;
            chargedPower = 0;
        }
    }

    void Gravity()
    {
        if (rb.velocity.y < 0 && !isGrounded) // se tiver a cair/descer
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * extraGravity * Time.deltaTime;
            isFalling = true;
            isJumping = false;
            anim.SetBool("isIdle", false);
            if (rb.velocity.y < -40)
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
            isFalling = false;
            anim.SetBool("isIdle", false);
        }
        else if (rb.velocity.y == 0)
        {
            isJumping = false;
            isFalling = false;
        }
    }

    void FixedUpdate()
    {
        if (jumpNow)
        {
            if (totalForce >= maxJumpPower)
            {
                totalForce = maxJumpPower;
                rb.AddForce(jumpDirection * totalForce, ForceMode2D.Impulse);
                chargedPower = 0;
                jumpNow = false;
            }
            else if (totalForce <= minimumPower)
            {
                totalForce = minimumPower;
                rb.AddForce(jumpDirection * totalForce, ForceMode2D.Impulse);
                chargedPower = 0;
                jumpNow = false;
            }
            else
            {
                rb.AddForce(jumpDirection * totalForce, ForceMode2D.Impulse);
                chargedPower = 0;
                jumpNow = false;
            }
        }
        Gravity();
    }

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
        
        Gizmos.DrawCube(groundCheck.position, new Vector2(xValue,yValue));
    }
}
