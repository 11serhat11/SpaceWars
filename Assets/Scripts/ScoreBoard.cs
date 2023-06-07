using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    int score;
    [SerializeField] TMP_Text tMP_Text;
    void Start() 
    {
        tMP_Text = GetComponent<TMP_Text>();
    }
    public void IncreaseScore(int point)
        {
            score += point;
            tMP_Text.text = score.ToString();
        }


}
