using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ladder : MonoBehaviour
{
    public bool isInRange;
    private PlayerMovement playerMovement;
    public BoxCollider2D collider ;

    void Awake()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Archer").GetComponent<PlayerMovement>();
        
    }

  
      void Update()
    {
        if( Input.GetKeyDown(KeyCode.E) && isInRange )
        {
            playerMovement.isClimbing = true;
            collider.isTrigger = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Archer"))
        {
            isInRange = true;
        }
    }

     private void OnTriggerExit2D(Collider2D collision)
     {
         if (collision.CompareTag("Archer"))
        {
            isInRange = false;
            playerMovement.isClimbing = false;
            collider.isTrigger = false ;
        }
     }
  


}
