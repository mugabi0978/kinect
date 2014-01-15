using UnityEngine;
using System.Collections;
using System;
using OmekFramework.Common.Main;
using System.Text;
using Omek;

public class Walk : MonoBehaviour
{
  /// <summary>
  /// which gesture will be considered
  /// </summary>
  public string[] m_walkGestures = { "leftKneeUp", "rightKneeUp" };
  /// <summary>
  /// what method to call
  /// </summary>
  public string WalkListnerName = "OnWalk";

  IntPtr handle;

  // Use this for initialization
  void Start()
  {
    handle = new IntPtr();
  }

  // Update is called once per frame
  // check for the gestures of the person
  void Update()
  {
    uint result = IMotionSensorDotNet.runSensor(handle);

      bool isWalkGestures = false;
      foreach (string gestureName in m_walkGestures)
      {
        
        // enabling and disabling gestures: StringBuilder rightClick = new StringBuilder("click"); result = IMotionSensorDotNet.enableGesture(handle, rightClick); result = IMotionSensorDotNet.disableGesture(handle, rightClick); // retrieving the gestures of the current frame StringBuilder gestureName = new StringBuilder(); uint playerLabel = 0; while (IMotionSensorDotNet.hasMoreGestures(handle, out ref hasGestures) == 0 && hasGestures == true) { IntPtr gesture = IMotionSensorDotNet.popNextGesture(handle); IMotionSensorDotNet.getFiredEventName(gesture, gestureName, 1000); }

        /*

        // enabling and disabling gestures: 
        StringBuilder rightClick = new StringBuilder(gestureName); 
        result = IMotionSensorDotNet.enableGesture(handle, rightClick); 
        result = IMotionSensorDotNet.disableGesture(handle, rightClick); 

        uint playerLabel = 0; 
        while (IMotionSensorDotNet.hasMoreGestures(handle, out ref hasGestures) == 0 && hasGestures == true) 
        { 
          IntPtr gesture = IMotionSensorDotNet.popNextGesture(handle); 
          IMotionSensorDotNet.getFiredEventName(gesture, gestureName, 1000); 
        }


        foreach (PointerListener.PointerHit ph in m_pointerlistener.m_curInPointers)
        {
          if (ph.m_pointerRef.m_personID != PointerListener.MOUSE_POINTER_ID)
          {
            if (FrameworkManager.GenericInstance.Gestures.IsGestureActive(gestureName, (uint)ph.m_pointerRef.m_personID))
            {
              isClickGesture = true;
              break;
            }
          }
        }
        */
        if (isWalkGestures)
        {
          break;
        }
      }

      // walking
      if (isWalkGestures)
      {
        SendMessage(WalkListnerName, SendMessageOptions.DontRequireReceiver);
      }
    }
  }
}
