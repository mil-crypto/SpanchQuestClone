using UnityEngine;

public class IceMageCreator : Creator
{
    public override Mage FactoryMethod()
    {
        var prefab = Resources.Load<GameObject>("Prefabs/mage_blue");
        var go = Object.Instantiate(prefab);
        var enemyComponent = go.AddComponent<IceMage>();
        enemyComponent.transform.position += new Vector3(0, 1, 0);
        enemyComponent.Init(3, 5f, 4f, 2f);
        return enemyComponent;
    }
}
