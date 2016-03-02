/******************************************************************************\
* Copyright (C) Leap Motion, Inc. 2011-2014.                                   *
* Leap Motion proprietary. Licensed under Apache 2.0                           *
* Available at http://www.apache.org/licenses/LICENSE-2.0.html                 *
\******************************************************************************/

using UnityEngine;
using System.Collections;
using Leap;

/**
* The finger model for our debugging. Draws debug lines for each bone.
*/
public class HandCoordinate : MonoBehaviour
{
    Controller controller = new Controller();
    public Vector3 modelFingerPointing = Vector3.forward;
    public Vector3 modelPalmFacing = -Vector3.up;
    public float XAxis, YAxis,ZAxis;
    public Vector handBasis;
    
    void Update()
    {
        Frame frame = controller.Frame();
        Hand hands = frame.Hands[0];
        handBasis = hands.PalmPosition;
        XAxis = handBasis.x;
        YAxis = handBasis.y;
        ZAxis = handBasis.z;

        XAxis = digits(XAxis);
        YAxis = digits(YAxis);
        ZAxis = digits(ZAxis);
    }

    float digits(float Axis)
    {
        int b = (int)(Axis * 10);
        Axis = (float)b / 10;

        return Axis;
    }
   
   void OnGUI()
    {

        GUI.Box(new Rect(10, 80, 150, 23), "X:" + XAxis);
        GUI.Box(new Rect(10, 110, 150, 23), "Y:" + YAxis);
        GUI.Box(new Rect(10, 140, 150, 23), "Z:" + ZAxis);
    }
}
