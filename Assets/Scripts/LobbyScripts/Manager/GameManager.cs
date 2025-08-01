using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager instance;
    public static GameManager Instance {  get { return instance; } }
    public Vector2 playerLocation;
    public Animator originAnimator;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        originAnimator = GetComponent<Animator>();
    }

    public void SavePlayerPosition(Vector2 position)
    {
        playerLocation = position;
    }

    public Vector2 LoadPlayerPosition()
    {
        return playerLocation;
    }
}
