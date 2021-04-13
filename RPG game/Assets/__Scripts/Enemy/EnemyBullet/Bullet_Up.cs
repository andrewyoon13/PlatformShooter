using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Up : MonoBehaviour
{


    float moveSpeed = 3.0f;

    Movement target;

    Rigidbody2D rb;

    Vector2 moveDirection;


    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();

        moveDirection = rb.transform.position * moveSpeed;

        rb.velocity = new Vector2(0, -moveDirection.y);

        Destroy(gameObject, 10f);

    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("Movement"))
        {
            Destroy(gameObject);
        }

        if(col.gameObject.CompareTag("Turn"))
        {
            Destroy(gameObject);
        }
    }

   
}
