using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiCore : MonoBehaviour
{
    [SerializeField] Text healthText;
    [SerializeField] Text coinText;

    CharacterCore.CharacterData characterData;

    private void Start()
    {
    }

    private void FixedUpdate()
    {
        if (characterData == null)
        {
            characterData = CharacterCore.Instance.characterData;
        }
        healthText.text = "HEALTH :" + characterData.health.ToString();
        coinText.text = "COIN :" + characterData.coin.ToString();
    }
}
