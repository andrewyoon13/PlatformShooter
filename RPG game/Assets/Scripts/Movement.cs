using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float health = 30;
    public float damage = 10;
    private Rigidbody2D rb;
    public float speed;
    private float moveInput;
    public float jumpV = 10f;
    public BoxCollider2D boxCollider2D;
    [SerializeField] private LayerMask layerMask;
    public bool isPlayer1 = false;
    public bool isPlayer2 = false;
    public bool hasKey = false;
    private Vector3 velo = Vector3.zero;
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;
    private bool faceRight = true;
    public float move;

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
        if (isGrounded() && Input.GetKeyDown(KeyCode.UpArrow)){
            rb.velocity = Vector2.up * jumpV;
    
        }

        if (isGrounded()){
            animator.SetBool("isJumping", false);
        }else if (isGrounded() == false){
            animator.SetBool("isJumping", true);
        }

        Vector3 targetVelocity = new Vector2(move * 10f, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velo, m_MovementSmoothing);
        if (Input.GetAxis("Horizontal") > 0 && faceRight){
            faceRight = !faceRight;
            transform.Rotate(0f, 180f, 0f);
        }else if (Input.GetAxis("Horizontal") < 0 && !faceRight){
            faceRight = !faceRight;
            transform.Rotate(0f, 180f, 0f);
        }


        
    }

    private bool isGrounded(){
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size,0f,Vector2.down,0.1f,layerMask);
        return raycastHit2d.collider != null;
    }

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Key")){
            Destroy(other.gameObject);
            hasKey = true;
        }

        if(other.gameObject.CompareTag("Exit")){//this is where we will load up the stat progression UI scene
            if(hasKey){
             //load in UI scene
             Debug.Log("trying to leave");
            }else 
            Debug.Log("get the key");
        }
        if(other.gameObject.CompareTag("Enemy2")){
            health = health - damage;
            if(health == 0){
                Destroy(gameObject);
                FindObjectOfType<GameManagement>().GameEnding(); //send the execution over to the GameManagement class and eventually restart the game

            }
            
        }
        if(other.gameObject.CompareTag("Bullet")){
            health = health - damage;
            if(health == 0){
                Destroy(gameObject);
                FindObjectOfType<GameManagement>().GameEnding(); //send the execution over to the GameManagement class and eventually restart the game

            }
            
        }
        if(other.gameObject.CompareTag("trap")){
            Destroy(other.gameObject);
            health-= 15;
            Debug.Log("health:" + health);
        }

    }



}
