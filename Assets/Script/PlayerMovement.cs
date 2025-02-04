using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class PlayerMovement : MonoBehaviour
{
    bool canMove;
    Vector3 offset;
    public float minX, minY, maxX, maxY;
    public GameObject boundaryObject;
    SpriteRenderer spriteRenderer;
    Vector2 spriteSize;
    Rigidbody2D rb;

    void Start()
    {   
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        if (spriteRenderer != null)
        {
            spriteSize = spriteRenderer.bounds.size;
            Debug.Log("Sprite Size: " + spriteSize);
        }
        else
        {
            Debug.LogError("No SpriteRenderer Found");
        }
        Debug.Log(boundaryObject.name);
        if(boundaryObject != null)
        {
            CalculateBoundary();
        }
        else
        {
            Debug.LogError("Boundary Object not assigned!");
        }
    }

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
            rb.MovePosition(newPosition);
        }

        if (Input.GetMouseButtonUp(0)) // Release mouse
        {
            canMove = false;
        }

    }

    void CalculateBoundary()
    {
        SpriteRenderer boundarySprite = boundaryObject.GetComponent<SpriteRenderer>();

        if (boundarySprite != null)
        {
            Bounds boundaryBounds = boundarySprite.bounds;
            minX = boundaryBounds.min.x + spriteSize.x / 2;
            maxX = boundaryBounds.max.x - spriteSize.x / 2;
            minY = boundaryBounds.min.y + spriteSize.y / 2;
            maxY = boundaryBounds.center.y - spriteSize.y / 2;
        }
    }
}
