using UnityEngine;

public class FireMageCreator : Creator
{
    public override Mage FactoryMethod()
    {
        var prefab = Resources.Load<GameObject>("Prefabs/mage_red");
        var go = Object.Instantiate(prefab);
        var enemyComponent = go.AddComponent<FireMage>();
        enemyComponent.transform.position += new Vector3(1,0,0);
        enemyComponent.Init(1, 10f, 2f, 4f);
        return enemyComponent;
    }
}
