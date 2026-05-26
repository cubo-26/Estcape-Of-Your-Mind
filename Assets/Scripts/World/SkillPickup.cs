using UnityEngine;

public class SkillPickup : MonoBehaviour
{
    private SpriteRenderer sr;
    public SkillData skillToGive;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        // Hiển thị icon của skill random sẽ nhận
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SkillManager.Instance.AssignSpecificSkill(skillToGive);
            AudioManager.Instance.PlayPowerUpSound();
            Destroy(gameObject);
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
