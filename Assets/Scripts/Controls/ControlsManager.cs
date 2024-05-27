using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsManager : MonoBehaviour
{

    Map map;
    static Map.ControlsActions controls;
    private void Awake()
    {
        map = new Map();
        controls= map.controls;
    }
    public static Map.ControlsActions getControls() { return controls; }
    private void OnEnable()
    {
        map.Enable();
    }
    private void OnDisable()
    {
        map.Disable();
    }
}
