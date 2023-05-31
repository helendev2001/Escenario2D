using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    public float fuerzaSalto = 200;
    private Rigidbody2D rigidbody2;
    private Animator animator;
    public int puntuacion = 0;
    public ControlManager gameover;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2 = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            animator.SetBool("estaSaltando",true);
            rigidbody2.AddForce(new Vector2(0,fuerzaSalto));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Suelo") {
            animator.SetBool("estaSaltando",false);
        }
       /* if (collision.gameObject.tag == "obstaculo")
        {
            gameover.Perdiste();
        }*/

    }
    void FixedUpdate()
    {
        rigidbody2.position = new Vector2(rigidbody2.position.x, Mathf.Clamp(rigidbody2.position.y, -4, 4.5f));
    }

}
