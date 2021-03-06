using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyCheck : MonoBehaviour
{
    [SerializeField] private int KeyAmount;

    [SerializeField] private Sprite keySprite;

    [SerializeField] private Sprite emptySlot;

    // Update is called once per frame
    void Update()
    {
        if (PlayerInfos.Instance.Keys > KeyAmount - 1) 
            gameObject.GetComponent<Image>().sprite = keySprite;
         else
            gameObject.GetComponent<Image>().sprite = emptySlot;
    }
}
