using UnityEngine;
using UnityEngine.SceneManagement; // This is necessary to use SceneManager

public class DoubleClickHandler : MonoBehaviour
{
    public string sceneToLoad; // The name of the scene to load

    private float timeBetweenClicks = 0.3f; // Time allowed between clicks for it to be considered a double-click
    private float lastClickTime = 0f;
    private int clickCount = 0;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 0 is the left mouse button
        {
            float timeSinceLastClick = Time.time - lastClickTime;

            if (timeSinceLastClick <= timeBetweenClicks)
            {
                clickCount++;
            }
            else
            {
                clickCount = 1;
            }

            lastClickTime = Time.time;

            if (clickCount == 2)
            {
                LoadScene();
            }
        }
    }

    void LoadScene()
    {
        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            Debug.LogError("Scene name not set!");
        }
    }
}
