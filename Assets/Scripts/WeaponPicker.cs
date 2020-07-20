using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPicker : MonoBehaviour
{
    private LinkedList<GameObject> availableWeapons;
    private LinkedListNode<GameObject> currentWeaponIndex;
    private GameObject activeWeapon;

    public GameObject SelectedWeapon { get { return activeWeapon; } }
    public RobotWeapon[] debugAvailableWeapons;

    private void Start()
    {
        foreach (var weapon in debugAvailableWeapons)
        {
            RobotWeaponsManager.Instance.UnlockWeapon(weapon);
        }

        availableWeapons = new LinkedList<GameObject>();

        foreach (var unlockedWeapon in RobotWeaponsManager.Instance.GetWeapons())
        {
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
            availableWeapons.AddLast(weapon);
        }
        RenderCurrentWeapon();
    }

    public void NextWeapon()
    {
        if (currentWeaponIndex.Equals(availableWeapons.Last))
        {
            currentWeaponIndex = availableWeapons.First;
        }
        else
        {
            currentWeaponIndex = currentWeaponIndex.Next;
        }
        RenderCurrentWeapon();
    }

    public void PreviousWeapon()
    {
        if (currentWeaponIndex.Equals(availableWeapons.First))
        {
            currentWeaponIndex = availableWeapons.Last;
        }
        else
        {
            currentWeaponIndex = currentWeaponIndex.Previous;
        }
        RenderCurrentWeapon();
    }

    private void RenderCurrentWeapon()
    {
        if (currentWeaponIndex == null)
        {
            currentWeaponIndex = availableWeapons.First;
        }

        if (activeWeapon != null)
        {
            activeWeapon.SetActive(false);
        }
        if (availableWeapons.Count == 0)
        {
            // No weapons unlocked
        }
        else
        {
            activeWeapon = currentWeaponIndex.Value;
            activeWeapon.SetActive(true);
        }
    }
}
