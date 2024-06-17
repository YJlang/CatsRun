using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rbody;
    private float jumpForce = 680.0f; // ������ ��
    private float autoMoveSpeed = 2.0f; // �ڵ� �̵� �ӵ�
    private float maxWalkSpeed = 7.0f; // �ִ� �̵� �ӵ�
    private bool GroundFlag = false;
    private Animator animator;
    private int jumpCount = 0; // ���� ī��Ʈ
    //����UI
    public Text ScoreText;
    public int ScorePoint = 0;
    //�÷��̾� HP��
    public float PlayerHP = 100.0f;
    public Image HpBar;
    //ī�޶�
    private Camera mainCamera;
    private bool isSpinning = false; // ȸ�� ������ ����

    void Start()
    {
        this.rbody = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (transform.position.y < -20.0f)
        {
            PlayerHP = 0;
            HpBar.fillAmount = 0;
            Debug.Log("�÷��̾� ����");
            Debug.Log("�ְ����� : " + ScorePoint);
            SceneManager.LoadScene("EndScene");
        }

        // ���� �� ���� ����
        if (Input.GetKeyDown(KeyCode.Space) && (GroundFlag || jumpCount < 1))
        {
            rbody.velocity = new Vector2(rbody.velocity.x, 0); // ���� y �ӵ��� �ʱ�ȭ
            rbody.AddForce(transform.up * jumpForce);
            jumpCount++;
            if (jumpCount == 1)
            {
                animator.SetBool("IsJumping", true);
                animator.SetBool("IsDoubleJumping", false);
            }
            else
            {
                animator.SetBool("IsDoubleJumping", true);
            }
        }

        // �������� �ڵ� �̵�
        if (!isSpinning)
        {
            Vector2 newVelocity = rbody.velocity;
            newVelocity.x = autoMoveSpeed;
            float speedx = Mathf.Abs(newVelocity.x);

            // �̵� �ӵ� ����
            newVelocity.x = Mathf.Clamp(newVelocity.x, -maxWalkSpeed, maxWalkSpeed);

            rbody.velocity = newVelocity;

            // ���� ��ȯ (�׻� �������� ���ϰ� ��)
            Vector3 scale = transform.localScale;
            scale.x = Mathf.Abs(scale.x);
            transform.localScale = scale;

            // �ִϸ����� �ӵ� ����
            this.animator.speed = speedx / 2.0f;
        }
    }

    public void ScoreUp()
    {
        ScorePoint += 100;
        ScoreText.text = ScorePoint.ToString();
    }

    public void PlayerHPMinus()
    {
        PlayerHP -= 10.0f;
        if (PlayerHP < 1)
        {
            Debug.Log("�ְ����� : " + ScorePoint);
            SceneManager.LoadScene("EndScene");
        }
        HpBar.fillAmount = PlayerHP / 100.0f;
    }

    public void SpinPlayer()
    {
        if (!isSpinning)
        {
            StartCoroutine(SpinRoutine());
        }
    }

    private IEnumerator SpinRoutine()
    {
        isSpinning = true;
        float spinDuration = 1.5f; // ȸ�� ���� �ð�
        float spinSpeed = 720.0f; // ȸ�� �ӵ� (��/��)
        float elapsedTime = 0.0f;

        while (elapsedTime < spinDuration)
        {
            float rotationAmount = spinSpeed * Time.deltaTime;
            transform.Rotate(0, 0, rotationAmount);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // ȸ�� �Ϸ� �� ���� ������ ����
        transform.rotation = Quaternion.identity;
        isSpinning = false;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        GroundFlag = true;
        jumpCount = 0; // ���� ������ ���� ī��Ʈ �ʱ�ȭ
        animator.SetBool("IsJumping", false);
        animator.SetBool("IsDoubleJumping", false);
        animator.SetBool("IsWalking", true); // Walk ���·� ���ư���
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        GroundFlag = false;
        animator.SetBool("IsWalking", false); // ���߿� ���� �� Walk ���� ����
    }
}
