using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Clock;
    float metersCount;
    int minutes, seconds;
   
    private void Update()
    {
         metersCount += Time.deltaTime;
         minutes = Mathf.FloorToInt(metersCount / 60F);
         seconds = Mathf.FloorToInt(metersCount % 60F);
        Clock.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

}
