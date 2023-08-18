using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISpriteAnimation : MonoBehaviour
{

    public Image m_Image;

    public Sprite[] m_SpriteArray;
    public float m_Speed = .04f;

    private int m_IndexSprite;
    Coroutine m_CorotineAnim;
    bool loop;

    private void Start()
    {
        m_Image.enabled = false;
    }

    public void Func_PlayUIAnim(bool _loop)
    {
        loop = _loop;
        m_Image.enabled = true;
        StartCoroutine(Func_PlayAnimUI());
    }

    public void Func_StopUIAnim()
    {
        loop = true;
        StopCoroutine(Func_PlayAnimUI());
    }
    IEnumerator Func_PlayAnimUI()
    {
        yield return new WaitForSeconds(m_Speed);
        if (m_IndexSprite >= m_SpriteArray.Length)
        {
            m_IndexSprite = 0;
        }
        m_Image.sprite = m_SpriteArray[m_IndexSprite];
        m_IndexSprite += 1;
        if (m_IndexSprite < m_SpriteArray.Length || loop == true)
            m_CorotineAnim = StartCoroutine(Func_PlayAnimUI());
        else
            m_Image.enabled = false;
    }
}
