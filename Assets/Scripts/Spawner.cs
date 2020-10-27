using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    public GameObject Platform;
    public GameObject Hazard;
    public static Spawner instance;

    private List<GameObject> pool;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);
        
        pool = new List<GameObject>();
        PrePool();
    }

    private void PrePool() {
        pool.Add(Instantiate(Platform));
        pool.Add(Instantiate(Platform));
        pool.Add(Instantiate(Platform));
        pool.Add(Instantiate(Platform));
        pool.Add(Instantiate(Hazard));
        pool.Add(Instantiate(Hazard));
        pool.Add(Instantiate(Hazard));
        pool.Add(Instantiate(Hazard));
    }

    public void Pool(GameObject thing) {
        Transform trans = thing.GetComponent<Transform>();

        trans.position = new Vector3(-10, -10, 0);
        thing.SetActive(false);

        pool.Add(thing);
    }

    public void Spawn(GameObject toSpawn) {
        GameObject choice = Platform;

        foreach (GameObject go in pool) {
            if (go.tag == toSpawn.tag) {
                choice = go;
                break;
            }
        }

        choice.SetActive(true);

        Transform trans = choice.GetComponent<Transform>();
        trans.position = new Vector3(Random.Range(0, 1080), 1950, 0);
    }
}
