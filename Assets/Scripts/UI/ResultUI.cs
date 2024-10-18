using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResultUI : MonoBehaviour
{
    public TextMeshProUGUI highestScore;

    public TextMeshProUGUI completedTurn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        highestScore.text = PlayerPrefs.GetInt("HighScore",0).ToString();
        completedTurn.text = StaticValue.completedTurn.ToString();
    }
}
