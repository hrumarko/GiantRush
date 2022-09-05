using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorCollect : MonoBehaviour
{
    public string Color;
    

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player"){
            FindObjectOfType<Character>().SetColor(Color);
        }
    }
}
