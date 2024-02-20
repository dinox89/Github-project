
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class PLAYERANDROID : MonoBehaviour, IAgentInput
{
 
    public event Action OnJumpPressed;
    public event Action OnJumpRelease;
  
 

  






    public void JumpPressed()
    {
        OnJumpPressed?.Invoke();
    }

    public void JumpRelease()
    {
        OnJumpRelease?.Invoke();
    }
}
