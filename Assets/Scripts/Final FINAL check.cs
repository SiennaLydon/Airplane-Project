using UnityEngine;

public class FinalFINALcheck : MonoBehaviour
{

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
        {
            
            Debug.Log(PointCounter.pointsss);
            Destroy(gameObject);
            

            PointCounter.pointsss ++;
        }
}
