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

    public GameObject thigh_L;
    public GameObject thigh_R;

    public GameObject calf_L;
    public GameObject calf_R;

    public float thigh_L_Rotation;
    public float thigh_R_Rotation;
    public float calf_L_Rotation;
    public float calf_R_Rotation;

    public float arm_R_Rotation;
    public float foreArm_R_Rotation;

    public float arm_L_Rotation;
    public float foreArm_L_Rotation;

    public int arm_L_Index;
    public int foreArm_L_Index;

    public int arm_R_Index;
    public int foreArm_R_Index;

    public int thigh_L_Index;
    public int thigh_R_Index;

    public int calf_R_Index;
    public int calf_L_Index;
    // Start is called before the first frame update
    void Start()
    {

        arm_L_Rotation = -135;
        arm_R_Rotation = -135;
        foreArm_L_Rotation = -135;
        foreArm_R_Rotation = -135;

     thigh_L_Rotation = -180;
     thigh_R_Rotation=-180;
     calf_L_Rotation=-180;
     calf_R_Rotation= - 180;
}

    // Update is called once per frame
    void Update()
    {
        thigh_L.transform.rotation = Quaternion.Euler(new Vector3(thigh_L_Rotation, 75, 0));
        calf_L.transform.rotation = Quaternion.Euler(new Vector3(calf_L_Rotation, 75, 0));

        thigh_R.transform.rotation = Quaternion.Euler(new Vector3(thigh_R_Rotation, -75, 0));
        calf_R.transform.rotation = Quaternion.Euler(new Vector3(calf_R_Rotation, -75, 0));


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


        if(Input.GetKeyDown(KeyCode.L))
        {
            LowerLeftCalf();
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            RaiseLeftCalf();
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            LowerLeftThigh();
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            RaiseLeftThigh();
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            LowerRightCalf();
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            RaiseRightCalf();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            LowerRightThigh();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            RaiseRightThigh();
        }
        //CheckArmPostion();
        //CheckForeArmPosition();


    }
    public void RaiseLeftArm()
    {
        if(!GameRoot.GetInstance().gameEnd)
        {
            if (arm_L_Index < 2)
            {
                if (arm_L_Rotation != -45)
                {
                    arm_L_Rotation += 45;
                }

                arm_L_Index++;

                if (!(foreArm_L_Index - arm_L_Index > 1))
                {
                    if (foreArm_L_Rotation != -135)
                    {
                        foreArm_L_Rotation -= 45;
                    }
                    else
                    {

                    }
                }

            }
        }
        
    }

    public void LowerLeftArm()
    {
        if (!GameRoot.GetInstance().gameEnd)
        {
            if (arm_L_Index > 0)
            {
                if (foreArm_L_Index - arm_L_Index > 1)
                {

                }
                else if (foreArm_L_Index < arm_L_Index)
                {
                    if (arm_L_Rotation != -135)
                    {

                        arm_L_Rotation -= 45;
                    }
                }
                else
                {
                    if (foreArm_L_Rotation != -45)
                    {
                        foreArm_L_Rotation += 45;
                    }
                    else
                    {

                    }
                    if (arm_L_Rotation != -135)
                    {

                        arm_L_Rotation -= 45;
                    }
                }

                arm_L_Index--;
            }
        }
    }

    public void RaiseLeftForearm()
    {
        if (!GameRoot.GetInstance().gameEnd)
        {
            if (foreArm_L_Index < 4)
            {
                if (foreArm_L_Rotation == -45)
                {
                    if (arm_L_Rotation != -45)
                    {
                        arm_L_Rotation += 45;

                    }
                }
                else
                {
                    foreArm_L_Rotation += 45;
                }
                foreArm_L_Index++;
            }
        }
    }

    public void LowerLeftForearm()
    {
        if (!GameRoot.GetInstance().gameEnd)
        {
            if (foreArm_L_Index > 0)
            {


                foreArm_L_Index--;
                if (foreArm_L_Index - arm_L_Index > 1)
                {
                    if (arm_L_Rotation != -135)
                    {
                        arm_L_Rotation -= 45;
                    }
                }
                else
                {
                    if (foreArm_L_Rotation != -135)
                    {
                        foreArm_L_Rotation -= 45;
                    }
                }
            }
        }
    }

    public void RaiseRightForearm()
    {
        if (!GameRoot.GetInstance().gameEnd)
        {
            if (foreArm_R_Index < 4)
            {
                if (foreArm_R_Rotation == -45)
                {
                    if (arm_R_Rotation != -45)
                    {
                        arm_R_Rotation += 45;

                    }
                }
                else
                {
                    foreArm_R_Rotation += 45;
                }
                foreArm_R_Index++;
            }
        }
    }

    public void LowerRightForearm()
    {
        if (!GameRoot.GetInstance().gameEnd)
        {
            if (foreArm_R_Index > 0)
            {


                foreArm_R_Index--;
                if (foreArm_R_Index - arm_R_Index > 1)
                {
                    if (arm_R_Rotation != -135)
                    {
                        arm_R_Rotation -= 45;
                    }
                }
                else
                {
                    if (foreArm_R_Rotation != -135)
                    {
                        foreArm_R_Rotation -= 45;
                    }
                }
            }
        }
    }

    public void RaiseRightArm()
    {
        if (!GameRoot.GetInstance().gameEnd)
        {
            if (arm_R_Index < 2)
            {
                if (arm_R_Rotation != -45)
                {
                    arm_R_Rotation += 45;
                }
                arm_R_Index++;

                if (!(foreArm_R_Index - arm_R_Index > 1))
                {
                    if (foreArm_R_Rotation != -135)
                    {
                        foreArm_R_Rotation -= 45;
                    }
                    else
                    {

                    }
                }


            }
        }
    }

    public void LowerRightArm()
    {
        if (!GameRoot.GetInstance().gameEnd)
        {
            if (arm_R_Index > 0)
            {
                if (foreArm_R_Index - arm_R_Index > 1)
                {

                }
                else if (foreArm_R_Index < arm_R_Index)
                {
                    if (arm_R_Rotation != -135)
                    {

                        arm_R_Rotation -= 45;
                    }
                }
                else
                {
                    if (foreArm_R_Rotation != -45)
                    {
                        foreArm_R_Rotation += 45;
                    }
                    else
                    {

                    }
                    if (arm_R_Rotation != -135)
                    {

                        arm_R_Rotation -= 45;
                    }
                }

                arm_R_Index--;
            }
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

    public void RaiseLeftThigh()
    {
        if (!GameRoot.GetInstance().gameEnd)
        {
            if (thigh_L_Rotation < -135)
            {
                thigh_L_Rotation += 45;
                thigh_L_Index++;
            }
        }
    }

    public void LowerLeftThigh()
    {
        if (!GameRoot.GetInstance().gameEnd)
        {
            if (thigh_L_Rotation > -180)
            {
                thigh_L_Rotation -= 45;
                thigh_L_Index--;
            }
        }
    }

    public void RaiseLeftCalf()
    {
        if (!GameRoot.GetInstance().gameEnd)
        {
            if (calf_L_Rotation < -90)
            {
                calf_L_Rotation += 45;
                calf_L_Index++;
            }
        }
    }

    public void LowerLeftCalf()
    {
        if (!GameRoot.GetInstance().gameEnd)
        {
            if (calf_L_Rotation > -180)
            {
                calf_L_Rotation -= 45;
                calf_L_Index--;
            }
        }
    }

    public void RaiseRightThigh()
    {
        if (!GameRoot.GetInstance().gameEnd)
        {
            if (thigh_R_Rotation < -135)
            {
                thigh_R_Rotation += 45;
                thigh_R_Index++;
            }
        }
    }

    public void LowerRightThigh()
    {
        if (!GameRoot.GetInstance().gameEnd)
        {
            if (thigh_R_Rotation > -180)
            {
                thigh_R_Rotation -= 45;
                thigh_R_Index--;
            }
        }
    }

    public void RaiseRightCalf()
    {
        if (!GameRoot.GetInstance().gameEnd)
        {
            if (calf_R_Rotation < -90)
            {
                calf_R_Rotation += 45;
                calf_R_Index++;
            }
        }
    }

    public void LowerRightCalf()
    {
        if (!GameRoot.GetInstance().gameEnd)
        {
            if (calf_R_Rotation > -180)
            {
                calf_R_Rotation -= 45;
                calf_R_Index--;
            }
        }
    }
}
