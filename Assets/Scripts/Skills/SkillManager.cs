using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public static SkillManager Instance;

    [Header("All Skills trong game")]
    public SkillData[] allSkills; // Kéo 4 skill asset vào đây

    public SkillData CurrentSkill { get; private set; }

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        
    }
    
    public void AssignSpecificSkill(SkillData skill)
    {
    CurrentSkill = skill;
    FindAnyObjectByType<PlayerSkill>()?.OnSkillChanged(CurrentSkill);
    SkillUI.Instance?.UpdateSkillUI(CurrentSkill);

    Debug.Log($"Skill nhận được: {CurrentSkill.skillName}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
