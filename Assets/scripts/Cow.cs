using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow : MonoBehaviour
{
    public AnimationCurve moveCurve;

    // Creating original and end positions
    public Vector2 originalPos;
    Vector2 endPos;
    // Lerp uses 0 for the original position and 1 for end
    private float t = 0f;
    float targetT = 0f;

    void Start()
    {
        //Setting end position equal original position + 3
        endPos = originalPos;
        endPos.y += 3;
    }

    void Update()
    {
        // Get the position of the mouse on the screen and switch into world position
        Vector2 mousePos = Input.mousePosition;
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

        // Get disition of x position between mouse and caw
        float distanceX = worldPos.x - transform.position.x;

        // If the distance is less than Range, raise (targetT=1), otherwise back to original position (targetT=0)
        if ((distanceX < 2 && distanceX >0) || (distanceX < 0 && distanceX > -2))
        {
            targetT = 1f;
        }
        else
        {
            targetT = 0f;
        }
        
        // Making t changes smoothly
        t = Mathf.Lerp(t, targetT, 3 * Time.deltaTime);

        // Use AnimationCurves to calculate the current movement progress with t
        transform.position = Vector2.Lerp(originalPos, endPos, moveCurve.Evaluate(t));
        transform.Rotate(0f, 0f, 30 * t * Time.deltaTime);

    }
}

