using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBehaviour : MonoBehaviour
{
    [SerializeField]
    private IntReference TrashPool;
    [SerializeField]
    private Sprite[] statusSprites;

    private void Start()
    {
        TrashPool.Value = 0;
        ChangeTrashState();
    }

    public void ChangeTrashState()
    {
        switch (TrashPool.Value)
        {
            case var expression when (TrashPool.Value >= 0 && TrashPool.Value < 5):
                GetComponent<SpriteRenderer>().sprite = statusSprites[0];
                break;
            case var expression when (TrashPool.Value >= 5 && TrashPool.Value < 8):
                GetComponent<SpriteRenderer>().sprite = statusSprites[1];
                break;
            case var expression when (TrashPool.Value >= 8 && TrashPool.Value <= 10):
                GetComponent<SpriteRenderer>().sprite = statusSprites[2];
                break;
        }
    }
}
