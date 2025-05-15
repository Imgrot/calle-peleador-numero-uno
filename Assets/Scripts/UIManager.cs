using System;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image vidaPlayer;
    public Image vidaEnemy;

    public GameManager gameManager;

    private float vidaActualPlayer;
    private float vidaMaximaPlayer;
    private float vidaActualEnemy;
    private float vidaMaximaEnemy;

    void Update()
    {
        vidaUpdatePlayer();
        vidaUpdateEnemy();
        ActualizarBarraPlayer();
        ActualizarBarraEnemy();
    }

    private void vidaUpdatePlayer()
    {
        vidaActualPlayer = gameManager.numeroVidasPlayer;
        vidaMaximaPlayer = 10;
    }
    private void vidaUpdateEnemy()
    {
        vidaActualEnemy = gameManager.numeroVidasEnemy;
        vidaMaximaEnemy = 10;
    }
    private void ActualizarBarraPlayer()
    {
        vidaPlayer.fillAmount = Mathf.Lerp(vidaPlayer.fillAmount, vidaActualPlayer / vidaMaximaPlayer, Time.deltaTime * 1);
    }
    private void ActualizarBarraEnemy()
    {
        vidaPlayer.fillAmount = Mathf.Lerp(vidaPlayer.fillAmount, vidaActualEnemy / vidaMaximaEnemy, Time.deltaTime * 1);
    }
}
