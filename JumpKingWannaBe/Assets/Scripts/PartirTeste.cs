using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartirTeste : MonoBehaviour
{
    private Collider2D coll;
    public bool isPartida;
    Animator anim;
    private SpriteRenderer sr;
    public float SpeedToBreak = 1.5f;
    public float SpeedToReturn = 2;
    private ParticleSystem ps;

    private void Start()
    {
        coll = GetComponent<Collider2D>();
        sr = GetComponent<SpriteRenderer>();
        ps = GetComponentInChildren<ParticleSystem>();
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (isPartida)
        {
            StartCoroutine(Voltar());
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            anim.SetBool("isPlayer", true);
            Debug.Log("aaaa");
            StartCoroutine(Partir());
        }
    }

    IEnumerator Partir()
    {
        Debug.Log("Partir");
        yield return new WaitForSeconds(SpeedToBreak);
        ps.Play();
        coll.enabled = false;
        sr.enabled = false;
        isPartida = true;
        anim.SetBool("isPlayer", false);

    }

    IEnumerator Voltar()
    {
        Debug.Log("Vai voltar");
        yield return new WaitForSeconds(SpeedToReturn);
        coll.enabled = true;
        sr.enabled = true;
        isPartida = false;
    }
}
