using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CollectColors{
    Red = 1,
    Blue = 2,
    Green = 3,
    Yellow = 4
}
public class CollectCharacter : MonoBehaviour
{
    public CollectColors _color;
    public Material[] materials;
    void Start()
    {
        switch(_color)
        {
            case CollectColors.Red:
                GetComponent<MeshRenderer>().material = materials[0];
            break;
            
            case CollectColors.Blue:
                GetComponent<MeshRenderer>().material = materials[1];
            break;

            case CollectColors.Green:
                GetComponent<MeshRenderer>().material = materials[2];
            break;

            case CollectColors.Yellow:
                GetComponent<MeshRenderer>().material = materials[3];
            break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
