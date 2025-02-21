using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class player : MonoBehaviour
{
    public Vector2 input;
    public float speed;
    Rigidbody2D rigid;
    public Scaner scanner;
   
    SpriteRenderer spriter;
    Animator anim;
    

    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        scanner = GetComponent<Scaner>(); 
    }

    void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical"); 
    }

    private void FixedUpdate()
    {
        Vector2 aVecter = input.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition( rigid.position + aVecter);

    }

    void LateUpdate()
    {
        if( input.x != 0 )
        {
            spriter.flipX = input.x < 0;
        }
    }
}
