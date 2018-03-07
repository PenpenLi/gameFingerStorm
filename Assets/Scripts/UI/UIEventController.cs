using UnityEngine;
using System.Collections;

public class UIEventController : MonoBehaviour 
{
    private GameController _gameController;
    public GameController GameController
    {
        get
        {
            if (this._gameController == null)
                this._gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
            return this._gameController;
        }
    }

    public void Register ( GameObject registerObj )
    { 
        if (registerObj != null)
        {
            UIImageButton imageButton = registerObj.GetComponent<UIImageButton>();
            if (imageButton != null)
            {
                UIEventListener.Get(registerObj).onClick = HandleEvent;
            }
            else
            {
                UIButton button = registerObj.GetComponent<UIButton>();
                if (button != null)
                {
                    UIEventListener.Get(registerObj).onClick = HandleEvent;
                }
            }
        }
    }

    public void UnRegister ( GameObject registerObj )
    {
        if (registerObj != null)
            UIEventListener.Get(registerObj).onClick = null;
    }

    public void RegisterInHierarchy ( GameObject registerObj )
    {
        if(registerObj != null)
        {
            UIImageButton[] imageButtons = registerObj.GetComponentsInChildren<UIImageButton>();
            foreach (UIImageButton imageButton in imageButtons)
            {
                UIEventListener.Get(imageButton.gameObject).onClick = HandleEvent;
            }
            UIButton[] buttons = registerObj.GetComponentsInChildren<UIButton>();
            foreach (UIButton button in buttons)
            {
                UIEventListener.Get(button.gameObject).onClick = HandleEvent;
            }
        }
    }

    public void UnRegisterInHierarchy ( GameObject registerObj )
    {
        if (registerObj != null)
        {
            UIImageButton[] imageButtons = registerObj.GetComponentsInChildren<UIImageButton>();
            foreach (UIImageButton imageButton in imageButtons)
            {
                UIEventListener.Get(imageButton.gameObject).onClick = null;
            }
            UIButton[] buttons = registerObj.GetComponentsInChildren<UIButton>();
            foreach (UIButton button in buttons)
            {
                UIEventListener.Get(button.gameObject).onClick = null;
            }
        }
    }

    private void HandleEvent ( GameObject eventObj )
    {
        string eventObjTag = eventObj.tag;

        switch (eventObjTag)
        {
            case "HomePageStartGameButton":
                {
					
                    break;
                }
            case "HomePageOptionsButton":
                {
                    break;
                }
			case "HomePagePVEButton":
                {
					this.GameController.GameType = GameType.PVE;
                    this.GameController.MyFactionType = FactionType.Blue;
                    this.GameController.GetFSM().ChangeState(GameState_BeforeStartGame.Instance());
                    break;
                }
			case "HomePagePVPButton":
                {
					this.GameController.GameType = GameType.PVP;
                    this.GameController.GetFSM().ChangeState(GameState_Matching.Instance());
                    break;
                }
			case "GameResultBackToMenuButton":
			    {
				    Time.timeScale = 1;
				    GameSceneController gameSceneCtrl = GameObject.Find("GameSceneController").GetComponent<GameSceneController>();
				    gameSceneCtrl.BackToMainMenu();
				    this.GameController.GetFSM().ChangeState(GameState_HomePage.Instance());
				    break;
			    }
        }
    }
}
