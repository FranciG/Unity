  using UnityEngine;
  //  inherit from the Character class to gain properties like hitPoints.


  public class Player : Character
  {
// we instantiate a copy of the HealthBar prefab
public HealthBar healthBarPrefab;
// store a reference to the instantiated HealthBar
HealthBar healthBar;

public void Start()
	{
    
// The Start() method will only be called once—when the script is enabled. It assigns the current hitPoints.value
hitPoints.value = startingHitPoints;
// Instantiate a copy of the Health Bar prefab and store a reference to it in memory
healthBar = Instantiate(healthBarPrefab);
healthBar.character = this;
	}


    // OnTriggerEnter2D() is called whenever this object overlaps with a trigger collider
void OnTriggerEnter2D(Collider2D collision)
{
//Examine the tag of the collided gameObject. If that tag is “CanBePickedUp” then continue execution inside the if-statement.
    if (collision.gameObject.CompareTag("CanBePickedUp"))
    {
// grab a reference to the gameObject attached to the collision
//every collision will have a GameObject that it collided with attached to the collision
//It applies to any type of GameObject with the tag, “CanBePickedUp”
//We call GetComponent() on the gameObject and pass in the Script name, “Consumable”
  Item hitObject = collision.gameObject.GetComponent<Consumable>().item;
// Check to see if the hitObject is null. If the hitObject is not null, it has been retrieved the hitObject
    if (hitObject != null)
    {
// value will be set to indicate that the object in the collision should disappear.
            bool shouldDisappear = false;
            switch (hitObject.itemType)
            {
                case Item.ItemType.COIN:
// coins the player collides with should disappear by default
                    shouldDisappear = true;
                    break;
                case Item.ItemType.HEALTH:
// The AdjustHitPoints() method will return true if the hit-points were adjusted, and false if they were not.
                    shouldDisappear = AdjustHitPoints(hitObject.quantity);
                    break;
                default:
                    break;
            }
// If AdjustHitPoints() returned true, then the prefab object should disappear.
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

}
