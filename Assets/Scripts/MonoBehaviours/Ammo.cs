using UnityEngine;
public class Ammo : MonoBehaviour
{
// amount of damage
    public int damageInflicted;
// Called when another object enters the Trigger Collider
    void OnTriggerEnter2D(Collider2D collision)
    {
// check if we hit the BoxCollider2D inside the enemy
if (collision is BoxCollider2D)
        {
// Retrieve the Enemy script component of the gameObject from the collision
            Enemy enemy = collision.gameObject.GetComponent<Enemy>();
// Start the Coroutine to damage the Enemy.
//Parameters: the amount of damage and damage interval (time to wait between inflicting damage)
//Interval = 0 will inflict damage a single time.
//damageInflicted is set in Unity editor
            StartCoroutine(enemy.DamageCharacter(damageInflicted, 0.0f));
// Because the ammo has struck the Enemy, set the gameObject of the AmmoObject to be inactive.
            gameObject.SetActive(false);
        }
    }
}
