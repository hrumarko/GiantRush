using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] Rigidbody _rb;
    Vector3 _direction;

    int a = 0;
    Ray pos0;
    Vector3 goPos1;

    public float speed;
    [Header("Color")]
    [SerializeField] Material _mat;
    public CollectColors col;
    [Header("Score")]
    [SerializeField]Score _score;
    public static System.Action died;
    void Awake(){
        int rand = Random.Range(1, 4);
        SetColor(rand);
    }
    void Start()
    {
        
        _direction = new Vector3(0, 0, 1);
    }

    // Update is called once per frame
    void Update()
    {   
        SideMoving();
        _rb.velocity = _direction * speed;
    }

    

    public void SideMoving(){        
        if(Input.GetMouseButton(0)){
            if(a == 0){
                a =1;
                pos0 =  Camera.main.ScreenPointToRay(Input.mousePosition);
                goPos1 = this.transform.position;
            }
            
            Ray pos1 = Camera.main.ScreenPointToRay(Input.mousePosition);
            float posX = pos1.direction.x - pos0.direction.x;
            
            transform.position = new Vector3(goPos1.x + (posX*speed), this.transform.position.y, this.transform.position.z);
        }
        if(Input.GetMouseButtonUp(0)){
            a=0;
        }
        BoundsMovement();
            
    }
    void BoundsMovement(){
        if(transform.position.x > 3.25f){
                float y = this.transform.position.y;
                float z = this.transform.position.z;
                transform.position = new Vector3(3.25f, y, z);
            }

            if(transform.position.x < -3.25f){
                float y = this.transform.position.y;
                float z = this.transform.position.z;
                transform.position = new Vector3(-3.25f, y, z);
            }
    }
    
    private void OnCollisionEnter(Collision other)
    {
        
        if(other.gameObject.tag == "Collect"){
            Destroy(other.gameObject);
            
            if(col == other.gameObject.GetComponent<CollectCharacter>()._color){
                Score.basicScore++;
                if(Score.score <10)transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
                _score.ScoreUp();
            }else{
                if(Score.score >= 0 ){
                    if(Score.score <11){
                        transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
                    }                    
                    _score.ScoreDown();
                }
                if(Score.score < 0){
                    died?.Invoke();
                }
                
            }
        }
    }

    public void SetColor(int num){
        switch(num){
            case 1: _mat.color = Color.red; break;
            case 2: _mat.color = Color.blue; break;
            case 3: _mat.color = Color.green; break;
            case 4: _mat.color = Color.yellow; break;
        }
        col = (CollectColors)num;
    }

    public void SetColor(string color){
        switch(color){
            case "Red": 
                _mat.color = Color.red;
                col = CollectColors.Red;
            break;
            case "Blue":
                _mat.color = Color.blue;
                col = CollectColors.Blue; 
             break;
            case "Green":
                _mat.color = Color.green;
                col = CollectColors.Green; 
             break;
            case "Yellow":
                _mat.color = Color.yellow;
                col = CollectColors.Yellow; 
             break;
        }

        
    }
}
