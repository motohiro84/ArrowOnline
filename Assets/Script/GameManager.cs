using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  public GameObject spawn;
  public GameObject Player;
  public GameObject Armature;
  public GameObject Hito;
  public GameObject GameOverText;
  public GameObject sarcophagi;
  private bool spawnKey = true;
  private Vector3 spawnPos;
  bool gameOverKey = false;



  void Start()
  {
    SpawnPlayer();
  }


  void Update()
  {
    if (gameOverKey && Input.GetKeyDown(KeyCode.Space))
    {
      Player.GetComponent<PlayerHp>().HP = 100;
      SpawnPlayer();
      PlayerMove.stratMoveKey = true;
      Armature.SetActive(true);
      Hito.SetActive(true);
      GameOverText.SetActive(false);
    }
  }

  void SpawnPlayer()
  {
    SetPosition();
    Player.transform.position = spawnPos;
    Player.transform.LookAt(sarcophagi.transform);
  }

  void SetPosition()
  {
    float x = 0;
    float z = 0;

    while (spawnKey)
    {
      x = Random.Range(-22f, 22f);
      z = Random.Range(-38f, 38f);
      if ((x < -2f || x > 2f) || (z < -1f || z > 1f))
      {
        spawnKey = false;
      }
    }

    spawnPos = new Vector3(x, spawn.transform.position.y, z);
  }

  public void GameOver()
  {
    PlayerMove.stratMoveKey = false;
    Armature.SetActive(false);
    Hito.SetActive(false);
    GameOverText.SetActive(true);
    spawnKey = true;
    gameOverKey = true;
  }


}
