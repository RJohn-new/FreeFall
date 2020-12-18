using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Transform trans;
    public GameObject player;

    void Awake() {
        trans = GetComponent<Transform>();
    }
    // Update is called once per frame
    void Update()
    {
        //trans.position.y = player.GetComponent<Transform>().position.y;
        trans.position = new Vector3(trans.position.x, player.GetComponent<Transform>().position.y, -5);
    }
}
