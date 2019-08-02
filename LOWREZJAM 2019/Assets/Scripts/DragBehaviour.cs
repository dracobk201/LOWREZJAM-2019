using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragBehaviour : MonoBehaviour
{
    float deltaX, deltaY;
    Rigidbody2D rb;
    bool moveAllowed = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPosition))
                    {
                        deltaX = touchPosition.x - transform.position.x;
                        deltaX = touchPosition.y - transform.position.y;

                        moveAllowed = true;
                    }
                    break;
                case TouchPhase.Moved:
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPosition) && moveAllowed)
                        rb.MovePosition(new Vector2(touchPosition.x - deltaX, touchPosition.y - deltaY));
                    break;
                case TouchPhase.Ended:
                    moveAllowed = false;
                    break;
            }
        }
    }
}
