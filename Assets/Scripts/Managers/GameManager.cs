using System.Collections;
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
    public GameObject earthPlatform;
    public GameObject lightning;
    public GameObject waterIcicle;

    public GameObject playerPrefab;
    public GameObject guardPrefab;

    public int charCount = 0;
    public float deathAxis;

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

    private void Start()
    {
        //Vector3 pos = new Vector3(17.1f, -9.4f);
        //Quaternion rot = Quaternion.Euler(0, 0, 0);
        //SpawnPlayer(pos, rot, "Air");
    }

    public void SpawnPlayer(Vector3 pos, Quaternion rot, string elem)
    {
        GameObject player = Instantiate(playerPrefab, pos, rot);
        Element.AddElement(player, elem);
        player.AddComponent<Player>();
    }

    public void SpawnGuard(Vector3 pos, Quaternion rot, string elem)
    {
        GameObject guard = Instantiate(guardPrefab, pos, rot);
        Element.AddElement(guard, elem);
        guard.AddComponent<Guard>();
    }

    private void Update()
    {
        if(charCount == 1)
        {
            Vector3 pos = new Vector3(-22.43f, 13.05f);
            Quaternion rot = Quaternion.Euler(0, 0, 0);
            SpawnGuard(pos, rot, "Air");

            pos = new Vector3(-22.43f, 6.9f);
            SpawnGuard(pos, rot, "Earth");

            pos = new Vector3(-22.43f, 1.4f);
            SpawnGuard(pos, rot, "Fire");

            pos = new Vector3(-22.43f, -3.9f);
            SpawnGuard(pos, rot, "Water");
        }
    }

}
