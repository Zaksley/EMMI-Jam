using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject save;
    private void Awake() {
        DontDestroyOnLoad(save);
        DontDestroyOnLoad(this.gameObject);
    }
    // Update is called once per frame
}
