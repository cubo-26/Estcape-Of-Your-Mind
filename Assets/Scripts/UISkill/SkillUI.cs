using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillUI : MonoBehaviour
{
    public static SkillUI Instance;

    [Header("UI Elements")]
    public Image skillIcon;
    public Image cooldownOverlay;   // Image loại Filled, đặt đè lên icon
    public TextMeshProUGUI skillNameText;
    public TextMeshProUGUI cooldownText;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }
    public void UpdateSkillUI(SkillData skill)
    {
        if (skill.icon != null)
            skillIcon.sprite = skill.icon;

        skillNameText.text = skill.skillName;
        cooldownOverlay.fillAmount = 0f;
        cooldownText.text = "";
    }

    public void UpdateCooldown(float remaining, float total)
    {
        cooldownOverlay.fillAmount = remaining / total;
        cooldownText.text = remaining.ToString("F1") + "s";
    }
    public void SkillReady()
    {
        cooldownOverlay.fillAmount = 0f;
        cooldownText.text = "Ready!";
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
