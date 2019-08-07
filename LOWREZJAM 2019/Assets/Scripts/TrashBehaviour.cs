using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBehaviour : MonoBehaviour
{
    [SerializeField]
    private IntReference TrashPool;

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
                GetComponent<SpriteRenderer>().color = Color.green;
                break;
            case var expression when (TrashPool.Value >= 5 && TrashPool.Value < 8):
                GetComponent<SpriteRenderer>().color = Color.yellow;
                break;
            case var expression when (TrashPool.Value >= 8 && TrashPool.Value < 10):
                GetComponent<SpriteRenderer>().color = Color.magenta;
                break;
            case 10:
                GetComponent<SpriteRenderer>().color = Color.red;
                break;
        }
    }
}
