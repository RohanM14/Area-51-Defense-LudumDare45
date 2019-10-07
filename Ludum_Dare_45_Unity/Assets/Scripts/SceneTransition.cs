using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    private Transform flash;
    private SpriteRenderer fadeOutUIImage;
    private float fadeSpeed = 1.5f;
    private Quaternion endRotation = Quaternion.Euler(0, 0, 0);
    public enum FadeDirection
    {
        In, //Alpha = 1
        Out // Alpha = 0
    }

    // Start is called before the first frame update
    void Start()
    {
        flash = transform.Find("Flash");
        fadeOutUIImage = transform.Find("FadeSprite").gameObject.GetComponent<SpriteRenderer>();
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeScene(string sceneName)
    {
        StartCoroutine(RotateIn());
        SceneManager.sceneLoaded += OnSceneLoaded;
        StartCoroutine(waitTillRotate(sceneName));
    }

    private IEnumerator waitTillRotate(string sceneName)
    {
        yield return new WaitWhile(() => transform.rotation.eulerAngles.z != 0);
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(FadeAndLoadScene(FadeDirection.Out,sceneName));
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name.Equals("SampleScene"))
        {
            Debug.Log("Scene is recognized");
            GameObject spawnZone = GameObject.Find("EnemySpawnZone");
            spawnZone.GetComponent<EnemySpawnManager>().setupWave(UpgradeManager.currentWave);
        }
        SceneManager.sceneLoaded -= OnSceneLoaded;
        StartCoroutine(Fade(FadeDirection.In));
        flash.localScale = new Vector3(0, 0, 0);
        transform.rotation = Quaternion.Euler(0, 0, 90);
        Destroy(gameObject, 25f);
    }

    private IEnumerator RotateIn()
    {
        while (transform.rotation.z != 0)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, endRotation, 0.1f);
            if (transform.rotation.eulerAngles.z < 3) transform.rotation = endRotation;
            yield return null;
        }
    }

    #region FADE
    private IEnumerator Fade(FadeDirection fadeDirection)
    {
        float alpha = (fadeDirection == FadeDirection.Out) ? 0 : 1;
        float scale = 0;
        float scaleEndValue = 50;
        float fadeEndValue = (fadeDirection == FadeDirection.Out) ? 1 : 0;
        if (fadeDirection == FadeDirection.Out)
        {
            //transparent >> flash >> white screen
            while (scale < scaleEndValue)
            {
                scale = Mathf.Lerp(scale, scaleEndValue, 0.01f);
                if (scale >= 0.8 * scaleEndValue) scale = scaleEndValue;
                flash.localScale = new Vector3(scale,scale,scale);
                yield return null;
            }

            fadeOutUIImage.enabled = false;
        }
        else
        {
            fadeOutUIImage.enabled = true;
            while (alpha >= fadeEndValue)
            {
                SetColorImage(ref alpha, fadeDirection);
                yield return null;
            }
        }
    }
    #endregion
    #region HELPERS
    public IEnumerator FadeAndLoadScene(FadeDirection fadeDirection, string sceneToLoad)
    {
        Cursor.visible = true;
        yield return Fade(fadeDirection);
        SceneManager.LoadScene(sceneToLoad);
    }
    private void SetColorImage(ref float alpha, FadeDirection fadeDirection)
    {
        fadeOutUIImage.color = new Color(fadeOutUIImage.color.r, fadeOutUIImage.color.g, fadeOutUIImage.color.b, alpha);
        alpha += Time.deltaTime * (1.0f / fadeSpeed) * ((fadeDirection == FadeDirection.Out) ? 1 : -1);
    }
    #endregion

    public void quitGame()
    {
        Application.Quit();
    }


}
