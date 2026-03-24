using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ClickToMove : MonoBehaviour
{
    public LineRenderer lr;
    public List<Vector2> points;
    void Start()
    {
        points = new List<Vector2>();
        points.Add(transform.position);

        UpdateLineRenderer();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            //add a new point to the line
            Vector2 newPost = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            points.Add(newPost);
            UpdateLineRenderer();
            //sets the new point as the mouse position
        }

        if (Mouse.current.rightButton.wasPressedThisFrame)
        {
            points.RemoveAt(0);
            UpdateLineRenderer();
        }

    }

    void UpdateLineRenderer()
    {
        lr.positionCount = points.Count;
        for (int i = 0; i < points.Count; i++)
        {
            lr.SetPosition(i, points[i]);
        }
    }
}
