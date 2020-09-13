using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using Base;

public class sceneManager : BasedObject
{
    [SerializeField]
    private GameObject restartButton;

    public override void BaseObjectStart()
    {
        restartButton.SetActive(false);
        onGameOver += slideRestartButton;
    }
    public event UnityAction onGameOver;
    public void GameOver()
    {
        if(onGameOver!=null)
        {
            onGameOver();
        }
    }
    
    private void slideRestartButton()
    {
        restartButton.SetActive(true);
    }

    public void restartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
