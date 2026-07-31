using UnityEngine;
using System.Collections;

public class FlashEffect : MonoBehaviour
{
    [SerializeField]
    public float fadeDuration = 0.025f; // how long to fade out

    private SpriteRenderer sr;
    private Color originalColor;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;
    }

    void OnEnable()
    {
        StartCoroutine(FadeAndDestroy());
    }

    IEnumerator FadeAndDestroy()
    {
        float elapsed = 0f;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsed / fadeDuration);

            sr.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);

            yield return null;
        }

        Destroy(gameObject); // remove flash after fade
    }
}
