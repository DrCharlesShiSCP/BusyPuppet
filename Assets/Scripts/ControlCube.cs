using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCube : MonoBehaviour
{

    public GameObject arm_L;
    public GameObject arm_R;

    public GameObject foreArm_R;
    public GameObject foreArm_L;

    public PuppetControl puppetControl;

    public List<Transform> heights= new List<Transform>();
    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ChangeArmCubeHeight();
        CheckForeArmCubeHeight();
    }

    public void ChangeArmCubeHeight()
    {
        if (puppetControl != null)
        {
            if(puppetControl.arm_L_Index == 0)
            {
                Vector3 pos = arm_L.transform.position;
                arm_L.transform.position = new Vector3(pos.x, heights[1].position.y, pos.z);
            }
            else if (puppetControl.arm_L_Index == 1)
            {
                Vector3 pos = arm_L.transform.position;
                arm_L.transform.position = new Vector3(pos.x, heights[2].position.y, pos.z);
            }
            else if (puppetControl.arm_L_Index == 2)
            {
                Vector3 pos = arm_L.transform.position;
                arm_L.transform.position = new Vector3(pos.x, heights[3].position.y, pos.z);
            }

            if (puppetControl.arm_R_Index == 0)
            {
                Vector3 pos = arm_R.transform.position;
                arm_R.transform.position = new Vector3(pos.x, heights[1].position.y, pos.z);
            }
            else if (puppetControl.arm_R_Index == 1)
            {
                Vector3 pos = arm_R.transform.position;
                arm_R.transform.position = new Vector3(pos.x, heights[2].position.y, pos.z);
            }
            else if (puppetControl.arm_R_Index == 2)
            {
                Vector3 pos = arm_R.transform.position;
                arm_R.transform.position = new Vector3(pos.x, heights[3].position.y, pos.z);
            }
        }
    }

    public void CheckForeArmCubeHeight()
    {
        if (puppetControl != null)
        {
            if (puppetControl.foreArm_L_Index == 0)
            {
                Vector3 pos = foreArm_L.transform.position;
                foreArm_L.transform.position = new Vector3(pos.x, heights[0].position.y, pos.z);
            }
            else if (puppetControl.foreArm_L_Index == 1)
            {
                Vector3 pos = foreArm_L.transform.position;
                foreArm_L.transform.position = new Vector3(pos.x, heights[1].position.y, pos.z);
            }
            else if (puppetControl.foreArm_L_Index  == 2)
            {
                Vector3 pos = foreArm_L.transform.position;
                foreArm_L.transform.position = new Vector3(pos.x, heights[2].position.y, pos.z);
            }
            else if (puppetControl.foreArm_L_Index == 3)
            {
                Vector3 pos = foreArm_L.transform.position;
                foreArm_L.transform.position = new Vector3(pos.x, heights[3].position.y, pos.z);
            }
            else if (puppetControl.foreArm_L_Index == 4)
            {
                Vector3 pos = foreArm_L.transform.position;
                foreArm_L.transform.position = new Vector3(pos.x, heights[4].position.y, pos.z);
            }


            if (puppetControl.foreArm_R_Index == 0)
            {
                Vector3 pos = foreArm_R.transform.position;
                foreArm_R.transform.position = new Vector3(pos.x, heights[0].position.y, pos.z);
            }
            else if (puppetControl.foreArm_R_Index == 1)
            {
                Vector3 pos = foreArm_R.transform.position;
                foreArm_R.transform.position = new Vector3(pos.x, heights[1].position.y, pos.z);
            }
            else if (puppetControl.foreArm_R_Index == 2)
            {
                Vector3 pos = foreArm_R.transform.position;
                foreArm_R.transform.position = new Vector3(pos.x, heights[2].position.y, pos.z);
            }
            else if (puppetControl.foreArm_R_Index == 3)
            {
                Vector3 pos = foreArm_R.transform.position;
                foreArm_R.transform.position = new Vector3(pos.x, heights[3].position.y, pos.z);
            }
            else if (puppetControl.foreArm_R_Index == 4)
            {
                Vector3 pos = foreArm_R.transform.position;
                foreArm_R.transform.position = new Vector3(pos.x, heights[4].position.y, pos.z);
            }
        }
    }
}
