using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoseChecker : MonoBehaviour
{
    public PuppetRandomizer puppetRandomizer; // Reference to the randomizer script
    public GameObject dancer; // Dancer object
    public AudioClip DanceClip;
    public AudioSource DanceSource;
    private bool hasMatched = false;

    void Start()
    {
        puppetRandomizer = FindObjectOfType<PuppetRandomizer>();
        hasMatched = false;
        dancer.SetActive(false);

        // Ensure PuppetRandomizer is linked
        if (puppetRandomizer == null)
        {
            puppetRandomizer = FindObjectOfType<PuppetRandomizer>();
        }
    }

    void Update()
    {
        // Use the currently active puppet and shadow from the PuppetRandomizer
        PuppetControl puppet = puppetRandomizer.puppetModels[puppetRandomizer.currentRoundIndex].GetComponent<PuppetControl>();
        ShadowControl shadow = puppetRandomizer.puppetShadows[puppetRandomizer.currentRoundIndex].GetComponent<ShadowControl>();

        if (CheckMatch(puppet, shadow) && !hasMatched)
        {
            StartCoroutine(CheckMatchDelay(puppetRandomizer.puppetModels[puppetRandomizer.currentRoundIndex]));
        }
    }

    IEnumerator CheckMatchDelay(GameObject activePuppet)
    {
        hasMatched = true;
        Debug.Log("Good job!");
        yield return new WaitForSeconds(1);

        // Deactivate the active puppet model
        activePuppet.SetActive(false);

        // Activate the dancer
        dancer.SetActive(true);
        DanceSource.PlayOneShot(DanceClip);
        GameRoot.GetInstance().WIn();
    }

    bool CheckMatch(PuppetControl puppet, ShadowControl shadow)
    {
        // Check upper body match
        bool leftArmMatch = Mathf.Approximately(puppet.arm_L_Rotation, shadow.arm_L_Rotation);
        bool leftForearmMatch = Mathf.Approximately(puppet.foreArm_L_Rotation, shadow.foreArm_L_Rotation);
        bool rightArmMatch = Mathf.Approximately(puppet.arm_R_Rotation, shadow.arm_R_Rotation);
        bool rightForearmMatch = Mathf.Approximately(puppet.foreArm_R_Rotation, shadow.foreArm_R_Rotation);

        // Check lower body match
        bool leftThighMatch = Mathf.Approximately(puppet.thigh_L_Rotation, shadow.thigh_L_Rotation);
        bool rightThighMatch = Mathf.Approximately(puppet.thigh_R_Rotation, shadow.thigh_R_Rotation);
        bool leftCalfMatch = Mathf.Approximately(puppet.calf_L_Rotation, shadow.calf_L_Rotation);
        bool rightCalfMatch = Mathf.Approximately(puppet.calf_R_Rotation, shadow.calf_R_Rotation);

        return leftArmMatch && leftForearmMatch && rightArmMatch && rightForearmMatch &&
               leftThighMatch && rightThighMatch && leftCalfMatch && rightCalfMatch;
    }
}
