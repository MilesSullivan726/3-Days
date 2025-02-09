using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeOut : MonoBehaviour
{
    public float fadeOutTime = 3;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(FadeOutScene(spriteRenderer));
    }

    // set alpha of white screen slowly higher to mimic a fade to white
    IEnumerator FadeOutScene(SpriteRenderer sprite)
    {
        Color tempColor = sprite.color;

        while (tempColor.a < 1)
        {
            tempColor.a += Time.deltaTime / fadeOutTime;
            sprite.color = tempColor;
            yield return null;
        }
        sprite.color = tempColor;
        SceneManager.LoadSceneAsync("Day 2", LoadSceneMode.Single);
    }
}
