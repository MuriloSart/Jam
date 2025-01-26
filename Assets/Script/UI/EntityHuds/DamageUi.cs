using Entities;
using TMPro;
using UnityEngine;

public class DamageUi : MonoBehaviour
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
        textMeshProUGUI.text = entity.Damage.ToString();
    }
}
