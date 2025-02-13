using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class FadeIn : MonoBehaviour
{
    public float fadeOutTime = 3;
    public bool isText = false;
    private SpriteRenderer spriteRenderer;
    private TextMeshProUGUI textMeshProUGUI;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
        if (!isText)
        {
            StartCoroutine(FadeOutScene(spriteRenderer));
        }
        else
        {
            StartCoroutine(FadeOutText(textMeshProUGUI));
        }
    }

    // set alpha of white screen slowly higher to mimic a fade to white
    IEnumerator FadeOutScene(SpriteRenderer sprite)
    {
        yield return new WaitForSeconds(2);

        Color tempColor = sprite.color;

        while (tempColor.a > 0)
        {
            tempColor.a -= Time.deltaTime / fadeOutTime;
            sprite.color = tempColor;
            yield return null;
        }
        sprite.color = tempColor;
        
    }

    IEnumerator FadeOutText(TextMeshProUGUI text) {

        yield return new WaitForSeconds(2);

        Color tempColor = text.color;

        while (tempColor.a > 0)
        {
            tempColor.a -= Time.deltaTime / fadeOutTime;
            text.color = tempColor;
            yield return null;
        }
        text.color = tempColor;

    }
}
