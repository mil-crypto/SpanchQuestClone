
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    public abstract void IssueCry();

    public void SpawnTo(Vector3 spawnPoint)
    {
        Vector3 randomPoint = Random.insideUnitCircle * 3;
        transform.position = spawnPoint + new Vector3(randomPoint.x, 0, randomPoint.y);
    }
}
