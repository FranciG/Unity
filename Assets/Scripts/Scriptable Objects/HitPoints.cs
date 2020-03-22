
using UnityEngine;
// creates an entry in the Create submenu, which allows us to easily create instances of the HitPoints Scriptable Object
[CreateAssetMenu(menuName = "HitPoints")]
public class HitPoints : ScriptableObject
{
// Use a float to hold the hit-points. We’ll need to assign a float to the Image object property: Fill Amount, in the Meter object of our health bar
    public float value;
}

