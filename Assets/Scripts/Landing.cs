using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Landing : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(transform.position.y > 10) {
            Spawner.instance.Pool(gameObject);

            GameManager.instance.SpawnNew();
        }
    }
}
