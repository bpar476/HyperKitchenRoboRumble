using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPicker : MonoBehaviour
{
    private List<GameObject> availableWeapons;
    private int currentWeaponIndex = 0;
    private GameObject activeWeapon;

    public RobotWeapon[] debugAvailableWeapons;

    private void Start()
    {
        foreach (var weapon in debugAvailableWeapons)
        {
            RobotWeaponsManager.Instance.UnlockWeapon(weapon);
        }

        availableWeapons = new List<GameObject>();

        foreach (var unlockedWeapon in RobotWeaponsManager.Instance.GetWeapons())
        {
            Debug.Log("spawning weapon");
            var startPos = new Vector3(400, 0, -1);

            // The spatula sprite is not aligned with the position of the root game object because its pivot is funny
            // We have to hardcode a different position
            if (unlockedWeapon.weaponName == "spatula")
            {
                startPos = new Vector3(300, 75, -1);
            }

            var weapon = Instantiate(unlockedWeapon.prefab, Vector3.zero, Quaternion.identity, transform);
            weapon.transform.localScale *= 50;
            weapon.transform.localPosition = startPos;
            weapon.SetActive(false);
            availableWeapons.Add(weapon);
        }
        RenderCurrentWeapon();
    }

    public void NextWeapon()
    {
        currentWeaponIndex += 1;
        if (currentWeaponIndex >= availableWeapons.Count)
        {
            currentWeaponIndex = 0;
        }
        RenderCurrentWeapon();
    }

    public void PreviousWeapon()
    {
        currentWeaponIndex -= 1;
        if (currentWeaponIndex < 0)
        {
            currentWeaponIndex = availableWeapons.Count - 1;
        }
        RenderCurrentWeapon();
    }

    private void RenderCurrentWeapon()
    {
        if (activeWeapon != null)
        {
            activeWeapon.SetActive(false);
        }
        if (availableWeapons.Count == 0)
        {
            // No weapons unlocked
        }
        else if (currentWeaponIndex >= availableWeapons.Count)
        {
            // Bad state, reset to first
            currentWeaponIndex = 0;
            RenderCurrentWeapon();
        }
        else
        {
            activeWeapon = availableWeapons[currentWeaponIndex];
            activeWeapon.SetActive(true);
        }
    }


}
