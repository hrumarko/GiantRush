using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLevels : MonoBehaviour
{
    public GameObject[] Red;
    public GameObject[] Green;
    public GameObject[] Blue;
    public GameObject[] Yellow;
    [SerializeField] Character character;

    private void Start()
    {
        
        StartSpawnLevel();
    }
    public void StartSpawnLevel(){
        string charColor = character.col.ToString();
        Debug.Log($"{charColor}");
        switch(charColor){
            case "Red":
                Spawn(Red);
            break;
            case "Green":
                Spawn(Green);
            break;
            case "Blue":
                Spawn(Blue);
            break;
            case "Yellow":
                Spawn(Yellow);
            break;
        }
    }

    public void Spawn(GameObject[] array){
        Debug.Log("Create");
        Instantiate(array[Random.Range(0, array.Length)], new Vector3(0, 0.44f, 10), Quaternion.identity);
        Instantiate(array[Random.Range(0, array.Length)], new Vector3(0, 0.44f, 45), Quaternion.identity);
    }

}
