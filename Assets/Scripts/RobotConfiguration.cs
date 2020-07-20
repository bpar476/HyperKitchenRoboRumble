using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotConfiguration : MonoBehaviour
{
    [SerializeField]
    private Transform _frontWeaponPosition;
    [SerializeField]
    private Transform _backWeaponPosition;

    public Transform FrontWeaponPosition { get { return _frontWeaponPosition; } }
    public Transform BackWeaponPosition { get { return _backWeaponPosition; } }
}
