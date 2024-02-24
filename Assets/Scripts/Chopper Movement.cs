
using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChopperMovement : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI savedText;
    [SerializeField] private TextMeshProUGUI holdingText;
    [SerializeField] private GameObject soldierParentGO;
    [SerializeField] private GameObject gameOverGO;
    [SerializeField] private TextMeshProUGUI gameOverText;
    [SerializeField] private GameObject GMGO;

    [SerializeField] private float speed = 0.01f;
    [SerializeField] private float x = 0;
    [SerializeField] private float y = 0;

    [SerializeField] public int holding = 0;

    [SerializeField] public int saved = 0;

    [SerializeField] public Boolean playing = true;

    private void Update()
    {
        if (playing)
        {
            x = Input.GetAxis("Horizontal");
            y = Input.GetAxis("Vertical");

            Vector3 move = new Vector3(x, y, 0);
            move = Vector3.ClampMagnitude(move, 1f);

            gameObject.transform.position += (move * speed);
            if (gameObject.transform.position.x > 6) gameObject.transform.position = new Vector3(6, gameObject.transform.position.y, gameObject.transform.position.z);
            if (gameObject.transform.position.x < -6) gameObject.transform.position = new Vector3(-6, gameObject.transform.position.y, gameObject.transform.position.z);
            if (gameObject.transform.position.y > 3.5) gameObject.transform.position = new Vector3(gameObject.transform.position.x, 3.5f, gameObject.transform.position.z);
            if (gameObject.transform.position.y < -3.5) gameObject.transform.position = new Vector3(gameObject.transform.position.x, -3.5f, gameObject.transform.position.z);
        }
        if (saved >= 9)
        {
            playing = false;
            GameOver("Mission Complete");
            GMGO.GetComponent<GameManager>().record();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Tree"))
        {
            playing = false;
            GameOver("Mission Failed");
        }
        if (other.gameObject.CompareTag("Soldier"))
        {
            if (holding < 3)
            {
                other.gameObject.SetActive(false);
                holding++;
                holdingText.SetText(""+holding);
            }
        }
        if (other.gameObject.CompareTag("Tent"))
        {
            saved += holding;
            savedText.SetText("" + saved);
            holding = 0;
            holdingText.SetText("" + holding);
        }
    }

    private void GameOver(string Text)
    {
        while (gameOverGO.transform.localScale.y < 2)
            gameOverGO.transform.localScale = new Vector3(gameOverGO.transform.localScale.x, gameOverGO.transform.localScale.y + Time.deltaTime*0.001f, gameOverGO.transform.localScale.z);
        gameOverText.SetText(Text);
    }

}
