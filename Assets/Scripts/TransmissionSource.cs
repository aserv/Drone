using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class TransmissionSource : MonoBehaviour {
    public Sprite m_ActiveSprite;
    public Sprite m_InactiveSprite;

    public void Activate(bool val) {
        GetComponent<SpriteRenderer>().sprite = val ? m_ActiveSprite : m_InactiveSprite;
    }
}
