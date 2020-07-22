using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ManagedWeaponsLoadout))]
public class RobotWeaponUsage : MonoBehaviour
{

    private ManagedWeaponsLoadout loadout;

    private void Awake()
    {
        loadout = GetComponent<ManagedWeaponsLoadout>();
    }

    private void Update()
    {
        var frontWeaponObject = loadout.ActiveFrontWeapon;
        var backWeaponObject = loadout.ActiveBackWeapon;
        if (Input.GetAxis("Fire1") > 0)
        {
            frontWeaponObject.Use();
        }
        else
        {
            frontWeaponObject.StopUsing();
        }
        if (Input.GetAxisRaw("Fire2") != 0)
        {
            backWeaponObject.Use();
        }
        else
        {
            backWeaponObject.StopUsing();
        }
    }
}
