using TMPro;
using UnityEngine;

public class BirdScore : MonoBehaviour
{
    [SerializeField] private BirdMover _birdMover;
    
    private TMP_Text _text;


    private void Start()
    {
        _text = GetComponent<TMP_Text>();
    }
    private void Update()
    {
        _text.text = _birdMover.Score.ToString();
    }
}
