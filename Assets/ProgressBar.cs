using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{

    GameObject player;
    [SerializeField] Slider slider;
    [SerializeField] TMPro.TextMeshProUGUI progress;
    [SerializeField] float end = 200f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        progress.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateProgressSlider(player.transform.position.x, end);
    }

    void UpdateProgressSlider(float currentDistance, float maxDistance)
    {
        slider.maxValue = maxDistance;
        slider.value = currentDistance;

        if (currentDistance > end)
        {
            progress.enabled = true;
        }
    }
}
