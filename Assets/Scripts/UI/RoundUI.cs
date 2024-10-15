using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RoundUI : MonoBehaviour
{

    public TextMeshProUGUI currentTurn;

    public TextMeshProUGUI completedTurn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTurn.text = StaticValue.currentTurn.ToString();
        completedTurn.text = StaticValue.completedTurn.ToString();
    }
}
