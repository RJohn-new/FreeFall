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
        Pool(Instantiate(Platform));
        Pool(Instantiate(Platform));
        Pool(Instantiate(Platform));
        Pool(Instantiate(Platform));
        Pool(Instantiate(Hazard));
        Pool(Instantiate(Hazard));
        Pool(Instantiate(Hazard));
        Pool(Instantiate(Hazard));
    }

    public void Pool(GameObject thing) {
        Transform trans = thing.GetComponent<Transform>();

        trans.position = new Vector3(-10, -10, 0);
        thing.SetActive(false);
        trans.SetParent(GameObject.Find("PoolParent").GetComponent<Transform>());

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

        Vector3 screenBottomCenter = new Vector3(Screen.width / 2, 0, 0);
        var spawnPos = Camera.main.ScreenToWorldPoint(screenBottomCenter);

        trans.position = new Vector3(Random.Range(-2.8f, 2.8f), spawnPos.y-1, 0);
        trans.SetParent(null);
        pool.Remove(choice);
        GameManager.instance.LandingCount++;
    }
}
