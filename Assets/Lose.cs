using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Lose : MonoBehaviour
{
    public GameObject diedCanvas;


    private void OnEnable()
    {
        Character.died +=Died;
    }


    private void OnDisable()
    {
        Character.died -=Died;
    }
    void Died(){
        Time.timeScale =0;
        diedCanvas.SetActive(true);
    }

    public void Restart(){
        Time.timeScale = 1;
        diedCanvas.SetActive(false);
        SceneManager.LoadScene(1);
    }
}
