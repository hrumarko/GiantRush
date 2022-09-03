using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterColor : MonoBehaviour
{
    [SerializeField] Material _mat;
    CollectColors col;
    void Awake(){
        
    }
    void Start()
    {   
        int rand = Random.Range(1, 4);

        SetColor(rand);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetColor(int num){
        switch(num){
            case 1: _mat.color = Color.red; break;
            case 2: _mat.color = Color.blue; break;
            case 3: _mat.color = Color.green; break;
            case 4: _mat.color = Color.yellow; break;
                
            
        }
    }

    
}
