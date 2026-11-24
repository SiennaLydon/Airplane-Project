using UnityEngine;
using TMPro;

public class FinalStats : MonoBehaviour

{
    [SerializeField] TextMeshProUGUI Stats;

    public static bool done = false;

    private void OnTriggerEnter(Collider other)
    {
        
        Stats.text = ("Your score: " + PointCounter.pointsss + " / 28  Your time: " + Timer.Seconds + " seconds");
        Timer.Seconds = 2000;
    }
}




