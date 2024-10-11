using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowControl : MonoBehaviour
{
    public GameObject arm_R;
    public GameObject foreArm_R;
    public GameObject arm_L;
    public GameObject foreArm_L;

    public int arm_L_Index;
    public int foreArm_L_Index;
    public int arm_R_Index;
    public int foreArm_R_Index;

    public float arm_L_Rotation;
    public float foreArm_L_Rotation;
    public float arm_R_Rotation;
    public float foreArm_R_Rotation;

    public List<float> angles = new List<float>();  

    void Start()
    {    
        arm_L_Rotation = angles[Random.Range(0,angles.Count)];
        arm_R_Rotation = angles[Random.Range(0, angles.Count)];

        foreArm_L_Rotation = angles[Random.Range(0, angles.Count)];
        foreArm_R_Rotation = angles[Random.Range(0, angles.Count)];
        //arm_L_Index = Random.Range(0, 3);
        //if (arm_L_Index == 0)
        //{
        //    foreArm_L_Index = Random.Range(0, 4);
        //}
        //else if (arm_L_Index == 2)
        //{
        //    foreArm_L_Index = Random.Range(1, 4);
        //}
        //else
        //{
        //    foreArm_L_Index = Random.Range(0, 4);
        //}

        //arm_R_Index = Random.Range(0, 3);
        //if (arm_R_Index == 0)
        //{
        //    foreArm_R_Index = Random.Range(0, 4);
        //}
        //else if (arm_R_Index == 2)
        //{
        //    foreArm_R_Index = Random.Range(1, 4);
        //}
        //else
        //{
        //    foreArm_R_Index = Random.Range(0, 4);
        //}
        //UpdateArmRotation();
        //UpdateForeArmRotation();
    }

    void Update()
    {
        arm_L.transform.rotation = Quaternion.Euler(new Vector3(arm_L_Rotation, 90, 0));
        foreArm_L.transform.rotation = Quaternion.Euler(new Vector3(foreArm_L_Rotation, 90, 0));

        arm_R.transform.rotation = Quaternion.Euler(new Vector3(arm_R_Rotation, -90, 0));
        foreArm_R.transform.rotation = Quaternion.Euler(new Vector3(foreArm_R_Rotation, -90, 0));
        //CheckForeArmPosition();
        //CheckArmPostion();
    }

    void UpdateArmRotation()
    {
        arm_L_Rotation = GetArmRotationFromIndex(arm_L_Index);
        arm_R_Rotation = GetArmRotationFromIndex(arm_R_Index);
    }

    void UpdateForeArmRotation()
    {
        foreArm_L_Rotation = GetForeArmRotationFromIndex(foreArm_L_Index);
        foreArm_R_Rotation = GetForeArmRotationFromIndex(foreArm_R_Index);
    }

    float GetArmRotationFromIndex(int index)
    {
        switch (index)
        {
            case 0: return -135;
            case 1: return -90;
            case 2: return -45;
            default: return 0;
        }
    }

    float GetForeArmRotationFromIndex(int index)
    {
        switch (index)
        {
            case 0: return -135;
            case 1: return -90;
            case 2: return -45;
            case 3: return -45;
            default: return 0;
        }
    }

    public void CheckArmPostion()
    {
        if (arm_L_Index == 0)
            arm_L_Rotation = -135;
        else if (arm_L_Index == 1)
            arm_L_Rotation = -90;
        else if (arm_L_Index == 2)
            arm_L_Rotation = -45;

        if (arm_R_Index == 0)
            arm_R_Rotation = -135;
        else if (arm_R_Index == 1)
            arm_R_Rotation = -90;
        else if (arm_R_Index == 2)
            arm_R_Rotation = -45;
    }

    public void CheckForeArmPosition()
    {
        if (foreArm_L_Index == 0)
            foreArm_L_Rotation = -135;
        else if (foreArm_L_Index == 4)
            foreArm_L_Rotation = -45;

        if (foreArm_R_Index == 0)
            foreArm_R_Rotation = -135;
        else if (foreArm_R_Index == 4)
            foreArm_R_Rotation = -45;
    }
}
