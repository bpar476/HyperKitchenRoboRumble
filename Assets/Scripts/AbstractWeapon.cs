using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractWeapon : MonoBehaviour
{
    public abstract void Use();

    // Optional hooks for using weapon

    // Will be called when the action of using the weapon is stopped
    // Could be used for rapid fire or something that should be continuous
    public virtual void StopUsing() { }
    public virtual void EquipToPlayer(GameObject player) { }

}
