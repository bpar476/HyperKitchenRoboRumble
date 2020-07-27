using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockWeaponsMenu : MonoBehaviour
{

    public RobotWeapon[] weaponsToUnlock;
    public RectTransform customizeMenu;
    // Start is called before the first frame update
    void Start()
    {
        RobotWeaponsManager manager = RobotWeaponsManager.Instance;
        foreach (var weapon in weaponsToUnlock)
        {
            manager.UnlockWeapon(weapon);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            customizeMenu.gameObject.SetActive(true);
            Destroy(gameObject);
        }
    }
}
