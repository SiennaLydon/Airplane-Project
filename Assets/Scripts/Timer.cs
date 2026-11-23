using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Timer_Txt;
   
    private int Seconds = 0;

    void Start()
    {
        StartCoroutine(Timer_Count());
    }

    IEnumerator Timer_Count()
    {
        while(Seconds < 10)
        {
            yield return new WaitForSeconds(1);
            Seconds++;
            UpdateTimer();
        }

         Debug.Log("Took too long");
         Seconds = 0;
         UpdateTimer();
         StopCoroutine(Timer_Count());
    }

    private void UpdateTimer()
    {
        int min = Mathf.FloorToInt(Seconds / 60);
        int sec = Mathf.FloorToInt(Seconds % 60);

        Timer_Txt.text = min.ToString("00") + ":" + sec.ToString("00");
    }
}
