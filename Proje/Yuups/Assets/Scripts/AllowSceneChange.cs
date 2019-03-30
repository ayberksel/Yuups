using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllowSceneChange : MonoBehaviour {

    public void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
