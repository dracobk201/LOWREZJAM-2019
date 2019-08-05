using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragBehaviour : MonoBehaviour
{
    [SerializeField]
    private FloatReference DragSpeed;
    [SerializeField]
    private GameEvent ThrownToPlanet;
    [SerializeField]
    private GameEvent ThrownToTrash;
    private float deltaX, deltaY;
    private Rigidbody2D rb;
    private Vector3 originalPosition;
    private bool moveAllowed = false;
    private bool touchingPlanet;
    private bool touchingTrash;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalPosition = rb.position;
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
                    if (moveAllowed)
                        rb.position = Vector3.Lerp(transform.position, touchPosition, DragSpeed.Value * Time.deltaTime);
                    break;
                case TouchPhase.Ended:
                    moveAllowed = false;
                    break;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals(Global.PlanetTag))
        {
            touchingPlanet = true;
            Debug.Log("A planet");
        }
        else if (collision.tag.Equals(Global.TrashTag))
        {
            touchingTrash = true;
            Debug.Log("A trash");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag.Equals(Global.PlanetTag))
        {
            touchingPlanet = false;
            Debug.Log("Not a planet");
        }
        else if (collision.tag.Equals(Global.TrashTag))
        {
            touchingTrash = false;
            Debug.Log("Not a trash");
        }
    }

    private void OnMouseDown()
    {
        Debug.Log("OnMouseDown");
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        moveAllowed = true;
    }

    private void OnMouseDrag()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (moveAllowed)
            rb.position = Vector3.Lerp(transform.position, mousePosition, DragSpeed.Value * Time.deltaTime);
    }

    private void OnMouseUp()
    {
        Debug.Log("OnMouseUp");

        moveAllowed = false;
        if (touchingPlanet)
        {
            ThrownToPlanet.Raise();
            GetComponent<SpriteRenderer>().color = Color.green;
        }
        else if (touchingTrash)
        {
            ThrownToTrash.Raise();
            GetComponent<SpriteRenderer>().color = Color.red;
        }
        else
        {
            rb.position = originalPosition;
            GetComponent<SpriteRenderer>().color = Color.white;

        }
    }

}
