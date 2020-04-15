// using Coroutines and IEnumerator in the Wander algorithm
using System.Collections;
using UnityEngine;
// Ensure that the GameObject using the Wander script has these components necessary for the Wander script.
//By using RequireComponent, any GameObject with this script is attached will automatically have the required components if it not already present.
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Animator))]
public class Wander : MonoBehaviour
{
    // variables used to set the speed at which the Enemy pursues the Player
    public float pursuitSpeed;
    public float wanderSpeed;
    float currentSpeed;
// how often the Enemy should change direction
    public float directionChangeInterval;
// The followPlayer flag can be set to turn on and off the player-chasing behavior
    public bool followPlayer;
// Coroutine will be responsible for moving the Enemy a little bit each frame, toward the destination
    Coroutine moveCoroutine;
// The RigidBody2D and Animator attached to the GameObject.
    Rigidbody2D rb2d;
    Animator animator;
//  The script will retrieve the transform from the PlayerObject and assign it to targetTransform 
    Transform targetTransform = null;
// destination where the Enemy is wandering
    Vector3 endPosition;
// When choosing a new direction to wander, a new angle is added to the existing angle
//used to generate a vector, which becomes the destination.
    float currentAngle = 0;

void Start()
    {
// Grab and cache the Animator component attached to the GameObject
        animator = GetComponent<Animator>();
// Setting currentSpeed to wanderSpeed
        currentSpeed = wanderSpeed;
//  Store a reference to the Rigidbody2D to move the enemy
        rb2d = GetComponent<Rigidbody2D>();
// Start the WanderRoutine() Coroutine
        StartCoroutine(WanderRoutine());
    }

// WanderRoutine() Coroutine
public IEnumerator WanderRoutine()
{
// While true the enemy will wander
    while (true)
    {
// Method chooses a new endpoint 
        ChooseNewEndpoint();
//Check if the Enemy is already moving by checking if moveCoroutine is null or has a value


        if (moveCoroutine != null)
        {
//If it has a value the Enemy is moving, so needs to stop before moving in a new direction.
            StopCoroutine(moveCoroutine);
        }
// Start the Move() Coroutine and save a reference to it in moveCoroutine
        moveCoroutine = StartCoroutine(Move(rb2d, currentSpeed));
// Yield execution of the Coroutine for directionChangeInterval seconds, then start the loop again choosing a new endpoint.
        yield return new WaitForSeconds(directionChangeInterval);
    }
}

// by omitting the access modifier the method is private. Its only used inside the Wander class.

void ChooseNewEndpoint()
{
// Choose a random value between 0 and 360 for a new direction (angle, in degrees) to travel.
//New angle is added to the current angle
    currentAngle += Random.Range(0, 360);
// Mathf.Repeat(currentAngle, 360) will loop the value: currentAngle to keep it smaller than 0, and never bigger than 360
    currentAngle = Mathf.Repeat(currentAngle, 360);
// convert an Angle to a Vector3 and add the result to the endPosition
// endPosition will be used by the Move() Coroutine
    endPosition += Vector3FromAngle(currentAngle);
}

Vector3 Vector3FromAngle(float inputAngleDegrees)
{
//Convert the input angle from degrees to radians by multiplying by the degrees-to-radians conversion constant
    float inputAngleRadians = inputAngleDegrees * Mathf.Deg2Rad;
// Use the input angle in radians to create a normalized directional vector for the enemy direction
    return new Vector3(Mathf.Cos(inputAngleRadians), Mathf.Sin(inputAngleRadians), 0);
}

public IEnumerator Move(Rigidbody2D rigidBodyToMove, float speed)
{
//retrieve the rough distance remaining between the current position of the Enemy and the destination    
// sqrMagnitude property is a Unity-provided approach to performing quick Vector magnitude calculations
    float remainingDistance = (transform.position - endPosition).sqrMagnitude;
// Check the remaining distance between the current location and the endPosition is greater than float.Epsilon
    while (remainingDistance > float.Epsilon)
    {
// targetTransform is actually the Player’s transform, it will be constantly updated with the Players new position
//The enemy follows dynamically the player.
        if (targetTransform != null)
        {
            endPosition = targetTransform.position;
        }
// Ensure the gameobject has a RigidBody2D to move
        if (rigidBodyToMove != null)
        {
// Initiate the state transition to the walking state and play the Enemy walking animation
//Boolean parameter is set in unity animator state transition.
            animator.SetBool("isWalking", true);
// Vector3.MoveTowards method is used to calculate the movement for a RigidBody2D
//takes three parameters: a current position, an end position, and the distance to move in the frame
            Vector3 newPosition = Vector3.MoveTowards(rigidBodyToMove.position, endPosition, speed * Time.deltaTime);
// Use MovePosition() to move the RigidBody2D to the newPosition, calculated in the previous line
            rb2d.MovePosition(newPosition);
// sqrMagnitude property to update the distance remaining
            remainingDistance = (transform.position - endPosition).sqrMagnitude;
        }
// Yield execution until the next Fixed Frame update
        yield return new WaitForFixedUpdate();
    }
// Enemy reaches endPosition and waits for a new direction, the Animation State changes to idle
    animator.SetBool("isWalking", false);
}





}
