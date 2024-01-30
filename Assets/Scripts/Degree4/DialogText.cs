using System.Collections;
using TMPro;
using UnityEngine;

public class DialogText : MonoBehaviour
{
    public TMP_Text dialogText;
    public string[] content;
    public float speed;
    private int m_sentenceIndex;
    private Coroutine m_showCo;

    private void Start()
    {
        m_showCo = StartCoroutine(ShowCo());
    }
    private IEnumerator ShowCo()
    {
        dialogText.text = "";
        foreach (char letter in content[m_sentenceIndex].ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(speed);
        }

    }
    public void NextDialog()
    {
        if (m_sentenceIndex < content.Length - 1)
        {
            m_sentenceIndex++;
            dialogText.text = "";
            if (m_showCo != null)
            {
                StopCoroutine(m_showCo);
            }
            m_showCo = StartCoroutine(ShowCo());
        }
    }
}