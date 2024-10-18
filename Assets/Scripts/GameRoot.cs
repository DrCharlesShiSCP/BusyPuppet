using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameRoot : MonoBehaviour
{

    public static GameRoot instance;
    // Start is called before the first frame update

    public float roundTime = 120;

    public float currentTime;

    public bool gameEnd = false;

    public GameObject TimeCountUI;
    public GameObject TimeUp;
    public GameObject CorrectUI;
    public GameObject resultUI;


    public List<Mesh> meshes = new List<Mesh>();
    public List<Material> materials = new List<Material>();

    public GameObject puppetMeshObj;
    public GameObject puppetShadowGameObj;
    public GameObject puppetDancingGameObj;

    public GameObject controlCubes;

    public AudioClip failSFX;
    public AudioSource DanceSource;
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
        int index  = Random.Range(0,meshes.Count);

        puppetMeshObj.GetComponent<SkinnedMeshRenderer>().sharedMesh = meshes[index];

        puppetMeshObj.GetComponent<SkinnedMeshRenderer>().material= materials[index];

        puppetShadowGameObj.GetComponent<SkinnedMeshRenderer>().sharedMesh = meshes[index];

        puppetDancingGameObj.GetComponent<SkinnedMeshRenderer>().sharedMesh = meshes[index];
        puppetDancingGameObj.GetComponent<SkinnedMeshRenderer>().material = materials[index];

        if (StaticValue.currentTurn < 10)
        {
            StaticValue.currentTurn++;
        }
        resultUI.SetActive(false); 
        CorrectUI.SetActive(false);
        TimeCountUI.SetActive(true);
        TimeUp.SetActive(false);
        controlCubes.SetActive(true);
        currentTime = roundTime;
    }

    // Update is called once per frame
    void Update()
    {
        TimeCounter();
        CheckTime();
        ResetTheGameWithKey();
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
                    
                    int currentHighestScore = PlayerPrefs.GetInt("HighScore", 0);
                    if (StaticValue.completedTurn > currentHighestScore)
                    {
                        PlayerPrefs.SetInt("HighScore", StaticValue.completedTurn);
                        PlayerPrefs.Save();
                    }
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
        DanceSource.PlayOneShot(failSFX);
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
        controlCubes.SetActive(false);
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

    public void ResetTheGameWithKey()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            StaticValue.completedTurn = 0;
            StaticValue.currentTurn = 0;
            SceneManager.LoadScene("PuppetTestScene");
        }
    }
}
