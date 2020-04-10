using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RPGGameManager : MonoBehaviour
{
public RPGCameraManager cameraManager;

    // playerSpawnPoint property will hold a reference to the Spawn Point specifically designated for the player
    public SpawnPoint playerSpawnPoint;
// A static variable: sharedInstance is used to access the Singleton
    public static RPGGameManager sharedInstance = null;
    void Awake()
    {
// Check if sharedInstance is already initialized and not equal to this current instance
//There should be only one instance of RPGGameManager
        if (sharedInstance != null && sharedInstance != this)
        {
// If sharedInstance is initialized and not equal to the current instance, then destroy it
            Destroy(gameObject);
        }
        else
        {
// assign the one sharedInstance variable to the current object
            sharedInstance = this;
        }
    }
    void Start()
    {
// Create the method SetupScene to call all the logic
        SetupScene();
    }
// The method to be called
    public void SetupScene()
    {
     // invoke the SpawnPlayer() method
     SpawnPlayer();
    }

public void SpawnPlayer()
{
// Check if the playerSpawnPoint property is not null before try to use it
    if (playerSpawnPoint != null)
    {
// Call the SpawnObject() method on the playerSpawnPoint.SpawnObject to Spawn the player.
        GameObject player = playerSpawnPoint.SpawnObject();
 
    cameraManager.virtualCamera.Follow = player.transform;
    
    }



}

}
