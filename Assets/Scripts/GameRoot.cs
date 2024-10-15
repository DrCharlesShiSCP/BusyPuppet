using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameRoot : MonoBehaviour
{

    public static GameRoot instance;
    // Start is called before the first frame update

    public float roundTime = 20;

    public float currentTime;

    public bool gameEnd = false;

    public GameObject TimeCountUI;
    public GameObject TimeUp;
    public GameObject CorrectUI;
    public GameObject resultUI;

    
    public static GameRoot GetInstance()
    {
        if (instance == null)
        {
            
            return instance;
        }
        else
        {

        }
        return instance;
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    void Start()
    {
        if (StaticValue.currentTurn < 10)
        {
            StaticValue.currentTurn++;
        }
        CorrectUI.SetActive(false);
        TimeCountUI.SetActive(true);
        TimeUp.SetActive(false);
        currentTime = roundTime;
    }

    // Update is called once per frame
    void Update()
    {
        TimeCounter();
        CheckTime();
    }

    public void TimeCounter()
    {
        if(!gameEnd)
        {
            currentTime = roundTime -= Time.deltaTime;
        }
        

    }

    public void CheckTime()
    {
        if (StaticValue.currentTurn <10)
        {
            if (!gameEnd)
            {
                if (currentTime < 0)
                {
                    StartCoroutine(NextTurn());
                }
            }
        }
        else
        {
            if (!gameEnd)
            {
                if (currentTime < 0)
                {
                    resultUI.SetActive(true);
                }
            }
            
        }        
        
    }

    IEnumerator NextTurn()
    {
        gameEnd= true;
        TimeUp.SetActive(true);
        TimeCountUI.SetActive(false);
        
        currentTime = 3f;
        yield return new WaitForSeconds(1f);
        while (currentTime > 0)
        {
            currentTime-= Time.deltaTime;
            yield return null;
        }
        SceneManager.LoadScene("PuppetTestScene");
    }

    public void WIn()
    {

         StartCoroutine(WinProcess());

    }

    IEnumerator WinProcess()
    {
        gameEnd = true;
        CorrectUI.SetActive(true);
        TimeCountUI.SetActive(false);
        currentTime = 3f;
        yield return new WaitForSeconds(2f);
        while (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            yield return null;
            
        }
        StaticValue.completedTurn++;
        SceneManager.LoadScene("PuppetTestScene");
    }
}
