using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBehaviour : MonoBehaviour
{
    [SerializeField]
    private IntReference TrashPool;
    [SerializeField]
    private IntReference TrashLowAmount;
    [SerializeField]
    private IntReference TrashMediumAmount;
    [SerializeField]
    private IntReference TrashHeavyAmount;
    [SerializeField]
    private Sprite TrashStatusGood;
    [SerializeField]
    private Sprite TrashStatusMedium;
    [SerializeField]
    private Sprite TrashStatusBad;

    private void Start()
    {
        TrashPool.Value = TrashMediumAmount.Value;
        ChangeTrashState();
    }

    public void ChangeTrashState()
    {
        switch (TrashPool.Value)
        {
            case var expression when (TrashPool.Value >= 0 && TrashPool.Value < TrashLowAmount.Value):
                GetComponent<SpriteRenderer>().sprite = TrashStatusBad;
                break;
            case var expression when (TrashPool.Value >= TrashLowAmount.Value && TrashPool.Value < TrashMediumAmount.Value):
                GetComponent<SpriteRenderer>().sprite = TrashStatusMedium;
                break;
            case var expression when (TrashPool.Value >= TrashMediumAmount.Value && TrashPool.Value <= TrashHeavyAmount.Value):
                GetComponent<SpriteRenderer>().sprite = TrashStatusBad;
                break;
        }
    }
}
