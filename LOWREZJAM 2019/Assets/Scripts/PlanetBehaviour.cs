using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetBehaviour : MonoBehaviour
{
    [SerializeField]
    private IntReference PlanetPool;
    [SerializeField]
    private IntReference PlanetLowAmount;
    [SerializeField]
    private IntReference PlanetMediumAmount;
    [SerializeField]
    private IntReference PlanetHeavyAmount;
    [SerializeField]
    private Sprite PlanetStatusGood;
    [SerializeField]
    private Sprite PlanetStatusMedium;
    [SerializeField]
    private Sprite PlanetStatusBad;
    [SerializeField]
    private Sprite PlanetStatusDestroyed;

    private void Start()
    {
        PlanetPool.Value = PlanetMediumAmount.Value;
        ChangePlanetState();
    }

    public void ChangePlanetState()
    {
        switch (PlanetPool.Value)
        {
            case var expression when (PlanetPool.Value < 0):
                GetComponent<SpriteRenderer>().sprite = PlanetStatusDestroyed;
                GetComponent<SpriteRenderer>().color = Color.black;
                break;
            case var expression when (PlanetPool.Value > 0 && PlanetPool.Value < PlanetLowAmount.Value):
                GetComponent<SpriteRenderer>().sprite = PlanetStatusBad;
                break;
            case var expression when(PlanetPool.Value >= PlanetLowAmount.Value && PlanetPool.Value < PlanetMediumAmount.Value):
                GetComponent<SpriteRenderer>().sprite = PlanetStatusMedium;
                GetComponent<SpriteRenderer>().color = Color.yellow;
                break;
            case var expression when (PlanetPool.Value >= PlanetMediumAmount.Value && PlanetPool.Value <= PlanetHeavyAmount.Value):
                GetComponent<SpriteRenderer>().sprite = PlanetStatusGood;
                break;
        }
    }
}
