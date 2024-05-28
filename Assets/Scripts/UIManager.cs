using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    Animator anim;
    bool state;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void PhoneOpen()
    {
        state = !state;
        if(state) anim.Play("Open");
         else anim.Play("Close");
    }
}
