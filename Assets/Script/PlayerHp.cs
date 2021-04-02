﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SoftGear.Strix.Unity.Runtime;

public class PlayerHp : StrixBehaviour
{
  [SerializeField]
  private int maxHp = 100;
  [SerializeField]
  private int Hp = 0;
  [SerializeField]
  private Text CurrentHp;
  public Image HpGauge;
  private int[] HpDamage = { 100, 40, 20 };
  public GameObject[] Part = new GameObject[3];
  public GameObject HPUI;
  public GameObject HpCanvas;


  public int HP
  {
    set
    {
      Hp = Mathf.Clamp(value, 0, maxHp);

      float scaleX = (float)Hp / maxHp;
      HpGauge.rectTransform.localScale = new Vector3(scaleX, 1, 1);
    }
    get
    {
      return Hp;
    }
  }

  void Start()
  {
    HP = maxHp;
    if (!isLocal)
    {
      HPUI.gameObject.SetActive(true);
      HpCanvas.SetActive(false);
    }
  }

  void Update()
  {
    Debug.Log(HP);
    if (CurrentHp.text != HP.ToString())
    {
      NowHp();
    }
  }

  void NowHp()
  {
    CurrentHp.text = Hp.ToString();
  }

  public void Damage()
  {
    if (HitArrow.partName == Part[0])
    {
      HP -= HpDamage[0];
    }
    if (HitArrow.partName == Part[1])
    {
      HP -= HpDamage[1];
    }
    if (HitArrow.partName == Part[2])
    {
      HP -= HpDamage[2];
    }

  }


}
