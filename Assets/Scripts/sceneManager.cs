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

    public event UnityAction onGameOver;
    public void GameOver()
    {
        if(onGameOver!=null)
        {
            onGameOver();
        }
    }

    public override void BaseObjectStart()
    {
        restartButton.SetActive(false);
        onGameOver += slideRestartButton;
    }

    public override void BaseObjectOnDestroy()
    {
        onGameOver -= slideRestartButton;
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
