using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{ 
    public static UIManager Instance;

    [Header("Start UI")]
    public TextMeshProUGUI startText;
    public TextMeshProUGUI purposeText; // ÉQÅ[ÉÄñ⁄ìIï\é¶

    [Header("Item UI")]
    public TextMeshProUGUI itemText;

    [Header("Goal UI")]
    public TextMeshProUGUI goalText;

    private void Awake()
    {
        Instance = this;
    }

    // ==== Start UI ====
    public void ShowStartUI(bool show)
    {
        startText?.gameObject.SetActive(show);
        purposeText?.gameObject.SetActive(show);
    }

    // ==== Item UI ====
    public void UpdateItem(int collected, int total)
    {
        if (itemText != null)
            itemText.text = $"Items:{collected}/{total}";
    }

    // ==== Goal UI ====
    public void ShowGoal(string message)
    {
        goalText.text = message;
        goalText.gameObject.SetActive(true);
    }

    public void HideGoal()
    {
        goalText.gameObject.SetActive(false);
    }
}
