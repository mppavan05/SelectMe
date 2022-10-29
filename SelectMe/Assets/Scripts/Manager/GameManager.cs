using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Text messageText;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShowMessage());
    }

    private IEnumerator ShowMessage()
    {
        messageText.text = string.Format("Welcome, {0} \n In Your game scene", References.userName);

        yield return new WaitForSeconds(3f);

        messageText.text = null;
    }
    
    public void LogOut()
    {
        //FirebaseManager.Instance.SaveDataButton();
        FirebaseManager.Instance.SignOutButton();
    }
}
