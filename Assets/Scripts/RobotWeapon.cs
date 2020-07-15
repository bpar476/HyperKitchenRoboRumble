using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "Robot Weapon")]
public class RobotWeapon : ScriptableObject
{
    public string weaponName;
    public GameObject prefab;
}
