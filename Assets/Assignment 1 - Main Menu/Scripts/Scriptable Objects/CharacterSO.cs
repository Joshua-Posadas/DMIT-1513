using UnityEngine;

[CreateAssetMenu(fileName = "CharacterSO", menuName = "Character/CharacterSO")]
public class CharacterSO : ScriptableObject
{
    public string characterName;
    public Sprite characterSprite;
    public GameObject prefab;

    public WeaponType weaponType;
}

public enum WeaponType
{
    MAC_10,
    M4_CARBINE,
    REMINGTON_870,
    LASER_RIFLE,
    PLASMA_RIFLE
}

public enum Skin
{
    RED,
    BLUE,
    GREE,
    PINK
}
