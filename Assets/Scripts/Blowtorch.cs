using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blowtorch : AbstractWeapon
{
    public GameObject flame;
    public float power;
    public Rigidbody2D attachedBody;


    public override void EquipToPlayer(GameObject player)
    {
        var rb = player.GetComponent<Rigidbody2D>();
        if (rb == null)
            Debug.LogError("Attaching blowtorch to game object with no rigidbody does nothing");

        attachedBody = rb;

    }

    public override void Use()
    {
        flame.SetActive(true);
        if (attachedBody != null)
        {
            // Only happens in UI
            attachedBody.AddForce(transform.right.normalized * power);
        }
    }

    public override void StopUsing()
    {
        flame.SetActive(false);
    }
}
