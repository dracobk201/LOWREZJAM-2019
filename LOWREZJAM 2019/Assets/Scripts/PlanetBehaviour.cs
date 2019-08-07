using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetBehaviour : MonoBehaviour
{
    [SerializeField]
    private IntReference PlanetPool;

    private void Start()
    {
        PlanetPool.Value = 8;
        ChangePlanetState();
    }

    public void ChangePlanetState()
    {
        switch (PlanetPool.Value)
        {
            case var expression when (PlanetPool.Value < 0):
                GetComponent<SpriteRenderer>().color = Color.black;
                break;
            case var expression when (PlanetPool.Value >= 0 && PlanetPool.Value < 5):
                GetComponent<SpriteRenderer>().color = Color.red;
                break;
            case var expression when(PlanetPool.Value >= 5 && PlanetPool.Value < 8):
                GetComponent<SpriteRenderer>().color = Color.magenta;
                break;
            case var expression when (PlanetPool.Value >= 8 && PlanetPool.Value < 10):
                GetComponent<SpriteRenderer>().color = Color.yellow;
                break;
            case 10:
                GetComponent<SpriteRenderer>().color = Color.green;
                break;
        }
    }
}
