using UnityEngine;
// Importing the UnityEngine.UI required to work with UI Elements
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
// A reference to the same HitPoints asset (a Scriptable Object) that the player prefab refers to. This data container allows to share data between the two objects automatically.
    public HitPoints hitPoints;
// a reference to the current Player object to retrieve the maxHitPoints that will be set programmatically, so it is hiden in the unity inspector to avoid confusion.
    [HideInInspector]
    //Correction: Switch from Player to Character
    public Character character;
//this will be set in the Unity Editor by dragging and dropping 
    public Image meterImage;

    public Text hpText;
// cache a local variable of max hitpints
    float maxHitPoints;
    void Start()
    {
// Retrieve and store the maximum hit-points for the Character.
        maxHitPoints = character.maxHitPoints;
    }
    void Update()
    {
// Check to make sure the reference to character is not null before doing anything with it
        if (character != null)
        {
// convert the current hit-points into a percentage
            meterImage.fillAmount = hitPoints.value / maxHitPoints;
// Modify the HPText Text property to show the hit-points remaining as a whole number
            hpText.text = "HP:" + (meterImage.fillAmount * 100);
        }
    }
}
