using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBehaviour : MonoBehaviour
{
    [SerializeField]
    private IntReference PlanetPool;
    [SerializeField]
    private IntReference TrashPool;
    [SerializeField]
    private IntReference MinItemValue;
    [SerializeField]
    private IntReference MaxItemValue;
    [SerializeField]
    private FloatReference DragSpeed;
    [SerializeField]
    private GameEvent ThrownToPlanet;
    [SerializeField]
    private GameEvent ThrownToTrash;
    [SerializeField]
    private Sprite[] itemSprites;
    private Rigidbody2D rb;
    private Vector3 originalPosition;
    private int itemValue;
    private bool moveAllowed = false;
    private bool touchingPlanet;
    private bool touchingTrash;
    private bool timeOut;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalPosition = rb.position;
        itemValue = Random.Range(MinItemValue.Value, MaxItemValue.Value);
        SettingSprite();
    }

    private void OnEnable()
    {
        touchingTrash = false;
        touchingPlanet = false;
    }

    private void Update()
    {
        Touching();
    }

    #region Touch Controls
    private void Touching()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPosition))
                        moveAllowed = true;
                    break;
                case TouchPhase.Moved:
                    if (moveAllowed)
                        rb.position = Vector3.Lerp(transform.position, touchPosition, DragSpeed.Value * Time.deltaTime);
                    break;
                case TouchPhase.Ended:
                    moveAllowed = false;
                    CheckEventCollision();
                    break;
            }
        }
    }
    #endregion

    #region PC Controls
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
        CheckEventCollision();
    }
    #endregion

    #region Collisions
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

    private void CheckEventCollision()
    {
        if (touchingPlanet)
        {
            ThrownToPlanet.Raise();
            PlanetPool.Value += itemValue;
            Destroy();
        }
        else if (touchingTrash)
        {
            ThrownToTrash.Raise();
            TrashPool.Value += itemValue;
            Destroy();
        }
        else
        {
            rb.position = originalPosition;
            //GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
    #endregion

    private void SettingSprite()
    {
        switch (itemValue)
        {
            case -3:
                GetComponent<SpriteRenderer>().sprite = itemSprites[0];
                break;
            case -2:
                GetComponent<SpriteRenderer>().sprite = itemSprites[1];
                break;
            case -1:
                GetComponent<SpriteRenderer>().sprite = itemSprites[2];
                break;
            case 0:
                GetComponent<SpriteRenderer>().sprite = itemSprites[3];
                break;
            case 1:
                GetComponent<SpriteRenderer>().sprite = itemSprites[4];
                break;
            case 2:
                GetComponent<SpriteRenderer>().sprite = itemSprites[5];
                break;
            case 3:
                GetComponent<SpriteRenderer>().sprite = itemSprites[6];
                break;
        }
    }

    private void Destroy()
    {
        gameObject.SetActive(false);
    }

    public void SelfDestruct()
    {
        if (gameObject.activeInHierarchy)
        {
            if (Random.value > 0.5f)
            {
                touchingPlanet = true;
                touchingTrash = false;
            }
            else
            {
                touchingPlanet = false;
                touchingTrash = true;
            }
            CheckEventCollision();
        }
    }

}
