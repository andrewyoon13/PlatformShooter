using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    private float moveInput;
    public float jumpV = 10f;
    public BoxCollider2D boxCollider2D;
    [SerializeField] private LayerMask layerMask;
    public bool isPlayer1 = false;
    public bool isPlayer2 = false;

    public Animator animator; 
    

    void Start(){
        rb = transform.GetComponent<Rigidbody2D>();
        boxCollider2D = transform.GetComponent<BoxCollider2D>();
    }

    void FixedUpdate(){
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        animator.SetFloat("Speed", Mathf.Abs(moveInput));
    }

    void Update(){
        if (isGrounded() && Input.GetKeyDown(KeyCode.Space)){
            rb.velocity = Vector2.up * jumpV;
    
        }

        if (isGrounded()){
            animator.SetBool("isJumping", false);
        }else if (isGrounded() == false){
            animator.SetBool("isJumping", true);
        }

        Vector3 playerScale = transform.localScale;
        if (Input.GetAxis("Horizontal") > 0 && isPlayer1){
            playerScale.x = -1;
        }else if (Input.GetAxis("Horizontal")<0 && isPlayer1){
            playerScale.x = 1;
        }

        if (Input.GetAxis("Horizontal") < 0 && isPlayer2){
            playerScale.x = -3;
        }else if (Input.GetAxis("Horizontal")>0 && isPlayer2){
            playerScale.x = 3;
        }

        
        transform.localScale = playerScale;
        
       
    }

    private bool isGrounded(){
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size,0f,Vector2.down,0.1f,layerMask);
        return raycastHit2d.collider != null;
    }

    


}
