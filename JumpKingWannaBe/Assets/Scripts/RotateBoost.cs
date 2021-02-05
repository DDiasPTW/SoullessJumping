using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBoost : MonoBehaviour
{
    private Collider2D coll;
    public bool isPartida;
    private SpriteRenderer sr;
    public GameObject gameObj;
    public float m_timer = 1.5f;
    public float SpeedToReturn;
    //private ParticleSystem ps;

    public Vector2 jumpDirection;

    public float PlayerForce;
    GameObject player;
    Rigidbody2D rb;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = player.GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        sr = GetComponent<SpriteRenderer>();
        //ps = GetComponentInChildren<ParticleSystem>();
    }
    

    void Update()
    {

        m_timer -= Time.deltaTime;
        if (m_timer <= 0.0f)
        {
            m_timer += 1.5f;
            gameObj.transform.Rotate(0.0f, 0.0f, 45.0f);
            //Debug.Log(gameObj.transform.localEulerAngles.z); 
        }


        //GET JUMP DIRECTION----------------------

        GetAngle();
        //---------------------

    }

    void GetAngle()
    {
        if (gameObj.transform.localEulerAngles.z >= 0 && gameObj.transform.localEulerAngles.z  < 45)
        {
            jumpDirection = new Vector2(0, 1);
        }
        if (gameObj.transform.localEulerAngles.z >= 45 && gameObj.transform.localEulerAngles.z < 90)
        {
            jumpDirection = new Vector2(-0.5f, 1);
        }
        if (gameObj.transform.localEulerAngles.z >= 90 && gameObj.transform.localEulerAngles.z < 135)
        {
            jumpDirection = new Vector2(-1, 0);
        }
        if (gameObj.transform.localEulerAngles.z >= 135 && gameObj.transform.localEulerAngles.z < 180)
        {
            jumpDirection = new Vector2(-0.5f, -1);
        }
        if (gameObj.transform.localEulerAngles.z >= 180 && gameObj.transform.localEulerAngles.z < 225)
        {
            jumpDirection = new Vector2(0, -1);
        }
        if (gameObj.transform.localEulerAngles.z >= 225 && gameObj.transform.localEulerAngles.z < 270)
        {
            jumpDirection = new Vector2(0.5f, -1);
        }
        if (gameObj.transform.localEulerAngles.z >= 270 && gameObj.transform.localEulerAngles.z < 315)
        {
            jumpDirection = new Vector2(1, 0);
        }
        if (gameObj.transform.localEulerAngles.z >= 315)
        {
            jumpDirection = new Vector2(0.5f, 1);
        }
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Player")
        {
            rb.AddForce(jumpDirection * PlayerForce,ForceMode2D.Impulse);
            
        }
    }


}
