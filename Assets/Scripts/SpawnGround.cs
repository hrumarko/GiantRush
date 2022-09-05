using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGround : MonoBehaviour
{
    public GameObject ground;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player"){
            Instantiate(ground, new Vector3(this.transform.position.x, -0.56f, this.transform.position.z+610), Quaternion.identity);
        }
    }
}
