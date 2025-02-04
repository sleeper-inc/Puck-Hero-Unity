using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    bool canMove;
    Vector3 offset;
    public float minX, minY, maxX, maxY;

    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = transform.position.z; // Ensure z position stays the same

        if (Input.GetMouseButtonDown(0)) // Detect initial click
        {
            Bounds playerBounds = GetComponent<SpriteRenderer>().bounds;

            if (playerBounds.Contains(mousePos))
            {
                canMove = true;
                offset = transform.position - mousePos;
            }
        }

        if (Input.GetMouseButton(0) && canMove) // Drag object
        {
            Vector3 newPosition = mousePos + offset;

            newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
            newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);

            transform.position = newPosition;
        }

        if (Input.GetMouseButtonUp(0)) // Release mouse
        {
            canMove = false;
        }
    }
}