using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Get the world position of the mouse.
        Vector3 mousePos = Input.mousePosition;
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

        // Only updatting x-coordinate, y-axis is fixed.
        transform.position = new Vector2(worldPos.x+0.6f, -3.75f);

        // Move the mouse up and down to make the light wider and narrower.
        // This is controlled by adding the y-axis of the mouse position to the scale.
        transform.localScale = new Vector2(0.4f + 0.1f * worldPos.y, 0.4f);
    }
}
