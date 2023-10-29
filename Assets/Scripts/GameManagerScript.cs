using JetBrains.Annotations;
using MalbersAnimations.Scriptables;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript Instance;
    [SerializeField] Transform train;

    [Header("UI")]
    [SerializeField] GameObject menu;


    [Header("Speed")]
    [SerializeField] float topSpeed;
    [SerializeField] float speed;

    [Header("Score")]
    [SerializeField] float score;
    [SerializeField] int displayScore;
    [SerializeField] TMP_Text scoreText;

    [Header("Game logic")]
    [SerializeField] List<GameObject> planesPrefabs;
    [SerializeField] List<GameObject> planesObjects;
        
    Vector3 newPlanePos;
    GameObject g;

    public bool playing;
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        score = 0;
        displayScore = 0;
        playing = false;
        newPlanePos = new Vector3(0, 0, 350);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Cursor.lockState = CursorLockMode.None;
        if (playing)
        {
            speed += ((speed < topSpeed) ? 0.001f : 0);
            train.transform.position += new Vector3(0, 0, Time.deltaTime * speed);
            score += 0.1f;
            displayScore = (int)score;
            scoreText.text = displayScore.ToString();

        }
    }

        
    public void playButton()
    {
        scoreText.gameObject.SetActive(true);
        menu.SetActive(false);
    }   
    
    public void pauseButton()
    {
        scoreText.gameObject.SetActive(false);
        menu.SetActive(true);
        playing =false; 
    }

    public void exitButton()
    {
        Application.Quit();
    }

    public void newPlane()
    {
        int ran = Random.Range(0, planesPrefabs.Count);
        planesObjects.Add(Instantiate(planesPrefabs[ran], newPlanePos, Quaternion.identity));
        g = planesObjects[0];
        planesObjects.RemoveAt(0);
        Destroy(g);
        newPlanePos += new Vector3(0, 0, 100);  


    }
}
