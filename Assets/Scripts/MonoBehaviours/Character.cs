
using UnityEngine;
/* generic Character class with properties common to all 
character types. */
// We’ll use the Abstract modifier in C# to indicate that this class cannot be instantiated and must be inherited by a subclass.
public abstract class Character : MonoBehaviour {
// Track characters health
    public HitPoints hitPoints;
    public float maxHitPoints;
    public float startingHitPoints;
}