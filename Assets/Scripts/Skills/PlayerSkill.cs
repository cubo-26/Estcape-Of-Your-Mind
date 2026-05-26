using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    private SkillData currentSkill;
    private float cooldownTimer = 0f;
    private bool isOnCooldown = false;

    // Tham chiếu các component cần dùng
    private Rigidbody2D rb;
    private PlayerController playerController;

    [Header("Phase Through")]
    public Collider2D playerCollider;
    public LayerMask groundLayer;

    [Header("Grapple")]
    public float grappleRange = 8f;
    public LineRenderer grappleLine; // thêm LineRenderer vào Player

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Instance.IsPlaying()) return;

        // Đếm cooldown
        if (isOnCooldown)
        {
            cooldownTimer -= Time.deltaTime;
            SkillUI.Instance?.UpdateCooldown(cooldownTimer, currentSkill.cooldown);

            if (cooldownTimer <= 0f)
            {
                isOnCooldown = false;
                SkillUI.Instance?.SkillReady();
            }
        }
        // Bấm E để dùng skill
        if (Input.GetKeyDown(KeyCode.E) && !isOnCooldown && currentSkill != null)
        {
            UseSkill();
        }
    }
    public void OnSkillChanged(SkillData skill)
    {
        currentSkill = skill;
        isOnCooldown = false;
        cooldownTimer = 0f;
    }
    void UseSkill()
    {
        switch (currentSkill.skillType)
        {
            case SkillData.SkillType.JumpBoost:    DoJumpBoost();    break;
            case SkillData.SkillType.Dash:         DoDash();         break;
            case SkillData.SkillType.PhaseThrough: DoPhaseThrough(); break;
            case SkillData.SkillType.Grapple:      DoGrapple();      break;
        }

        // Bắt đầu cooldown
        isOnCooldown = true;
        cooldownTimer = currentSkill.cooldown;
    }

    // ── Các skill ────────────────────────────────────────────

    void DoJumpBoost()
    {
        // Nhảy cao gấp đôi, không cần chạm đất
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, 18f);
        AudioManager.Instance.PlayJumpSound();
    }

    // dash nhanh ngang theo hướng input hoặc hướng đang nhìn
    void DoDash()
    {
    // Đọc input thực tế thay vì localScale
    float input = Input.GetAxisRaw("Horizontal");

    // Nếu không giữ phím thì dùng hướng đang nhìn
    float direction = input != 0 ? input : (transform.localScale.x > 0 ? 1f : -1f);

    // Tắt gravity tạm để dash ngang mượt
    rb.gravityScale = 0f;
    rb.linearVelocity = new Vector2(direction * 18f, 0f);

    // Bật lại gravity sau 0.2s
    StartCoroutine(ResetGravityAfterDash());
    }
    System.Collections.IEnumerator ResetGravityAfterDash()
    {
    yield return new WaitForSeconds(1f);
    rb.gravityScale = 5f;
    }

    void DoPhaseThrough()
    {
        // Xuyên qua nền tảng trong 0.5 giây
        StartCoroutine(PhaseThroughCoroutine());
    }
    System.Collections.IEnumerator PhaseThroughCoroutine()
    {
        // Tắt va chạm với Ground
        Physics2D.IgnoreLayerCollision(
            gameObject.layer,
            LayerMaskToLayer(groundLayer),
            true
        );

        yield return new WaitForSeconds(0.5f);

        // Bật lại va chạm
        Physics2D.IgnoreLayerCollision(
            gameObject.layer,
            LayerMaskToLayer(groundLayer),
            false
        );
    }
   void DoGrapple()
    {
    // Tìm tất cả GrapplePoint trong scene
    GameObject[] grapplePoints = GameObject.FindGameObjectsWithTag("GrapplePoint");

    if (grapplePoints.Length == 0)
    {
        isOnCooldown = false;
        Debug.Log("Không có điểm bám nào!");
        return;
    }

    // Tìm điểm bám gần nhất trong tầm
    GameObject nearest = null;
    float minDist = grappleRange;

    foreach (GameObject point in grapplePoints)
    {
        float dist = Vector2.Distance(transform.position, point.transform.position);
        if (dist < minDist)
        {
            minDist = dist;
            nearest = point;
        }
    }

    if (nearest != null)
    {
        StartCoroutine(GrappleCoroutine(nearest.transform.position));
    }
    else
    {
        // Không có điểm nào trong tầm → không tốn cooldown
        isOnCooldown = false;
        Debug.Log("Không có điểm bám trong tầm!");
    }
    }
    System.Collections.IEnumerator GrappleCoroutine(Vector2 target)
    {
        if (grappleLine) grappleLine.enabled = true;

        float elapsed = 0f;
        Vector2 startPos = transform.position;

        while (elapsed < 0.3f)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / 0.3f;
            transform.position = Vector2.Lerp(startPos, target, t);

            if (grappleLine)
            {
                grappleLine.SetPosition(0, transform.position);
                grappleLine.SetPosition(1, target);
            }

            yield return null;
        }

        if (grappleLine) grappleLine.enabled = false;
    }
    // Helper: chuyển LayerMask sang layer index
    int LayerMaskToLayer(LayerMask mask)
    {
        int val = mask.value;
        int layer = 0;
        while (val > 1) { val >>= 1; layer++; }
        return layer;
    }
}
