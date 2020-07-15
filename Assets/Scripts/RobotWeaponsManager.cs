using System.Collections.Generic;
using UnityEngine;

public class RobotWeaponsManager : MonoBehaviour
{

    private static RobotWeaponsManager m_instance;
    public static RobotWeaponsManager Instance { get { return m_instance; } }

    private RobotWeapon mainWeapon;
    private RobotWeapon utilityWeapon;

    private HashSet<RobotWeapon> unlockedWeapons;

    private void Awake()
    {
        if (m_instance != null && m_instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            m_instance = this;
        }

        unlockedWeapons = new HashSet<RobotWeapon>();
    }

    public void UnlockWeapon(RobotWeapon weapon)
    {
        Debug.Log("unlocking weapon");
        unlockedWeapons.Add(weapon);
    }

    public void SetMainWeapon(RobotWeapon weapon)
    {
        if (unlockedWeapons.Contains(weapon))
            mainWeapon = weapon;
    }

    public void SetUtilityWeapon(RobotWeapon weapon)
    {
        if (unlockedWeapons.Contains(weapon))
        {
            utilityWeapon = weapon;
        }
    }

    public IReadOnlyCollection<RobotWeapon> GetWeapons()
    {
        Debug.Log("unlocked weapons has this many weapons");
        Debug.Log(unlockedWeapons.Count);
        return unlockedWeapons;
    }
}
