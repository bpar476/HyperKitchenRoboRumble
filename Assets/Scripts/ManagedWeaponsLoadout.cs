using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RobotConfiguration))]
public class ManagedWeaponsLoadout : MonoBehaviour
{

    private RobotConfiguration configuration;

    private AbstractWeapon frontWeaponObject;
    private AbstractWeapon backWeaponObject;

    public AbstractWeapon ActiveFrontWeapon { get { return frontWeaponObject; } }
    public AbstractWeapon ActiveBackWeapon { get { return backWeaponObject; } }

    void Start()
    {
        configuration = GetComponent<RobotConfiguration>();
        EquipWeapons();
    }

    public void RefreshLoadout()
    {
        EquipWeapons();
    }

    private void EquipWeapons()
    {
        if (frontWeaponObject != null)
        {
            frontWeaponObject.gameObject.SetActive(false);
        }
        if (backWeaponObject != null)
        {
            backWeaponObject.gameObject.SetActive(false);
        }

        RobotWeaponsManager weaponsManager = RobotWeaponsManager.Instance;
        RobotWeapon frontWeapon = weaponsManager.FrontWeapon;
        if (frontWeapon != null)
        {
            frontWeaponObject = Instantiate(weaponsManager.FrontWeapon.prefab, configuration.FrontWeaponPosition.position, Quaternion.identity, transform);
            frontWeaponObject.EquipToPlayer(gameObject);
        }
        else
        {
            Debug.Log("no front weapon equipped, not instantiating");
        }
        RobotWeapon backWeapon = weaponsManager.BackWeapon;
        if (backWeapon != null)
        {
            backWeaponObject = Instantiate(weaponsManager.BackWeapon.prefab, configuration.BackWeaponPosition.position, Quaternion.identity, transform);
            backWeaponObject.EquipToPlayer(gameObject);
        }
        else
        {
            Debug.Log("no back weapon equipped, not instantiating");
        }
    }
}
