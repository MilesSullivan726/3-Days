using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeOut : MonoBehaviour
{
    public float fadeOutTime = 3;
    private SpriteRenderer spriteRenderer;
    public GameObject music;
    
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(FadeOutScene(spriteRenderer));
        music.GetComponent<Music>().fadeOut = true;
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
        if (SceneManager.GetActiveScene().name == "Day 1")
        {
            SceneManager.LoadSceneAsync("Day 2", LoadSceneMode.Single);
        }
        else if (SceneManager.GetActiveScene().name == "Day 2")
        {
            SceneManager.LoadSceneAsync("Day 3", LoadSceneMode.Single);
        }
        else if (SceneManager.GetActiveScene().name == "Day 3")
        {
            SceneManager.LoadSceneAsync("End Screen", LoadSceneMode.Single);
        }
    }
}
