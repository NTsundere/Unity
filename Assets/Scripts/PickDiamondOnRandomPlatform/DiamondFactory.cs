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
        Vector3 endPoint = _nonPickDiamond.transform.position + new Vector3 (0, 2, 0);
        float progress = 0f;
        while (progress < 1f)
        {
            progress += Time.deltaTime;
            _nonPickDiamond.transform.position = Vector3.Lerp(_nonPickDiamond.transform.position, endPoint, progress);
            yield return null;
        }
        progress = 0f;
        Destroy(_nonPickDiamond);
        GameObject _pickDiamond = Instantiate(_pickableDiamond, endPoint, Quaternion.identity, null);
        StartCoroutine(Create(platforms));
    }
}
