
using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class HeroController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float Speed;
    public TextMeshProUGUI scoreText;
    private float Score;
    public Transform cam;
    public GameObject panel;
    private Vector3 originalScale;
    void Start()
    {
        Time.timeScale = 1;
        rb = GetComponent<Rigidbody2D>();
        originalScale = transform.localScale;
    }

    void Update(){
        if(rb.velocity.y > 0 && transform.position.y > Score){
            Score = transform.position.y;
        }   
        scoreText.text = Math.Round(Score).ToString();
        if(cam.position.y > transform.position.y + 7f){
            Time.timeScale = 0;
            panel.SetActive(true);
        }
    }
    
    void FixedUpdate()
    {
    float moveX = Input.GetAxis("Horizontal"); // Klavye için yatay hareket

    // Klavye veya dokunma kontrolü
    if (Input.touchCount > 0) // Dokunmatik giriş varsa
    {
        Touch touch = Input.GetTouch(0); // İlk dokunuşu al

        if (touch.position.x < Screen.width / 2)
        {
            // Ekranın soluna dokundu
            moveX = -1;
        }
        else if (touch.position.x > Screen.width / 2)
        {
            // Ekranın sağına dokundu
            moveX = 1;
        }
        }

        // Hareketi uygula
        rb.velocity = new Vector2(moveX * Speed, rb.velocity.y);

        // Yön değiştirme
        if (moveX > 0)
        {
            // Sağa bak
            transform.localScale = new Vector3(Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);
        }
        else if (moveX < 0)
        {
            // Sola bak
            transform.localScale = new Vector3(-Mathf.Abs(originalScale.x), originalScale.y, originalScale.z);
        }
    }
    public void playAgain(){
        SceneManager.LoadScene(0);
    }
}
