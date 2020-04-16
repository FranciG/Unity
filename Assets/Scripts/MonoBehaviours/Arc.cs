using System.Collections;
using UnityEngine;

public class Arc : MonoBehaviour
{
//  TravelArc() method will move the gameObject along an arc. 
//takes two parameters: destination and duration. 
    public IEnumerator TravelArc(Vector3 destination, float duration)
    {
//  current gameObject transform.position assigned to startPosition
        var startPosition = transform.position;
// percentComplete is used in Linear Interpolation calculation
        var percentComplete = 0.0f;
// Check that the percentComplete is less than 1.0. (equivalent to 100%)
        while (percentComplete < 1.0f)
        {
// The distance the Ammo will travel each frame is dependent on the duration
            percentComplete += Time.deltaTime / duration;
// Linear Interpolation is used to move smoothly a gameobject between two points at a constant speed
            transform.position = Vector3.Lerp(startPosition, destination, percentComplete);
// Pause execution of the Coroutine until the next frame.
            yield return null;
        }
// If the arc has reached its destination, deactivate the attached gameObject
        gameObject.SetActive(false);
    }
}