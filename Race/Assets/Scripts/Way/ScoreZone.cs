using UnityEngine;

public class ScoreZone : MonoBehaviour
{
    private void OnEnable()
    {
        foreach (Transform obstacle in transform)
        {
            ActivateObstacle(obstacle);
        }
    }

    private void ActivateObstacle(Transform obstacle)
    {
        if (obstacle.TryGetComponent(out Enemy enemyCar))
        {
            if (enemyCar.gameObject.activeSelf == false)
            {
                enemyCar.gameObject.SetActive(true);
            }
        }
    }
}
