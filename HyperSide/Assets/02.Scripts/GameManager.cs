using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public delegate void GameEndEventHandler(bool isVictory);
    public static GameEndEventHandler GameOver;

    [HideInInspector]
    public bool isPlaying = true;

    public Nexus allyNexus;
    public Nexus enemyNexus;

    public TextMeshProUGUI ally_hp;
    public TextMeshProUGUI enemy_hp;

    private static GameObject endPanel;

    private static GameObject victoryImg;
    private static GameObject loseImg;

    void Start()
    {
        endPanel = GameObject.Find("EndPanel");

        victoryImg = GameObject.Find("v");
        loseImg = GameObject.Find("l");

        endPanel.SetActive(false);
        victoryImg.SetActive(false);
        loseImg.SetActive(false);

        Nexus.GameEnd += GameEnd;
    }

    void Update()
    {
        ally_hp.text = $"{(allyNexus.hp > 0 ? allyNexus.hp : 0)}";
        enemy_hp.text = $"{(enemyNexus.hp > 0 ? enemyNexus.hp : 0)}";
    }

    void GameEnd(bool isVictory)
    {
        isPlaying = false;
        /*
         * 여기다 게임 끝났을 때 동작할 코드 작성하세요
         * victory lose 어쩌구 그거
         * DG.Tweening 임포트 해놨으니 예쁘게 쓰세요 ^^
         */

        if (isVictory)
        {

            victoryImg.SetActive(true);
        }
        else
        {
            loseImg.SetActive(true);
        }
        endPanel.SetActive(true);
        GameOver(isVictory);
    }
}
