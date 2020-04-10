using UnityEngine;
using UnityEngine.UI;
public class Inventory : MonoBehaviour
{

// Store a reference to the Slot prefab
    public GameObject slotPrefab;
// Const is used so the variable does not change
    public const int numSlots = 5;
// Array to store the image components of the inventory
    Image[] itemImages = new Image[numSlots];
// Array to store references to the items on the inventory
    Item[] items = new Item[numSlots];
// Each index in the slots array will reference a single Slot prefab
    GameObject[] slots = new GameObject[numSlots];
    public void Start()
    {
     // instantiate the Slot prefabs and set up the Inventory Bar
    CreateSlots();
    }

//---

public void CreateSlots()
{
// make sure the Slot prefab is set
    if (slotPrefab != null)
    {
// Loop through the slots
        for (int i = 0; i < numSlots; i++)
        {
// Instantiate a copy of the Slot prefab and append the index number to the end
            GameObject newSlot = Instantiate(slotPrefab);
            newSlot.name = "ItemSlot_" + i;
//Set the Parent of the instantiated Slot to the child object (Inventory) at index 0 of InventoryObject
           newSlot.transform.SetParent(gameObject.transform.GetChild(0).transform);
// Assign this new Slot object to the slots array at the current index
            slots[i] = newSlot;
// The child object at index 1 of the Slot is an ItemImage. We retrieve the Image component from that ItemImage child and assign it to the itemImages array. 
            itemImages[i] = newSlot.transform.GetChild(1).GetComponent<Image>();
        }
    }
}

// AddItem will take a single parameter of type Item to add the item to the Inventory
// returns a bool indicating if the item was successfully added to the Inventory
public bool AddItem(Item itemToAdd)
{
// Loop  through the items array
    for (int i = 0; i < items.Length; i++)
    {
// Check if item is not null, itemType equals to the ane to add to the inventory, and item is stackable
        if (items[i] != null && items[i].itemType == itemToAdd.itemType && itemToAdd.stackable == true)
        {
          // Adding to existing slot

            items[i].quantity = items[i].quantity + 1;
//creating a GameObject with the Slot script attached to it
            Slot slotScript = slots[i].gameObject.GetComponent<Slot>();
// Grab a reference to the Text object
            Text quantityText = slotScript.qtyText;
// Enable the Text object to display the quantity when adding a stackable object to a slot already containing a stackable object
            quantityText.enabled = true;
//convert int into string
            quantityText.text = items[i].quantity.ToString();
// Returns true when added successfully
            return true;
        }
// Check the index of the items array to see if the item is already there. If it’s null, a newItem will be added to the slot.
        if (items[i] == null)
        {
            // Adding to empty slot
// Instantiate a copy of the itemToAdd and assign it to the items array

            items[i] = Instantiate(itemToAdd);
// Since it is the first item of a kind added, quantity is set to 1
            items[i].quantity = 1;
// Assign the Sprite from the itemToAdd, to the Image object in the itemImages array
            itemImages[i].sprite = itemToAdd.sprite;
// Enable the itemImage and return true to indicate the itemToAdd was successfully added
            itemImages[i].enabled = true;
            return true;
        }
    }
// If neither of the two if-statements resulted in adding the itemToAdd to the Inventory, false is returned.
    return false;
}

}
