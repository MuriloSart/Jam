using Entities;
using TMPro;
using UnityEngine;

public class ShieldUi : MonoBehaviour
{
    public Entity entity;
    private TextMeshProUGUI textMeshProUGUI;

    private void Start()
    {
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        TextAtualize();
    }

    public void TextAtualize()
    {
        textMeshProUGUI.text = entity.health.CurrentArmor.ToString();
    }
}
