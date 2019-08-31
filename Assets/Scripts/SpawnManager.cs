using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] strays;
    public GameObject[] dogTypes;
    private float maxSpawnRadius = 40;
    private List<GameObject> dogs = new List<GameObject>();
    public GameObject player;
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
     
    public void SpawnStray()
    {
        int randStrayInt = UnityEngine.Random.Range(0, strays.Length);
        float randX = UnityEngine.Random.Range(-maxSpawnRadius, maxSpawnRadius);
        float randZ = UnityEngine.Random.Range(-maxSpawnRadius, maxSpawnRadius);
        Instantiate(strays[randStrayInt], new Vector3(randX, 0, randZ), Quaternion.Euler(new Vector3(0, Random.Range(0, 360), 0)));
    }

    public void SpawnDog()
    {

        int randDogInt = UnityEngine.Random.Range(0, dogTypes.Length);
        GameObject newDog;
        if (dogs.Count == 0)
        {
            // follow player
            var localOffset = new Vector3(0, 0, -10);
            var worldOffset = transform.rotation * localOffset;
            var spawnPosition = transform.position + worldOffset;
            spawnPosition.y = 0;
            newDog = Instantiate(dogTypes[randDogInt], spawnPosition, dogTypes[randDogInt].transform.rotation);
            DogController dc = newDog.GetComponent<DogController>();
            dc.SetDogToFollow(player);

        }
        else
        {
            // follow last dog
            var localOffset = new Vector3(0, 0, -10);
            var worldOffset = dogs[dogs.Count - 1].transform.rotation * localOffset;
            var spawnPosition = dogs[dogs.Count - 1].transform.position + worldOffset;
            spawnPosition.y = 0;

            newDog = Instantiate(dogTypes[randDogInt], spawnPosition, dogTypes[randDogInt].transform.rotation);
            DogController dc = newDog.GetComponent<DogController>();
            dc.SetDogToFollow(dogs[dogs.Count - 1]);

        }
        dogs.Add(newDog);
        gameManager.SetScore(dogs.Count);

    }
}
