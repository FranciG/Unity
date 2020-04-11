  using UnityEngine;
  //  inherit from the Character class to gain properties like hitPoints.
using System.Collections;

  public class Player : Character
  {
//Store a reference to the Inventory prefab
//public Inventory inventoryPrefab;
//Used to store a reference to the Inventory once it’s instantiated
//Inventory inventory;
// we instantiate a copy of the HealthBar prefab
public HealthBar healthBarPrefab;
// store a reference to the instantiated HealthBar
HealthBar healthBar;

public HitPoints hitPoints;
private void OnEnable()
    {
        ResetCharacter();
    }
/*
public void Start()
	{
 
// The Start() method will only be called once—when the script is enabled. It assigns the current hitPoints.value
hitPoints.value = startingHitPoints;

	}
*/

    // OnTriggerEnter2D() is called whenever this object overlaps with a trigger collider
void OnTriggerEnter2D(Collider2D collision)
{

   
//Examine the tag of the collided gameObject. If that tag is “CanBePickedUp” then continue execution inside the if-statement.

if (collision.gameObject.CompareTag("CanBePickedUp"))
        {
            Item hitObject = collision.gameObject.GetComponent<Consumable>().item;

            if (hitObject != null)
            {
                bool shouldDisappear = false;

                switch (hitObject.itemType)
                {
                    case Item.ItemType.COIN:
                       // shouldDisappear = inventory.AddItem(hitObject);
                        break;
                    case Item.ItemType.HEALTH:
                        shouldDisappear = AdjustHitPoints(hitObject.quantity);
                        break;
                    default:
                        break;
                }

                if (shouldDisappear)
                {
                    collision.gameObject.SetActive(false);
                }
            }
        }

}

// The AdjustHitPoints() method will return type: bool, indicating if hitPoints was successfully adjusted.
public bool AdjustHitPoints(int amount)
{
// Check if the current hit-points are less than the maximum allowed hit-points.
    if (hitPoints.value < maxHitPoints)
    {
// Adjust the player’s current hitPoints by amount
        hitPoints.value = hitPoints.value + amount;
// Print out to help in debugging
        print("Adjusted HP by: " + amount + ". New value: " + hitPoints.value);
// Return true to indicate that the hit-points were adjusted and false if not.
        return true;
    }

    return false;
}


// Implement the DamageCharacter() method as done on the enemy class
public override IEnumerator DamageCharacter(int damage, float interval)
{
    while (true)
    {
        hitPoints.value = hitPoints.value - damage;
        if (hitPoints.value <= float.Epsilon)
        {
            KillCharacter();
            break;
        }
        if (interval > float.Epsilon)
        {
            yield return new WaitForSeconds(interval);
        }
        else
        {
            break;
        }
    }
}

public override void KillCharacter()
{
//  base keyword refeers to the parent or “base” class that the current class inherits from (character)
    base.KillCharacter();
//Destroy healthbar
    Destroy(healthBar.gameObject);
    //Destroy(inventory.gameObject);
}

public override void ResetCharacter()
{
// Instantiate a copy of the Health Bar prefab and store a reference to it in memory
    //inventory = Instantiate(inventoryPrefab);
    healthBar = Instantiate(healthBarPrefab);
    healthBar.character = this;
// Set the hit-points of the Player to the starting hit-points value
    hitPoints.value = startingHitPoints;
}


}
