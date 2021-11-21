using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollower : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 shifted = new Vector3(mousePos.x, mousePos.y, this.transform.position.z);
        this.transform.position = shifted;

        
    }
}
