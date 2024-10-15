using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeCount_UI : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeText.text = GameRoot.GetInstance().currentTime.ToString("0");
    }
}
