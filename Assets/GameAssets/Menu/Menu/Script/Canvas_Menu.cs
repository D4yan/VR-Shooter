using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Canvas_Menu : MonoBehaviour
{
    public Text text;
    public Image img;
    public Button btn;
    public GameObject canvas;
    public Camera camera;

    private Color original;
    public static int kills;

    private void Start()
    {
        kills = 0;

        btn.onClick.AddListener(ShowHighscore);

        btn.gameObject.SetActive(false);

        StartCoroutine(DelayedText());
    }

    // Update is called once per frame
    private void Update()
    {
        Vector3 direction = camera.transform.forward;
        Vector3 origin = camera.transform.position;
        origin.y = 1.5f;
        direction.y = 0;
        
        Ray ray = new Ray(origin, direction);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 5f))
        {
            this.gameObject.transform.position = hit.point - (ray.direction * 0.1f);
            this.gameObject.transform.forward = -hit.normal;
            }
        else
        {
            this.gameObject.transform.position = origin + (ray.direction * 5f);
            this.gameObject.transform.localRotation = Quaternion.identity;
        
        }
    }

    IEnumerator DelayedText()
    {
        yield return new WaitForSeconds(4);

        ChangeText("Ziehe deine Waffe wenn du bereit bist los zu starten.");

        yield return new WaitForSeconds(10);

        // Hier fehlt ein Event bei dem der Spieler seine Waffe zieht
        DeactivateCanvas();
    }

    public void DeactivateCanvas()
    {
        Debug.Log("Deactivate");
        canvas.SetActive(false);
    }

    public void ActivateCanvas()
    {
        Debug.Log("Activate");
        canvas.SetActive(true);
    }

    public void ChangeText(string t)
    {
        Debug.Log("Change Text");
        text.text = t;
    }

    public void GameOver(int score)
    {
        kills = score;
        ActivateCanvas();
        Debug.Log("Game Over");
        original = text.color;
        text.color = Color.red;
        ChangeText("Game Over \n Score: " + kills + "\n Schiesse einige male um neuzustarten!");
        ActivateHighscoreButton();

    }

    public void ActivateHighscoreButton()
    {
        btn.gameObject.SetActive(true);
    }

    public void ShowHighscore()
    {
        text.color = original;

        ChangeText("Highscore \n " + kills);

        // Mit einem Speicher von vorangegangenen Aktionen kann man hier noch viel machen.
    }

}
