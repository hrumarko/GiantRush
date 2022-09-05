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
    public static Vector3 _pos;


    private void OnEnable()
    {
        NewLevelTrigger.spawnNewLevel += SpawnLevel;
    }

    private void OnDisable()
    {
        NewLevelTrigger.spawnNewLevel -= SpawnLevel;
    }
    private void Start()
    {
        
        StartSpawnLevel();
    }
    public void StartSpawnLevel(){
        string charColor = character.col.ToString();
        Debug.Log($"{charColor}");
        switch(charColor){
            case "Red":
                FirstSpawn(Red);
            break;
            case "Green":
                FirstSpawn(Green);
            break;
            case "Blue":
                FirstSpawn(Blue);
            break;
            case "Yellow":
                FirstSpawn(Yellow);
            break;
        }
    }

    public void FirstSpawn(GameObject[] array){
        Debug.Log("Create");
        Instantiate(array[Random.Range(0, array.Length)], new Vector3(0, 0.44f, 10), Quaternion.identity);
        
        
    }

    public void SpawnLevel(){
        string charColor = character.col.ToString();
        Debug.Log("ZASPAVNYU BLYAA");
        switch(charColor){
            case "Red":
                Spawn(_pos, Red);
            break;
            case "Green":
                Spawn(_pos, Green);
            break;
            case "Blue":
                Spawn(_pos, Blue);
            break;
            case "Yellow":
                Spawn(_pos, Yellow);
            break;
        }
    }
    public void Spawn(Vector3 pos, GameObject[] array){

        Instantiate(array[Random.Range(0, array.Length)], new Vector3(0, 0.44f, pos.z+165), Quaternion.identity);
        
    }

}
