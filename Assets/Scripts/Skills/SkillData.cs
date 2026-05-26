using UnityEngine;

[CreateAssetMenu(fileName = "SkillData", menuName = "Scriptable Objects/SkillData")]
public class SkillData : ScriptableObject
{
    public string skillName;
    public string description;
    public Sprite icon;

    public float cooldown = 3f;
    public SkillType skillType;

    public enum SkillType
    {
        JumpBoost,
        Dash,
        PhaseThrough,
        Grapple
    }
    
}
