using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // [SerializeField] private float speed = 5.0f;
    [SerializeField] private float invincibilityDuration = 1.0f;
    private bool isInvincible = false;
    private int lives = 3;
    private Material material;
    private Color originalColor;
    // private UIManager lifeManager;

    private void Awake()
    {
        material = GetComponent<Renderer>().material;
        originalColor = material.color;
    }

    void Start()
    {
        UIManager.Instance.UpdateLives(lives);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") && !isInvincible)
        {
            LoseLife();
            other.gameObject.SetActive(false);
        }
    }

    private void LoseLife()
    {
        lives--;
        UIManager.Instance.UpdateLives(lives);

        if (lives <= 0)
        {
            Debug.Log("Game Over");
        }
        else
        {
            StartCoroutine(Invincibility());
        }
    }

    private IEnumerator Invincibility()
    {
        isInvincible = true;
        material.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0.5f);

        yield return new WaitForSeconds(invincibilityDuration);

        material.color = originalColor;
        isInvincible = false;
    }
}
