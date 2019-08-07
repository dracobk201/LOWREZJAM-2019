using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    private List<GameObject> items;
    [SerializeField]
    private IntReference ItemsPooled;
    [SerializeField]
    private GameObject ItemsPrefab;
    [SerializeField]
    private Transform ItemHolder;
    [SerializeField]
    private Vector2[] itemLocation;
    [SerializeField]
    private GameEvent NewWaveSpawned;

    private void Start()
    {
        InstantiateItems();
        ShowNewWave();
    }

    private void InstantiateItems()
    {
        items = new List<GameObject>();
        for (int i = 0; i < ItemsPooled.Value; i++)
        {
            GameObject item = Instantiate(ItemsPrefab) as GameObject;
            item.GetComponent<Transform>().SetParent(ItemHolder.transform);
            item.SetActive(false);
            items.Add(item);
        }
    }

    public void ShowNewWave()
    {
        bool isSpawned = false;
        for (int i = 0; i < 4; i++)
        {
            isSpawned = false;
            while (!isSpawned)
            {
                int index = Random.Range(0, items.Count-1);
                if (!items[index].activeInHierarchy)
                {
                    items[index].transform.position = itemLocation[i];
                    items[index].SetActive(true);
                    isSpawned = true;
                }
            }
        }
        NewWaveSpawned.Raise();
    }
}
