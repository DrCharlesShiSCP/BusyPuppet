using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuppetControl : MonoBehaviour
{

    public GameObject arm_R;
    public GameObject foreArm_R;

    public GameObject arm_L;
    public GameObject foreArm_L;


    public float arm_R_Rotation;
    public float foreArm_R_Rotation;

    public float arm_L_Rotation;
    public float foreArm_L_Rotation;

    public int arm_L_Index;
    public int foreArm_L_Index;

    public int arm_R_Index;
    public int foreArm_R_Index;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //foreArm_R.transform.rotation = Quaternion.Euler(new Vector3(foreArm_R_Rotation, -90, 0));

        //foreArm_L.transform.rotation = Quaternion.Euler(new Vector3(foreArm_L_Rotation, 90, 0));

        //arm_R.transform.rotation = Quaternion.Euler(new Vector3(arm_R_Rotation, -90, 0));
        //arm_L.transform.rotation = Quaternion.Euler(new Vector3(arm_L_Rotation, 90, 0));
        arm_L.transform.rotation = Quaternion.Euler(new Vector3(arm_L_Rotation, 90, 0));
        foreArm_L.transform.rotation = Quaternion.Euler(new Vector3(foreArm_L_Rotation, 90, 0));

        arm_R.transform.rotation = Quaternion.Euler(new Vector3(arm_R_Rotation, -90, 0));
        foreArm_R.transform.rotation = Quaternion.Euler(new Vector3(foreArm_R_Rotation, -90, 0));

        if (Input.GetKeyDown(KeyCode.Q))
        {
            RaiseLeftArm();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            LowerLeftArm();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            RaiseLeftForearm();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            LowerLeftForearm();
        }

        // Right Arm Controls
        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            RaiseRightArm();
        }

        if (Input.GetKeyDown(KeyCode.Keypad6))
        {
            LowerRightArm();
        }

        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            RaiseRightForearm();
        }

        if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            LowerRightForearm();
        }

        CheckArmPostion();
        CheckForeArmPosition();

    }
    public void RaiseLeftArm()
    {
        if (arm_L_Index < 2)
        {
            if (foreArm_L_Rotation != -135)
            {
                foreArm_L_Rotation -= 45;
            }
            else
            {
                foreArm_L_Index++;
            }
            arm_L_Index++;
        }
    }

    public void LowerLeftArm()
    {
        if (arm_L_Index > 0)
        {
            if (foreArm_L_Rotation != -45)
            {
                foreArm_L_Rotation += 45;
            }
            else
            {
                foreArm_L_Index--;
            }
            arm_L_Index--;
        }
    }

    public void RaiseLeftForearm()
    {
        if (foreArm_L_Index < 4)
        {
            if (foreArm_L_Rotation == -45)
            {
                if (arm_L_Rotation != -45)
                {
                    arm_L_Rotation += 45;
                    arm_L_Index++;
                }
            }
            else
            {
                foreArm_L_Rotation += 45;
            }
            foreArm_L_Index++;
        }
    }

    public void LowerLeftForearm()
    {
        if (foreArm_L_Index > 0)
        {
            if (foreArm_L_Rotation != -135)
            {
                foreArm_L_Rotation -= 45;
            }
            foreArm_L_Index--;
        }
    }

    public void RaiseRightForearm()
    {
        if (foreArm_R_Index < 4)
        {
            if (foreArm_R_Rotation == -45)
            {
                if (arm_R_Rotation != -45)
                {
                    arm_R_Rotation += 45;
                    arm_R_Index++;
                }
            }
            else
            {
                foreArm_R_Rotation += 45;
            }
            foreArm_R_Index++;
        }
    }

    public void LowerRightForearm()
    {
        if (foreArm_R_Index > 0)
        {
            if (foreArm_R_Rotation != -135)
            {
                foreArm_R_Rotation -= 45;
            }
            foreArm_R_Index--;
        }
    }

    public void RaiseRightArm()
    {
        if (arm_R_Index < 2)
        {
            if (foreArm_R_Rotation != -135)
            {
                foreArm_R_Rotation -= 45;
            }
            else
            {
                foreArm_R_Index++;
            }
            arm_R_Index++;
        }
    }

    public void LowerRightArm()
    {
        if (arm_R_Index > 0)
        {
            if (foreArm_R_Rotation != -45)
            {
                foreArm_R_Rotation += 45;
            }
            else
            {
                if (arm_R_Index - foreArm_R_Index <= 0)
                {
                    foreArm_R_Index--;
                }
            }
            arm_R_Index--;
        }
    }
    public void CheckArmPostion()
    {
        if(arm_L_Index == 0)
        {
            arm_L_Rotation = -135;

        }
        else if(arm_L_Index == 1)
        {
            arm_L_Rotation = -90;

        }
        else if (arm_L_Index == 2)
        {
            arm_L_Rotation = -45;

        }

        if (arm_R_Index == 0)
        {
            arm_R_Rotation = -135;

        }
        else if (arm_R_Index == 1)
        {
            arm_R_Rotation = -90;

        }
        else if (arm_R_Index == 2)
        {
            arm_R_Rotation = -45;

        }
    }

    public void CheckForeArmPosition()
    {
        if (foreArm_L_Index == 0)
        {
            foreArm_L_Rotation = -135;


        }
        else if (foreArm_L_Index == 4)
        {

            foreArm_L_Rotation = -45;

        }

        if (foreArm_R_Index == 0)
        {
            foreArm_R_Rotation = -135;


        }
        else if (foreArm_R_Index == 4)
        {

            foreArm_R_Rotation = -45;

        }
        
    }
}
