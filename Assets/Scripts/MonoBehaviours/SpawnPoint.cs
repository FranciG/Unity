using UnityEngine;
public class SpawnPoint : MonoBehaviour
{
// any prefab that we want to spawn once or at a consistent interval
    public GameObject prefabToSpawn;
// If we want to spawn the prefab at a regular interval
    public float repeatInterval;
    public void Start()
    {
// If the repeatInterval is greater than 0 the object should be spawned repeatedly
        if (repeatInterval > 0)
        {
// InvokeRepeating() takes three parameters: the method to call, the time to wait before invoking the first time, and the time interval to wait between invocations
            InvokeRepeating("SpawnObject", 0.0f, repeatInterval);
        }
    }
// SpawnObject() is responsible for. instantiating the prefab
//It is public, so that it can be called externally
    public GameObject SpawnObject()
    {
// Check if the prefab is set in the Unity Editor
        if (prefabToSpawn != null)
        {
// instantiate the prefab at the position of the SpawnPoint and without a rotation (done with Quaternion.identity)
            return Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
        }
// If Spawn Point is not configured properly in the editor, Return null;
        return null;
    }
}
