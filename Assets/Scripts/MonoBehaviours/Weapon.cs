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
}
