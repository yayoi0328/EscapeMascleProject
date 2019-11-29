using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class Message : MonoBehaviour
{

    //　メッセージUI
    private Text messageText;
    //　表示するメッセージ
    [SerializeField]
    [TextArea(1, 20)]
    private string allMessage = "・・・・・・<>"
            + "見えますか？<>"
            + "動いてますか？<>"
            + "・・・・・・<>"
            + "見えてるみたいですね。";
    //　使用する分割文字列
    [SerializeField]
    private string splitString = "<>";
    //　分割したメッセージ
    private string[] splitMessage;
    //　分割したメッセージの何番目か
    public int messageNum;
    //　テキストスピード
    [SerializeField]
    private float textSpeed = 0.05f;
    //　経過時間
    private float elapsedTime = 0f;
    //　今見ている文字番号
    private int nowTextNum = 0;
    //　マウスクリックを促すアイコン
    private Image clickIcon;
    //　クリックアイコンの点滅秒数
    [SerializeField]
    private float clickFlashTime = 0.2f;
    //　1回分のメッセージを表示したかどうか
    private bool isOneMessage = false;
    //　メッセージをすべて表示したかどうか
    private bool isEndMessage = false;

    void Start()
    {
        //クリックアイコンの変数に画像を割り付ける
        clickIcon = transform.Find("MessageWindow/Image").GetComponent<Image>();
        //クリックアイコンの表示状態を初期では非表示に設定する
        clickIcon.enabled = false;
        //メッセージテキストの変数にテキストコンポーネントを割り付けている
        messageText = GetComponentInChildren<Text>();
        //メッセージテキストの初期状態を何も出力されない状態に設定
        messageText.text = "";
        //allMessageを設定
        SetMessage(allMessage);
    }

    void Update()
    {
        //　メッセージが終わっているか、メッセージがない場合はこれ以降何もしない
        if (isEndMessage || allMessage == null)
        {
            return;
        }

        //　1回に表示するメッセージを表示していない	
        if (!isOneMessage)
        {
            //　テキスト表示時間を経過したらメッセージを追加
            if (elapsedTime >= textSpeed)
            {
                messageText.text += splitMessage[messageNum][nowTextNum];

                nowTextNum++;
                elapsedTime = 0f;

                //　メッセージを全部表示、または行数が最大数表示された
                if (nowTextNum >= splitMessage[messageNum].Length)
                {
                    isOneMessage = true;
                }
            }
            elapsedTime += Time.deltaTime;

            //　メッセージ表示中にマウスの左ボタンを押したら一括表示
            if (Input.GetMouseButtonDown(0))
            {
                //　ここまでに表示しているテキストに残りのメッセージを足す
                messageText.text += splitMessage[messageNum].Substring(nowTextNum);
                isOneMessage = true;
            }
            //　1回に表示するメッセージを表示した
        }
        else
        {

            elapsedTime += Time.deltaTime;

            //　クリックアイコンを点滅する時間を超えた時、反転させる
            if (elapsedTime >= clickFlashTime)
            {
                clickIcon.enabled = !clickIcon.enabled;
                elapsedTime = 0f;
            }

            //　マウスクリックされたら次の文字表示処理
            if (Input.GetMouseButtonDown(0))
            {
                nowTextNum = 0;
                messageNum++;
                messageText.text = "";
                clickIcon.enabled = false;
                elapsedTime = 0f;
                isOneMessage = false;

                //　メッセージが全部表示されていたらゲームオブジェクト自体の削除
                if (messageNum >= splitMessage.Length)
                {
                    isEndMessage = true;
                    transform.GetChild(0).gameObject.SetActive(false);
                }
            }
        }
    }
    //　新しいメッセージを設定
    void SetMessage(string message)
    {
        //このクラスのallMessageとして引数に指定されたmessageを設定
        this.allMessage = message;
        //　分割文字列で一回に表示するメッセージを分割する
        //空白の位置で、文字列を分割して文字列型の配列にそれぞれ格納する。オプションとして、空白は削除している
        splitMessage = Regex.Split(allMessage, @"\s*" + splitString + @"\s*", RegexOptions.IgnorePatternWhitespace);
        //現在のテキストナンバー、初期値に0を設定する
        nowTextNum = 0;
        //メッセージナンバー？初期値に0
        messageNum = 0;
        //テキストの初期状態として、何もない状態を設定する
        messageText.text = "";
        //1回分のメッセージを表示したかどうか
        isOneMessage = false;
        //メッセージをすべて表示したかどうか
        isEndMessage = false;
    }
    //　他のスクリプトから新しいメッセージを設定しUIをアクティブにする
    public void SetMessagePanel(string message)
    {
        SetMessage(message);
        transform.GetChild(0).gameObject.SetActive(true);
    }
}