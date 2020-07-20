using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RobotConfiguration))]
public class ManagedWeaponsLoadout : MonoBehaviour
{

    private RobotConfiguration configuration;

    void Start()
    {
        RobotWeaponsManager weaponsManager = RobotWeaponsManager.Instance;
        GameObject frontWeapon = Instantiate(weaponsManager.FrontWeapon.prefab, configuration.FrontWeaponPosition.position, Quaternion.identity, transform);
        GameObject backWeapon = Instantiate(weaponsManager.BackWeapon.prefab, configuration.BackWeaponPosition.position, Quaternion.identity, transform);
    }
}
