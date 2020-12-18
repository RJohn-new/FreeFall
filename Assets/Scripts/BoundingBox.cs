using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundingBox : MonoBehaviour
{

    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Platform" || other.tag == "Hazard") {
            Spawner.instance.Pool(other.gameObject);
            GameManager.instance.LandingCount--;
        }
    }
}
