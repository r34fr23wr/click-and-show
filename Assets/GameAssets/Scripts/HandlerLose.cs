using UnityEngine;
using UnityEngine.SceneManagement;

public class HandlerLose : MonoBehaviour
{
    [SerializeField] private GameObject[] _objectsToHide;
    [SerializeField] private GameObject[] _loseTexts;
    [SerializeField] private Castle _castle;

    private void OnEnable()
    {
        _castle.GetComponent<ICastle>().Kill += Lose;
    }

    private void OnDisable()
    {
        _castle.GetComponent<ICastle>().Kill -= Lose;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void Lose()
    {
        for(int i=0; i<_objectsToHide.Length; i++)
        {
            _objectsToHide[i].SetActive(false);
        }
        for(int i=0; i<_loseTexts.Length; i++)
        {
            _loseTexts[i].SetActive(true);
        }
    }
}
