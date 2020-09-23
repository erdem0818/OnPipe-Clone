using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using Base;

public class ScoreText : BasedObject
{
    private int _score;

    [SerializeField]
    private TextMeshProUGUI _scoreText;

    public override void BaseObjectStart()
    {
        _score=0;
        OnChangeScoreText += increaseScore;
    }
    public override void BaseObjectOnDestroy()
    {
        OnChangeScoreText -= increaseScore;
    }
    public event UnityAction OnChangeScoreText;
    public void scoreChanged()
    {
        if(OnChangeScoreText!=null)
        {
            OnChangeScoreText();
        }
    }

    private void increaseScore()
    {
        _score +=1;

        _scoreText.text = _score.ToString();
    }
}
