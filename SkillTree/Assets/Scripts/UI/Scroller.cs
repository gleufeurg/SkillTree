using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Scroller : MonoBehaviour
{
    [SerializeField] RawImage image;
    [SerializeField] [Range(0.001f, 1f)] float _x, _y = 0.01f;

    private void Update()
    {
        //unscaledDeltaTime to animate even when timeScale is set to 0
        image.uvRect = new Rect(image.uvRect.position + new Vector2(_x, _y) * Time.unscaledDeltaTime, image.uvRect.size);
    }
}
