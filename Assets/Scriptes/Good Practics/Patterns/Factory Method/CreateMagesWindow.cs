using UnityEngine;
using UnityEngine.UI;

public class CreateMagesWindow : MonoBehaviour
{
    [SerializeField] private Button _createFireMageButton;
    [SerializeField] private Button _createIceMageButton;

    private void Awake()
    {
        _createFireMageButton.onClick.AddListener(() =>
        {
            Creator creator = new FireMageCreator();
            Mage fireMage = creator.FactoryMethod();
            fireMage.CastSpell();
        });

        _createIceMageButton.onClick.AddListener(() =>
        {
            Creator creator = new IceMageCreator();
            Mage iceMage = creator.FactoryMethod();
            iceMage.CastSpell();
        });
    }
}
