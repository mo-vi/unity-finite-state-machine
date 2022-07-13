using TMPro;
using UnityEngine;

public class ManagerUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textAmmo;
    [SerializeField] private TextMeshProUGUI textState;

    public void UpdateAmmoString(string value)
    {
        if (!textState) return;

        textAmmo.text = value;
    }

    public void UpdateStateString(string value)
    {
        if (!textState) return;

        textState.text = $"State: {value}";
    }
}
