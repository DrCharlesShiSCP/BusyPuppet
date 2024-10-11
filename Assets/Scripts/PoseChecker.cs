using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoseChecker : MonoBehaviour
{
    public PuppetControl puppet; 
    public ShadowControl shadow;

    void Start()
    {
        puppet = FindObjectOfType<PuppetControl>();
        shadow = FindObjectOfType<ShadowControl>();
    }
    void Update()
    {
        if (CheckMatch())
        {
            Debug.Log("���ĺã�");
        }
    }

    bool CheckMatch()
    {
        bool leftArmMatch = Mathf.Approximately(puppet.arm_L_Rotation, shadow.arm_L_Rotation);
        bool leftForearmMatch = Mathf.Approximately(puppet.foreArm_L_Rotation, shadow.foreArm_L_Rotation);
        bool rightArmMatch = Mathf.Approximately(puppet.arm_R_Rotation, shadow.arm_R_Rotation);
        bool rightForearmMatch = Mathf.Approximately(puppet.foreArm_R_Rotation, shadow.foreArm_R_Rotation);

        return leftArmMatch && leftForearmMatch && rightArmMatch && rightForearmMatch;
    }
}
