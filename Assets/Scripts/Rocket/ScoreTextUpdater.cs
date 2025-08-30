using TMPro;
using UnityEngine;

public class ScoreTextUpdater : MonoBehaviour
{
    [SerializeField] private TMP_Text textMeshPro;
    private void Update()
    {
        RedrawText();
    }

    private void RedrawText()
    {
        if (textMeshPro != null)
        {
            textMeshPro.text = ScoreCollect.Score.ToString();
        }
    }
}