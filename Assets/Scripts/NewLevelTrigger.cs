using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NewLevelTrigger : MonoBehaviour
{
    public static Action spawnNewLevel;
    
    private void Start()
    {
        
    }
    void CheckPos(){
        Vector3 pos = this.transform.position;
        SpawnLevels._pos = pos;
        
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player"){
            CheckPos();
            spawnNewLevel?.Invoke();
        }
        
    }
}
