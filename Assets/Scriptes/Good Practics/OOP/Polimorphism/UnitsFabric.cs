using UnityEngine;

public class UnitsFabric : MonoBehaviour
{
    [SerializeField] private Transform _spawnPosition;
    public void CreateUnit(Unit unit)
    {
        Unit instance = Instantiate(unit);
        instance.SpawnTo(_spawnPosition.position);
        instance.IssueCry();
    }
}
