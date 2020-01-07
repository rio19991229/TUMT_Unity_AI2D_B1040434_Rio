using UnityEngine;
using UnityEngine.UI;   
using System.Collections;
public class npc : MonoBehaviour
{
    public enum state
    {
        start, notcomplete, complete
    }
    public state _state;

    [Header("對話")]
    public string missionStart = "請擊倒後面兩位敵人";
    public string missionNotComplete = "你還沒有擊倒完畢";
    public string missionComplete = "恭喜你!!!已擊倒兩位敵人!!!";
    [Header("任務相關")]
    public bool complete;
    public float countPlayer;
    public int countFinish = 2;
    [Header("介面")]
    public GameObject objCanvas;
    public Text textSay;

    public float speed = 0.5f;
    public static npc count;

    public GameObject finsh;

    private void Start()
    {
        count = this;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "player")
            Say();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "player")
            SayClose();
    }

    private void Say()
    {
        objCanvas.SetActive(true);
        StopAllCoroutines();

        if (countPlayer >= countFinish)
        {
            _state = state.complete;

            Invoke("finish", 3f);
        } 

        switch (_state)
        {
            case state.start:
                StartCoroutine(ShowDialog(missionStart));           
                _state = state.notcomplete;
                break;
            case state.notcomplete:
                StartCoroutine(ShowDialog(missionNotComplete));     
                break;
            case state.complete:
                StartCoroutine(ShowDialog(missionComplete));        
                break;
        }
    }
    private IEnumerator ShowDialog(string say)
    {
        textSay.text = "";                              // 清空文字

        for (int i = 0; i < say.Length; i++)            // 迴圈跑對話.長度
        {
            textSay.text += say[i].ToString();          // 累加每個文字
            yield return new WaitForSeconds(speed);     // 等待
        }
    }

    private void SayClose()
    {
        StopAllCoroutines();
        objCanvas.SetActive(false);
    }

    public void PlayerGet()
    {
        countPlayer++;
    }

    void finish()
    {
        finsh.SetActive(true);

        Destroy(play.fin);
    }
}
