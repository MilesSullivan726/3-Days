using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingCheck : MonoBehaviour
{

    public float fadeOutTime = 3;
    public GameObject goodEndingScene;
    public GameObject music;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (GameManager.choiceOneDecision == 1 && GameManager.choiceTwoDecision == 1)
        {
            StartCoroutine(GoodEndingScene(spriteRenderer));
        }

        else
        {
            StartCoroutine(FadeOutScene(spriteRenderer));
        }
    }

    // set alpha of white screen slowly higher to mimic a fade to white
    IEnumerator FadeOutScene(SpriteRenderer sprite)
    {
        music.GetComponent<Music>().fadeOut = true;
        Color tempColor = sprite.color;

        while (tempColor.a < 1)
        {
            tempColor.a += Time.deltaTime / fadeOutTime;
            sprite.color = tempColor;
            yield return null;
        }
        sprite.color = tempColor;
        
        SceneManager.LoadSceneAsync("Day 3", LoadSceneMode.Single);
        
    }

    IEnumerator GoodEndingScene(SpriteRenderer sprite)
    {
        Color tempColor = sprite.color;

        while (tempColor.a < 1)
        {
            tempColor.a += Time.deltaTime / fadeOutTime;
            sprite.color = tempColor;
            yield return null;
        }
        sprite.color = tempColor;
        
        goodEndingScene.SetActive(true);
        

        while (tempColor.a > 0)
        {
            tempColor.a -= Time.deltaTime / fadeOutTime;
            sprite.color = tempColor;
            yield return null;
        }
        sprite.color = tempColor;

        yield return new WaitForSeconds(5);
        music.GetComponent<Music>().fadeOut = true;
        while (tempColor.a < 1)
        {
            tempColor.a += Time.deltaTime / fadeOutTime;
            sprite.color = tempColor;
            yield return null;
        }
        sprite.color = tempColor;

        SceneManager.LoadSceneAsync("Day 3", LoadSceneMode.Single);
        
    }
}
