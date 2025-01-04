using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public Vector2 input; 

    Rigidbody2D rigid;

    public float speed; 
 

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
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
}
