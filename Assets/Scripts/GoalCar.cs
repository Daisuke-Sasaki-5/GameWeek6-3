using UnityEngine;

public class GoalCar : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            GameManager.instance.TryClear();
        }
    }
}
