﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject airBallPrefab;
    public GameObject earthBallPrefab;
    public GameObject fireBallPrefab;
    public GameObject waterBallPrefab;

    public GameObject airShockwave;
    public GameObject waterIcicle;
    public GameObject lightning;

    // Awake is called before the first frame update
    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

}
