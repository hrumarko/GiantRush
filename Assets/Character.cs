using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] Rigidbody _rb;
    Vector3 _direction;
    public float speed;
    [Header("Color")]
    [SerializeField] Material _mat;
    public CollectColors col;
    [Header("Score")]
    [SerializeField]Score _score;
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
            Ray pos = Camera.main.ScreenPointToRay(Input.mousePosition);
            float posX = pos.direction.x  * speed;
            transform.position = new Vector3(posX, this.transform.position.y, this.transform.position.z);
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
       
    }
    
    private void OnCollisionEnter(Collision other)
    {
        
        if(other.gameObject.tag == "Collect"){
            Destroy(other.gameObject);
            
            if(col == other.gameObject.GetComponent<CollectCharacter>()._color){
                if(Score.score <10)transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
                _score.ScoreUp();
            }else{
                if(Score.score >= 1){
                    transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
                    _score.ScoreDown();
                }
                if(Score.score < 1){
                    Time.timeScale = 0;
                    Debug.Log("LOSE");
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
}
