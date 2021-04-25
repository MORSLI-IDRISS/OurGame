using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed,jumpForce;
    public bool isJumping = false,isGrounded;
    public Rigidbody2D rb;
    private Vector3 velocity = Vector3.zero;
    public Transform groundChekLeft, groundChekRight;
    public GameObject prefab;
    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapArea(groundChekLeft.position,groundChekRight.position);
        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isJumping = true;
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            GameObject arrow = Instantiate(prefab, transform.position, Quaternion.identity);
            arrow.GetComponent<Rigidbody2D>().velocity = new Vector2(10.0f, 0.0f);
        }
        MovePlayer(horizontalMovement);
    }
    void MovePlayer(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);
        if (isJumping)
        {
            rb.AddForce(new Vector2(0f,jumpForce));
            isJumping = false;
        }
    }
}
