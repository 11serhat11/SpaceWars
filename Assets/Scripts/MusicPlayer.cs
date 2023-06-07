using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private void Awake() {
        int playerNum = FindObjectsOfType<MusicPlayer>().Length;
        if (playerNum > 1)
        Destroy(gameObject);

        else
        DontDestroyOnLoad(gameObject);
    }
}
