using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private GameObject[] weapons;
    [SerializeField] private Transform weaponHolder;

    private int currentWeaponIndex = -1;

    void Start()
    {
        foreach (GameObject weapon in weapons)
        {
            weapon.SetActive(false);
        }

        SwitchWeapon(0);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            SwitchWeapon(0);

        if (Input.GetKeyDown(KeyCode.Alpha2))
            SwitchWeapon(1);

        if (Input.GetKeyDown(KeyCode.Alpha3))
            SwitchWeapon(2);
    }

    void SwitchWeapon(int index)
    {
        if (index < 0 || index >= weapons.Length)
            return;

        if (currentWeaponIndex == index)
            return;

        if (currentWeaponIndex >= 0)
            weapons[currentWeaponIndex].SetActive(false);

        weapons[index].SetActive(true);

        currentWeaponIndex = index;
    }
}
