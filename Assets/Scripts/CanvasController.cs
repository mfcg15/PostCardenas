using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    [SerializeField] Text textCountMoney;
    [SerializeField] GameObject imageKey, imageRabbit, imageMoney;
    [SerializeField] GameObject panelCoin, panelTask;
    [SerializeField] Text textPlay;

    private bool key = false, rabbit = false, money = false;

    private void Awake()
    {
        PlayerController.onCoinsChange += OnMoneyChangeHandler;
    }
    void Start()
    {
        PlayerController.onTaskMoney += onActiveImageMoney;
        PlayerController.onTaskKey += onActiveImageKey;
        RabbitController.onTaskRabbit += onActiveImageRabbit;
        LaptopController.onActivePanel += onActivePanels;
    }

    void Update()
    {
        if (key == true && money == true && rabbit == true)
        {
            textPlay.text = "Mision cumplida. ¡Has ganado!";
            Debug.Break();
        }
    }


    public void OnMoneyChangeHandler(int money)
    {
        textCountMoney.text = "x"+ money;
    }

    public void onActiveImageMoney (bool status)
    {
        imageMoney.SetActive(status);
        money = status;
    }

    public void onActiveImageKey(bool status)
    {
        imageKey.SetActive(status);
        key = status;
    }

    public void onActiveImageRabbit(bool status)
    {
        imageRabbit.SetActive(status);
        rabbit = status;
    }

    public void onActivePanels(bool status)
    {
        panelCoin.SetActive(status);
        panelTask.SetActive(status);
    }

}
