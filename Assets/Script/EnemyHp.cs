using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SoftGear.Strix.Unity.Runtime;

public class EnemyHp : StrixBehaviour
{
  [SerializeField]
  private float maxHp = 100;

  [SerializeField]
  private GameObject HPUI;
  private Slider hpSlider;
  PlayerHp playerHp;

  void Start()
  {
    playerHp = transform.root.gameObject.GetComponent<PlayerHp>();
    hpSlider = HPUI.GetComponent<Slider>();
    hpSlider.value = 1f;
  }

  void Update()
  {
    UpdateHPValue();
  }

  [StrixRpc]
  public void UpdateHPValue()
  {
    if (isLocal)
    {
      return;
    }
    hpSlider.value = playerHp.HP / maxHp;
  }
}
