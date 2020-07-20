using UnityEngine;
using UnityEngine.UI;

public class CustomizeMenu : MonoBehaviour
{
    public WeaponPicker picker;
    private enum WeaponEquipMode
    {
        Front, Back
    }

    private WeaponEquipMode currentEquipMode = WeaponEquipMode.Front;

    public TMPro.TextMeshProUGUI weaponSelectorTitle;

    private void Start()
    {
        SetEditMainWeapon();
    }

    public void SetEditMainWeapon()
    {
        weaponSelectorTitle.text = "Main Weapon";
        currentEquipMode = WeaponEquipMode.Front;
    }

    public void SetEditUtilityWeapon()
    {
        weaponSelectorTitle.text = "Utility Weapon";
        currentEquipMode = WeaponEquipMode.Back;
    }

    public void EquipWeapon()
    {
        if (currentEquipMode == WeaponEquipMode.Front)
        {
            RobotWeaponsManager.Instance.SetMainWeapon(picker.SelectedWeapon);
        }
        else if (currentEquipMode == WeaponEquipMode.Back)
        {
            RobotWeaponsManager.Instance.SetUtilityWeapon(picker.SelectedWeapon);
        }
        else
        {
            throw new System.Exception("Heckin where is my third arm my dude");
        }
    }
}
