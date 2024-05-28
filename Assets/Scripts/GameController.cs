
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] TextOutLinners Clock,DaysTx, scheduleTx;
    [SerializeField] float speedTime=1f;
    float CountClock;
    int minutes, seconds;
    int Days=1;
    bool am=true;
    private void Start()
    {
      
        SceneManager.LoadScene(2,LoadSceneMode.Additive);
        DaysTx.AsignText("Day:" + Days);
    }
    private void Update()
    {
         CountClock += Time.deltaTime* speedTime;
         minutes = Mathf.FloorToInt(CountClock / 60F);
         seconds = Mathf.FloorToInt(CountClock % 60F);
        Debug.Log(minutes);
        if (minutes > 12) { 
            minutes = 1; 
            am = !am;
            if (am) Days++;
            DaysTx.AsignText("Day:"+Days);
            if (am) scheduleTx.AsignText("am");
            else scheduleTx.AsignText("pm");
        }
        
        Clock.AsignText(string.Format("{0:00}:{1:00}", minutes, seconds));

    }

}
