using System.Collections;
using UnityEngine;

public class DiamondFactory : MonoBehaviour
{
    [SerializeField] private Transform[] platforms;
    [SerializeField] private GameObject _nonPickableDiamond;
    [SerializeField] private GameObject _pickableDiamond;

    private void Start()
    {
        if (platforms != null)
        {
            StartCoroutine(Create(platforms));
        }
    }

    public IEnumerator Create(Transform[] platforms)
    {
        yield return new WaitForSeconds(2f);
        int randomPlatform = Random.Range(0, platforms.Length);
        GameObject _nonPickDiamond = Instantiate(_nonPickableDiamond, platforms[randomPlatform].position, Quaternion.identity, null);
        _nonPickDiamond.transform.position = Vector3.Lerp(_nonPickDiamond.transform.position, _nonPickDiamond.transform.position + new Vector3(0f, 2f, 0), 2f);
        yield return new WaitForSeconds(2f);
        Destroy(_nonPickDiamond);
        GameObject _pickDiamond = Instantiate(_pickableDiamond, platforms[randomPlatform].position, Quaternion.identity, null);
        _pickDiamond.transform.position = Vector3.Lerp(_pickDiamond.transform.position, _pickDiamond.transform.position + new Vector3(0f, 2f, 0), 2f);
        StartCoroutine(Create(platforms));
    }
}
