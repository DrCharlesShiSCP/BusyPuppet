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
            Debug.Log("×öµÄºÃ£¡");
        }
    }

    bool CheckMatch()
    {
        bool leftArmMatch = (puppet.arm_L_Index == shadow.arm_L_Index) &&
                            (puppet.foreArm_L_Index == shadow.foreArm_L_Index);

        bool rightArmMatch = (puppet.arm_R_Index == shadow.arm_R_Index) &&
                             (puppet.foreArm_R_Index == shadow.foreArm_R_Index);

        return leftArmMatch && rightArmMatch;
    }
}
