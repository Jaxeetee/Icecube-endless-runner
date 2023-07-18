using UnityEngine;
using MyUtilities;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Item[] _items;

    [SerializeField] private Transform[] _spawnLocations;

    [SerializeField] private GameObject _parent;

    private int _forcedItemsCounter;
    
    void Start()
    {
        for (int i = 0; i < _items.Length; i++)
        {
            PooledObjectItem.Add(StringManager.ITEM_KEYS[i], _items[i].gameObject, _parent);
        }
    }

    private void OnEnable()
    {
        GameManager.OnSpawnInterval += Spawn;
    }

    private void OnDisable()
    {
        GameManager.OnSpawnInterval -= Spawn;
    }

    private void Spawn()
    {
        int numOfItemsToSpawn = UnityEngine.Random.Range(1, 4);
        int maxObstacles = 2;
        int obstacleCounter = 0;

        ShuffleSpawnLocations(); // shuffles spawn locations in an array 

        for (int i = 0; i < numOfItemsToSpawn; i++)
        {
            GameObject spawnedItem = GetRandomItem();

            Item item = spawnedItem.GetComponent<Item>();
            if (item.itemType == Itemtype.Obstacle) obstacleCounter++; // 2 max 

            // changes to either an Ice Item or an empty object
            if (obstacleCounter > maxObstacles)
            {
                int randBool = UnityEngine.Random.Range(0, 2);
                spawnedItem = GetItem(randBool == 1);
            }

            if (spawnedItem == null) return;

            spawnedItem.transform.rotation = Quaternion.Euler(0, 180, 0);
            spawnedItem.transform.position = _spawnLocations[i].position;
            spawnedItem.SetActive(true);
        }
    }

    //this gets the random position of the item to spawn. 
    private void ShuffleSpawnLocations()
    {
        int n = _spawnLocations.Length;
        System.Random random = new System.Random();
        while (n > 1)
        {
            n--;
            int k = random.Next(n + 1);
            Transform temp = _spawnLocations[k];
            _spawnLocations[k] = _spawnLocations[n];
            _spawnLocations[n] = temp;
        }
    }

    private GameObject GetRandomItem()
    {
        int randomIndex = UnityEngine.Random.Range(0, _items.Length);
        GameObject chosenGO = PooledObjectItem.GetObject(StringManager.ITEM_KEYS[randomIndex]);
        return chosenGO;
    }

    private GameObject GetItem(bool getIce)
    {
        return getIce ? PooledObjectItem.GetObject(StringManager.ITEM_KEYS[0]) : null;
    }

}
