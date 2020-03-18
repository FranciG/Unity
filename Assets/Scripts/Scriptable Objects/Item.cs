using UnityEngine;
// CreateAssetMenu creates an entry in the Create submenu
[CreateAssetMenu(menuName = "Item")]
// Inherit from ScriptableObject, not Monobehaviour.
public class Item : ScriptableObject {
// The field: objectName, can serve a few different purposes. It will certainly come in handy for debugging, and perhaps your game will display the name of an Item in a storefront, or another game character will mention it.
    public string objectName;
// Store a reference to the Item’s Sprite, so we can display it in the game.
    public Sprite sprite;
// Keep track of the quantity of this specific Item
    public int quantity;
/* Stackable is a term used to describe how multiple copies of identical items 
can be stored in the same place and can be interacted at 
the same time. Set the boolean as stackable/not stackable. */
    public bool stackable;
// indicate the type of an item, game may have different types of coins will all be classified as the ItemType: Coin.
    public enum ItemType
    {
        COIN,
        HEALTH
    }
// Create a property called itemType using the ItemType enum.
    public ItemType itemType;
}