using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractWeapon : MonoBehaviour
{
    public abstract void Use();
    public abstract void StopUsing();
    public abstract void EquipToPlayer(GameObject player);

}
