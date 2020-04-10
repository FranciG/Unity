using UnityEngine;
// Inherit from MonoBehaviour so we can attach this script to a GameObject
public class Consumable : MonoBehaviour {
/* When the Consumable script is added to a GameObject, we’ll assign an Item 
to the item property. This will store a reference to the Scriptable Object 
asset in the Consumable script. 
Because we’ve declared it public, it’s still accessible from other scripts. */
    public Item item;
}
