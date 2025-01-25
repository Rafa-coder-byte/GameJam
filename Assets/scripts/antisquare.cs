using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Antisquare : MonoBehaviour
{
    public GameObject cuadrado;
    public float fadeDuration = 0.5f; // Duración del fade

    private SpriteRenderer cuadradoRenderer;
    private bool isFading = false;

    void Start()
    {
        cuadradoRenderer = cuadrado.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isFading)
        {
            StartCoroutine(FadeOut());
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && !isFading)
        {
            Debug.Log("Activando cuadrado");
            StartCoroutine(FadeIn());
        }
    }

    IEnumerator FadeOut()
    {
        isFading = true;
        float startAlpha = cuadradoRenderer.color.a;
        float rate = 1.0f / fadeDuration;
        float progress = 0.0f;

        while (progress < 1.0f)
        {
            Color tmpColor = cuadradoRenderer.color;
            cuadradoRenderer.color = new Color(tmpColor.r, tmpColor.g, tmpColor.b, Mathf.Lerp(startAlpha, 0, progress));
            progress += rate * Time.deltaTime;

            yield return null;
        }

        cuadrado.SetActive(false);
        isFading = false;
    }

    IEnumerator FadeIn()
    {
        cuadrado.SetActive(true);
        isFading = true;
        float startAlpha = cuadradoRenderer.color.a;
        float rate = 1.0f / fadeDuration;
        float progress = 0.0f;

        while (progress < 1.0f)
        {
            Color tmpColor = cuadradoRenderer.color;
            cuadradoRenderer.color = new Color(tmpColor.r, tmpColor.g, tmpColor.b, Mathf.Lerp(startAlpha, 1, progress));
            progress += rate * Time.deltaTime;

            yield return null;
        }

        isFading = false;
    }
}
