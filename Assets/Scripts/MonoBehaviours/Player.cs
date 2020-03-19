  using UnityEngine;
  //  inherit from the Character class to gain properties like hitPoints.
  public class Player : Character
  {
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
// To ensure that we’ve retrieved the item, print out the objectName property
        print("it: " + hitObject.objectName);

// This allows us script specific behaviors when colliding with each ItemType
                switch (hitObject.itemType)
                {
// In the case where the hitObject is of type COIN, don’t do anything just yet
                    case Item.ItemType.COIN:
                        break;
// call the method AdjustHitPoints(int amount) . This method takes a parameter of type int, which we’ll get from the hitObject property quantity.
                    case Item.ItemType.HEALTH:
                        AdjustHitPoints(hitObject.quantity);
                        break;
                    default:
                        break;
                }
        collision.gameObject.SetActive(false);
    }
    }
}

// This method will adjust the player’s hit-points by the amount in the parameter
    public void AdjustHitPoints(int amount)
    {
// Add the amount parameter to the existing hit-point count, and then assign the result to hitPoints.
        hitPoints = hitPoints + amount;
        print("Adjusted hitpoints by: " + amount + ". New value: " + hitPoints);
    }

}
