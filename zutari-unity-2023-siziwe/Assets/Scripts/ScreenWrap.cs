using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrap : MonoBehaviour
{
    private Camera mainCamera;
    private float objectWidth;
    private float objectHeight;

    private void Start()
    {
        mainCamera = Camera.main;

        // Get values for width and height of the object's renderer bounds
        objectWidth = GetComponent<Renderer>().bounds.size.x;
        objectHeight = GetComponent<Renderer>().bounds.size.y;
    }

    private void Update()
    {
        WrapObject(); //Check if cube has moved outside the camera view
    }

    private void WrapObject()
    {
        Vector3 viewPos = mainCamera.WorldToViewportPoint(transform.position);

        if (viewPos.x < 0)
        {
            viewPos.x = 1;
        }
        else if (viewPos.x > 1)
        {
            viewPos.x = 0;
        }

        if (viewPos.y < 0)
        {
            viewPos.y = 1;
        }
        else if (viewPos.y > 1)
        {
            viewPos.y = 0;
        }

        transform.position = mainCamera.ViewportToWorldPoint(viewPos);
    }
}
