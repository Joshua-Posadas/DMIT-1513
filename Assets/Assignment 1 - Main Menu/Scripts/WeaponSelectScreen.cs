using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

public class WeaponSelectScreen : MonoBehaviour
{
    public string[] customizationOptions;
    public GameObject weaponPrefab;
    public Transform parent;
    public UnityEvent OnWeaponSelected;

    private void Awake()
    {
        customizationOptions = System.Enum.GetNames(typeof(WeaponType));

    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void InitializeWeaponSelectScreen()
    {
        foreach (string option in customizationOptions)
        {
            GameObject tmp = Instantiate(weaponPrefab, parent);
            TMP_Text t = tmp.GetComponentInChildren<TMP_Text>();
            t.text = option;

            Button c = tmp.GetComponent<Button>();
            c.onClick.AddListener(delegate { CharacterSelectSingleton.Instance.SetWeaponType(option); });
            c.onClick.AddListener(delegate { OnWeaponSelected?.Invoke(); });
            c.onClick.AddListener(() => gameObject.SetActive(false));
        }
        Show();
    }
}
