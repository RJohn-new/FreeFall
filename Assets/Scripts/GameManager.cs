using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public GameObject Platform;
    public GameObject Hazard;
    private const int MaxLanding = 4;
    public int LandingCount;

    public bool GameOver = false;

    public static GameManager instance;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        LandingCount = 0;
    }

    // void Start() {
    //     StartCoroutine(InitialSpawn());
    // }

    // IEnumerator InitialSpawn() {
    //     Spawner.instance.Spawn(Platform);
    //     yield return new WaitForSeconds(2);
    //     Spawner.instance.Spawn(Platform);
    //     yield return new WaitForSeconds(2);
    //     Spawner.instance.Spawn(Platform);
    //     yield return new WaitForSeconds(2);
    //     Spawner.instance.Spawn(Platform);
    //     yield return new WaitForSeconds(2);
    // }

    public void SpawnNew() {
        int choice = Random.Range(0, 11);
        if (choice < 8) {
            Spawner.instance.Spawn(Platform);
        } else {
            Spawner.instance.Spawn(Hazard);
        }
    }

    public void LandingCheck() {
        if (LandingCount < MaxLanding) {
            SpawnNew();
        }
    }

    public void Start() {
        InvokeRepeating("LandingCheck", 0.5f, 0.75f);
    }
}
