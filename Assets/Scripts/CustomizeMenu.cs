using UnityEngine;
using UnityEngine.UI;

public class CustomizeMenu : MonoBehaviour
{

    public TMPro.TextMeshProUGUI weaponSelectorTitle;

    private void Start()
    {
        SetEditMainWeapon();
    }

    public void SetEditMainWeapon()
    {
        weaponSelectorTitle.text = "Main Weapon";
    }

    public void SetEditUtilityWeapon()
    {
        weaponSelectorTitle.text = "Utility Weapon";
    }

}
