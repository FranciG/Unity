using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* Declaring the UnityEngine Namespace allows to work with Unity-specific classes,
such as MonoBehaviour, GameObject, Rigidbody2D, and BoxCollider2D. */
public class MovementController : MonoBehaviour
//The script inherits MovementController from MonoBehaviour.
/*The methods provided by the parent MonoBehaviour class are Awake(), Start(), Update(), 
   LateUpdate(), and OnCollisionEnter()  */
{
    /* set the characters movement speed. By declaring it public, the variable movementSpeed appears in the Inspector
   when the GameObject to which it is attached is selected.*/
    public float movementSpeed = 3.0f;
    
    /*Vector2 is a built-in data structure that holds 2D vectors or points. It is used to represent
  a Player or Enemy character’s location in 2D space or where the character is moving */
    Vector2 movement = new Vector2();

    // Variable used to store a reference to the Animator component in the GameObject
    Animator animator;

    
    string animationState = "AnimationState";
    // Declare a variable to hold a reference to the Rigidbody2D.
    Rigidbody2D rb2D;


    //a set of enumerated constants used it to map the various states of a character with a corresponding int
    //to set the Animation State
    enum CharStates
    {
        walkEast = 1,
        walkSouth = 2,
        walkWest = 3,
        walkNorth = 4,

        idleSouth = 5
    }
    // Start is called before the first frame update
    private void Start()
    {
        //  GetComponent used for accessing components from within the script
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame, used to update game behaviors
    private void Update()
    {
        // Call the method to update the animation state machine
        UpdateState();
    }
    // FixedUpdate() is called at fixed intervals by the Unity Engine, not once per frame as the update() method.
    void FixedUpdate()
    {
        // Call the method to move the character
        MoveCharacter();
    }

    private void MoveCharacter()
    {
        /*The Input class gives several methods to capture user input.Here is captured 
        by using the method GetAxisRaw()
       and assign the values to the x and y values of the Vector2 structure. */
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        
        //  keep the player moving at the same rate of speed for every direction
        movement.Normalize();
        // set the velocity of the Rigidbody2D attached to the PlayerObject and move it.
        rb2D.velocity = movement * movementSpeed;
    }

    /*A series of if-else-if statements will determine if a call to Input.GetAxisRaw() returns a -1, 0, or 1,
    and move the character accordingly.*/
    private void UpdateState()
    {
        
        if (movement.x > 0)
        { // call the SetInteger() method  to set the value of the Animation Parameters
          //If movement.x is greater than 0, walkWest is called
            animator.SetInteger(animationState, (int)CharStates.walkEast);
        }
        else if (movement.x < 0)
        {   
            
            animator.SetInteger(animationState, (int)CharStates.walkWest);
        }
        else if (movement.y > 0)
        {
            animator.SetInteger(animationState, (int)CharStates.walkNorth);
        }
        else if (movement.y < 0)
        {
            animator.SetInteger(animationState, (int)CharStates.walkSouth);
        }
        else
        {
            animator.SetInteger(animationState, (int)CharStates.idleSouth);
        }
    }
}
