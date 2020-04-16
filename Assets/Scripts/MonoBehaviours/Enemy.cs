using UnityEngine;
using System.Collections;
// Enemy class inherits from Character so it gets access to public properties and methods in the Character class
public class Enemy : Character
{

// this variable will determine how much damage the enemy will do when it runs into the Player
public int damageStrength;
// damageCoroutine to store a reference to the DamageCharacter() Coroutine so we can stop it
Coroutine damageCoroutine;
float hitPoints;


    // overriding the KillCharacter() method from the parent character class.
public override IEnumerator DamageCharacter(int damage, float interval)
{
// loop will continue inflicting damage until the character dies, or if the interval = 0, it will break and return.
    while (true)
    {
//Start the FlickerCharacter() Coroutine from the character class when damaged
    StartCoroutine(FlickerCharacter());    
// Subtract the amount of damage inflicted from the current hitPoints and set the result to hitPoints.

        hitPoints = hitPoints - damage;
// check if the hitPoints are less than 0
//if the hitPoints are less than float.Epsilon, then the character has no health
        if (hitPoints <= float.Epsilon)
        {

            KillCharacter();
            break;
        }
// If interval is greater than float.Epsilon, then we want to yield execution, wait for interval seconds, then resume executing the while() loop
        if (interval > float.Epsilon)
        {
            yield return new WaitForSeconds(interval);
        }
        else
        {
//If interval is 0 loop will be broken, and the method will return
// The parameter interval will be zero in situations where damage is not continuous, such as a single hit
            break;
        }
    }
}
//Method to set the Character variables back to their original state
// Override the ResetCharacter() declaration in the parent character class
public override void ResetCharacter()
{
// Resetting the character, set the current hit-points to startingHitPoints
    hitPoints = startingHitPoints;
}

//OnEnable() is used to ensure that certain things occur every time an Enemy object becomes both enabled and active.

private void OnEnable()
{

    ResetCharacter();
}

// collision details are passed as the parameter: collision, into OnCollisionEnter2D()
void OnCollisionEnter2D(Collision2D collision)
{
// Compare the Tag on the object that the enemy has collided with to see if it’s the Player object
    if(collision.gameObject.CompareTag("Player"))
    {

        Player player = collision.gameObject.GetComponent<Player>();
// Check to see if this Enemy is already running the DamageCharacter() Coroutine. 
//If it is not, then start the Coroutine on the player object. 
//Pass into DamageCharacter() the damageStrength and the interval,
// because the enemy will continue to damage the player for as long as they are in contact
        if (damageCoroutine == null)
        {
            damageCoroutine = StartCoroutine(player.DamageCharacter(damageStrength, 1.0f));
        }
    }
}

// 1
void OnCollisionExit2D(Collision2D collision)
{
// 2
    if (collision.gameObject.CompareTag("Player"))
    {
// 3
        if (damageCoroutine != null)
        {
// 4
            StopCoroutine(damageCoroutine);
            damageCoroutine = null;
        }
    }
}



}
