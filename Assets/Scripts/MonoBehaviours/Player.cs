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
        collision.gameObject.SetActive(false);
    }
    }
}

}
