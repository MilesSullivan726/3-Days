using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.U2D;
using UnityEngine.UI;

public class TitleScreen : MonoBehaviour
{
    public float fadeOutTime = 3;
    public GameObject exposition;
    public GameObject music;
    private Image image;
    private bool expositionStarted = false;
    private bool canStartGame = false;

    // Start is called before the first frame update
    void Start()
    {
        
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !expositionStarted)
        {
            StartCoroutine(ShowExposition(image));
        }

        else if(Input.GetKeyDown(KeyCode.Space) && canStartGame)
        {
            StartCoroutine(StartGame(image));
        }
    }

    IEnumerator StartGame(Image sprite)
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

        SceneManager.LoadSceneAsync("Day 1", LoadSceneMode.Single);
    }

    IEnumerator ShowExposition(Image sprite)
    {
        expositionStarted = true;

        Color tempColor = sprite.color;

        while (tempColor.a < 1)
        {
            tempColor.a += Time.deltaTime / fadeOutTime;
            sprite.color = tempColor;
            yield return null;
        }
        sprite.color = tempColor;

        exposition.SetActive(true);

        while (tempColor.a > 0)
        {
            tempColor.a -= Time.deltaTime / fadeOutTime;
            sprite.color = tempColor;
            yield return null;
        }
        sprite.color = tempColor;

        yield return new WaitForSeconds(3);

        canStartGame = true;

    }
}
