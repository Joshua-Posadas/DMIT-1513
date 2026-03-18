using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [System.Serializable]
    public class WeaponSlot
    {
        public string weaponName;
        public GameObject weaponObject;
        public KeyCode switchKey;
    }

    [Header("Weapon Slots")]
    public WeaponSlot[] weapons;

    private GameObject currentWeapon;

    private void Start()
    {
        if (weapons.Length > 0)
        {
            EquipWeapon(weapons[0].weaponObject);
        }
    }

    private void Update()
    {
        foreach (var slot in weapons)
        {
            if (Input.GetKeyDown(slot.switchKey))
            {
                EquipWeapon(slot.weaponObject);
            }
        }
    }

    private void EquipWeapon(GameObject weapon)
    {
        if (currentWeapon == weapon) return;

        foreach (var slot in weapons)
        {
            if (slot.weaponObject != null)
                slot.weaponObject.SetActive(false);
        }

        weapon.SetActive(true);
        currentWeapon = weapon;
    }
}

