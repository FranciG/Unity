
using UnityEngine;

// IEnumerator is part of the System.Collections namespace that is why import it is needed
using System.Collections;
/* generic Character class with properties common to all 
character types. */
// We’ll use the Abstract modifier in C# to indicate that this class cannot be instantiated and must be inherited by a subclass.
public abstract class Character : MonoBehaviour {
// Track characters health
    //moved toplayer class public HitPoints hitPoints;
    public float maxHitPoints;
    public float startingHitPoints;
// “virtual” keyword in C# is used to declare that classes, methods, or variables will be implemented in the current class but can also be overridden in an inheriting class
//This method will be called when the characters hit-points reach zero.

public virtual void KillCharacter()
{
    // Destroy(gameObject) will remove it from the Scene when the Character is killed
    
     Destroy(gameObject);
     }

// Set the character back to its original starting state, so it can be used again.

public abstract void ResetCharacter();
// Called by other Characters to damage the current character. Takes an amount to damage the character and a time interval
public abstract IEnumerator DamageCharacter(int damage, float interval);

//Flcker when damaged
public virtual IEnumerator FlickerCharacter()
{
// tint the sprite red
    GetComponent<SpriteRenderer>().color = Color.red;
// Yield execution for 0.1 seconds
    yield return new WaitForSeconds(0.1f);
// Change the SpriteRenderer tint back to the default color
    GetComponent<SpriteRenderer>().color = Color.white;
}

}