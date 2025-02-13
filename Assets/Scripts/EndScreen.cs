using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour
{
    private Image image;
    public float fadeOutTime = 3;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        StartCoroutine(FadeIn(image));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator FadeIn(Image sprite)
    {
        Color tempColor = sprite.color;

        while (tempColor.a > 0)
        {
            tempColor.a -= Time.deltaTime / fadeOutTime;
            sprite.color = tempColor;
            yield return null;
        }
        sprite.color = tempColor;

        
    }
}
