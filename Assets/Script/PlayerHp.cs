using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHp : MonoBehaviour
{
  [SerializeField]
  public int maxHp = 100;
  [SerializeField]
  public int Hp = 0;
  [SerializeField]
  public Text CurrentHp;
  public Image HpGauge;
  private int[] HpDamage = { 100, 40, 20 };
  public GameObject[] Part = new GameObject[3];

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
  }

  // Update is called once per frame
  void Update()
  {
    if (CurrentHp.text != Hp.ToString())
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
