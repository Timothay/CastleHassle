using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KillCountManager : MonoBehaviour
{
    public int killCount;
    public TextMeshProUGUI killCountText;

    // Start is called before the first frame update
    void Start()
    {
        killCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        killCountText.text = "" + killCount.ToString("D3");
    }
}
