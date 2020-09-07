using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public float respawnDelay;
    private PlayerController gamePlayer;
    public CameraController camera;
    public int coins;
    public Text scoreText;
    
    // Start is called before the first frame update
    void Start()
    {
        gamePlayer = FindObjectOfType<PlayerController>();
        camera = FindObjectOfType<CameraController>();
        scoreText.text = "Coins: " + coins;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Respawn()
    {
        StartCoroutine("RespawnCoroutine");
    }

    public IEnumerator RespawnCoroutine()
    {
        gamePlayer.gameObject.SetActive(false);
        yield return new WaitForSeconds(respawnDelay);
        gamePlayer.transform.position = gamePlayer.respawnPoint;
        gamePlayer.gameObject.SetActive(true);
        camera.transform.position = new Vector3(gamePlayer.respawnPoint.x, camera.transform.position.y, camera.transform.position.z);
    }

    public void AddCoins(int noOfCoins)
    {
        coins = coins+ noOfCoins;
        scoreText.text = "Coins: " + coins;
    }
}
