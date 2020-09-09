﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SetPlayerColor : MonoBehaviour
{
    private List<Material> skins;
    private List<Material> skinsInUse;

    [Header("Player Colors")]
    public Material skinPlayer1;
    public Material skinPlayer2;
    public Material skinPlayer3;
    public Material skinPlayer4;

    private void Awake()
    {
        skins = new List<Material>();
        skins.Add(skinPlayer1);
        skins.Add(skinPlayer2);
        skins.Add(skinPlayer3);
        skins.Add(skinPlayer4);

        skinsInUse = new List<Material>();
    }

    int GetUnusedSkin()
    {
        if (skinsInUse.Count == 0)
        {
            skinsInUse.Add(skins[0]);
            return 0;
        }
        else
        {
            for (int i = 0; i < skins.Count; i++)
            {
                for (int ii = 0; ii < skinsInUse.Count; ii++)
                {
                    if (skins[i] != skinsInUse[ii])
                    {
                        skinsInUse.Add(skins[i]);
                        return i;
                    }
                }
            }
        }        
        return 0;
    }

    void RemoveColorFromUsedList(Material skin)
    {
        if (skinsInUse.Contains(skin))
        {
            skinsInUse.Remove(skin);
        }
    }

    public void OnPlayerJoined(PlayerInput playerInput)
    {
        Debug.Log("Player Joined");
        playerInput.gameObject.GetComponent<Renderer>().material = skins[GetUnusedSkin()];
    }

    public void OnPlayerLeft(PlayerInput playerInput)
    {
        Debug.Log("Player Left"); 
        RemoveColorFromUsedList(playerInput.gameObject.GetComponent<Renderer>().material);
    }
}