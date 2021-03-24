using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiProjecile : MonoBehaviour
{
    public float speed;

    public bool MoveRight = true;



    // Update is called once per frame
    void Update()
    {

        if (MoveRight)
        {

            transform.Translate(2 * Time.deltaTime * speed, 0, 0);
        }
        else
        {

            transform.Translate(-2 * Time.deltaTime * speed, 0, 0);

        }
    }



    void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.CompareTag("Turn"))
        {

            if (MoveRight)
            {
                MoveRight = false;
            }
            else
            {
                MoveRight = true;
            }
        }
    }

        
}


