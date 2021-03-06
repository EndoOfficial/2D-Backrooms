using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        // convert mouse position into world coordinates
        Vector2 mouseScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // get direction you want to point at
        Vector2 direction = (mouseScreenPosition - (Vector2)transform.position).normalized;

        // set vector of transform directly
        transform.forward = direction;
    }
    
}
