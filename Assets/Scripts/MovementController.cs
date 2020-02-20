using System.Collections;
using System.Collections.Generic;
/* Declaring the UnityEngine Namespace allows to work with Unity-specific classes,
such as MonoBehaviour, GameObject, Rigidbody2D, and BoxCollider2D.
 */
using UnityEngine;

//The script inherits MovementController from MonoBehaviour.
public class MovementController : MonoBehaviour
{
    /*The methods provided by the parent MonoBehaviour class are Awake(), Start(), Update(), 
    LateUpdate(), and OnCollisionEnter()  */
    
    /* set the characters movement speed. By declaring it public, the variable movementSpeed appears in the Inspector
    when the GameObject to which it is attached is selected.*/
    public float movementSpeed = 3.0f;
    /*Vector2 is a built-in data structure that holds 2D vectors or points. We’re going to use it to represent
    a Player or Enemy character’s location in 2D space or where the character is moving */
    Vector2 movement = new Vector2();
    // Declare a variable to hold a reference to the Rigidbody2D.
    Rigidbody2D rb2D;
    // Start is called before the first frame update
    private void Start()
    {
        /*The method GetComponent takes a parameter of Type, and will return the component attached to the 
        current object of that type, if one is attached. We call GetComponent<Rigidbody2D> to grab a reference to 
        the Rigidbody2D component that we attached to the PlayerObject in the Unity Editor. 
        We’re going to use this component to move the player around.*/
        rb2D = GetComponent<Rigidbody2D>();  
    }

    // Update is called once per frame, used to update game behaviors
    private void Update()
    {
        
    }

    // 5
    void FixedUpdate()
    {
        // 6
        movement.x = Input.GetAxisRaw(“Horizontal”);
        movement.y = Input.GetAxisRaw(“Vertical”);
        // 7
        movement.Normalize();
        // 8
        rb2D.velocity = movement * movementSpeed;
    }
}
