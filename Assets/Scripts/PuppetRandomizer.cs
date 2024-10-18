using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuppetRandomizer : MonoBehaviour
{
    public GameObject[] puppetModels; 
    public GameObject[] puppetShadows; 

    public int currentRoundIndex = -1; 

    void Start()
    {
        RandomizePuppet();
    }

    public void RandomizePuppet()
    {
        // Ensure the arrays have the same length
        if (puppetModels.Length != puppetShadows.Length)
        {
            Debug.LogError("The number of puppet models and shadows must be the same!");
            return;
        }

        // Deactivate all puppet models and shadows
        for (int i = 0; i < puppetModels.Length; i++)
        {
            puppetModels[i].SetActive(false);
            puppetShadows[i].SetActive(false);
        }

        // Select a random index for the current round
        currentRoundIndex = Random.Range(0, puppetModels.Length);

        // Activate the randomly selected puppet model and its corresponding shadow
        puppetModels[currentRoundIndex].SetActive(true);
        puppetShadows[currentRoundIndex].SetActive(true);
    }
}
