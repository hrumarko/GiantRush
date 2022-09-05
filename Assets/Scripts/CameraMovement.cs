using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject character;
    float x;
    float y;
    float z;
    void Start(){
        x = this.transform.position.x;
        y = this.transform.position.y;
    }
    void Update(){
        z = character.transform.position.z -15; 
        transform.position = new Vector3(x, y, z);
    }
}
