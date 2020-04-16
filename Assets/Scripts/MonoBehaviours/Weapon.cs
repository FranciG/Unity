// import System.Collections.Generic to use the List data structure
//A variable of type: List is used to represent the object pool
using System.Collections.Generic;
using UnityEngine;
// Weapon inherits from MonoBehaviour and thus can be attached to a GameObject
public class Weapon : MonoBehaviour
{
// The property ammoPrefab is set via the Unity Editor, used to instantiate copies of the AmmoObject
//that will be added to a pool of objects in the Awake() method.
    public GameObject ammoPrefab;
// property ammoPool of type: List is used to represent the object pool
    static List<GameObject> ammoPool;
// poolSize allows us to set the number of objects to be pre-instantiated in the object pool

    public int poolSize;
    public float weaponVelocity;
// The code to create the Object Pool and pre-initialize the AmmoObjects will be contained in the Awake() method 
    void Awake()
    {
// Check to see if the ammoPool object pool has been initialized already. If it has not been initialized, create a new ammoPool of type: List to hold GameObjects.
        if (ammoPool == null)
        {
            ammoPool = new List<GameObject>();
        }
// Create a loop using poolSize as the upper limit
        for (int i = 0; i < poolSize; i++)
        {
            GameObject ammoObject = Instantiate(ammoPrefab);
            ammoObject.SetActive(false);
            ammoPool.Add(ammoObject);
        }
    }

// 1
    void Update()
    {
// check if the left mouse button has been clicked and released. Parameter 0 refers to left button, 1 would be for right button

        if (Input.GetMouseButtonDown(0))
        {
// If the button is clicked, call FireAmmo(); method
            FireAmmo();
        }
    }
// retrieving and returning an AmmoObject from the object pool
    GameObject SpawnAmmo(Vector3 location)
    {
      
    
// Loop through the pool of pre-instantiated objects
        foreach (GameObject ammo in ammoPool)
        {
// Check if the current object is inactive
            if (ammo.activeSelf == false)
            {
// If is inactive, set it to active
                ammo.SetActive(true);
// pass a location to make it appear as though the AmmoObject was fired 
                ammo.transform.position = location;
// Return the active object
                return ammo;
            }
        }
// No inactive object was found, so all objects from the pool are currently being used. Return null
        return null;
    
    }
//  moving the AmmoObject from the starting location  SpawnAmmo(), to the end-position
    void FireAmmo()
    {
// convert the mouse position from Screen Space to World Space
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
// Retrieve an activated AmmoObject from the Ammo Object Pool via the SpawnAmmo() method
//Pass the current weapon’s transform.position as the starting position
        GameObject ammo = SpawnAmmo(transform.position);
// Check SpawnAmmo() returned an AmmoObject
//SpawnAmmo() returns null if all the pre-instantiated objects are already in use
        if (ammo != null)
        {
// reference the Arc component of the AmmoObject and save it to the variable arcScript.
            Arc arcScript = ammo.GetComponent<Arc>();
// travel duration for an AmmoObject
             float travelDuration = 1.0f / weaponVelocity;
// Call the TravelArc method from arcScript
            StartCoroutine(arcScript.TravelArc(mousePosition, travelDuration));
        }  
    }
// Set the ammoPool = null to destroy the Object Pool and free up memory
    void OnDestroy()
    {
        ammoPool = null;
    }



}
