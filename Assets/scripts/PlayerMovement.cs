using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed,jumpForce;
    private bool isJumping = false,isGrounded;
    [HideInInspector]
    public bool isClimbing;
    public Rigidbody2D rb;
    private Vector3 velocity = Vector3.zero;
    public Transform groundChekLeft, groundChekRight;
    public Animator animator;
    private bool IsJumping;
     private float verticalMovement,horizontalMovement;
    public GameObject prefab;
    
    void Update()
    // Update is called once per frame
    {
        isGrounded = Physics2D.OverlapArea(groundChekLeft.position,groundChekRight.position);
         horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
         verticalMovement = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;


        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;

            //animator.SetBool("IsJumping",true);
            float characterVelocity1 = Mathf.Abs(rb.velocity.x);
           // animator.SetFloat("Speed",characterVelocity1);
        }
        else
        {
           //animator.SetBool("IsJumping",false);   
           float characterVelocity2 = Mathf.Abs(rb.velocity.x);
          // animator.SetFloat("Speed",characterVelocity2);
      
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            GameObject arrow = Instantiate(prefab, transform.position, Quaternion.identity);
            arrow.GetComponent<Rigidbody2D>().velocity = new Vector2(10.0f, 0.0f);
        }
   


        float characterVelocity = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("Speed",characterVelocity);
      
       

    }

    void FixedUpdate()
    {
         MovePlayer(horizontalMovement,verticalMovement);
    }
    void MovePlayer(float _horizontalMovement , float _verticalMovement)
    {
        if(!isClimbing) //déplacement horizontal (sur X)
        {
            Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
            rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);
            if (isJumping)
                {
                  rb.AddForce(new Vector2(0f,jumpForce));
                  isJumping = false;
                }
        }
        else 
        {
            Vector3 targetVelocity = new Vector2(0 , _verticalMovement);
             rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);        
        }
                //déplacement vertical (sur Y)
        
    }  
}
