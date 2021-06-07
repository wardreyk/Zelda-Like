using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BDC_MoovableRock : MonoBehaviour
{

    public bool upColliderOn;
    public bool downColliderOn;
    public bool leftColliderOn;
    public bool rigtColliderOn;

    public Rigidbody2D rigidBodyMoovableRock;


    private void Update()
    {
        if (Input.GetButtonDown("Interact") && leftColliderOn == true || rigtColliderOn == true || upColliderOn == true || downColliderOn == true)
        {
            MoovableRock();
        }
    }
    public void MoovableRock()
    {
        if (leftColliderOn == true || rigtColliderOn == true )
        {
            rigidBodyMoovableRock.constraints = RigidbodyConstraints2D.None;
            rigidBodyMoovableRock.constraints = RigidbodyConstraints2D.FreezePositionY;
            rigidBodyMoovableRock.constraints = RigidbodyConstraints2D.FreezeRotation;

        }
        else if (upColliderOn == true || downColliderOn == true)
        {
            rigidBodyMoovableRock.constraints = RigidbodyConstraints2D.None;
            rigidBodyMoovableRock.constraints = RigidbodyConstraints2D.FreezePositionX;
            rigidBodyMoovableRock.constraints = RigidbodyConstraints2D.FreezeRotation;

            

        }
    }

    public void UnMoovableRock()
    {
        rigidBodyMoovableRock.constraints = RigidbodyConstraints2D.FreezeRotation;
        rigidBodyMoovableRock.constraints = RigidbodyConstraints2D.FreezePosition;
        print("UnmoovablerockOn");
    }
}
