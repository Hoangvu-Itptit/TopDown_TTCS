using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SelectCharacter : BasePopup
{
    public static SelectCharacter Instance;
    public PlayerDataSO modelData;

    [Header("Button Select Player")] public Transform content;
    public SelectModelButton btnSelectPrefabs;
    public GameObject btnSelectModel;
    [HideInInspector] public List<SelectModelButton> listItemSelects;

    [Header("Model Data Player")] public Transform model;
    public List<(GameObject models, int indexInSO)> modelSelects = new();
    public TMP_Text nameModel;
    public GameObject dataUI;
    public TMP_Text hp;
    public TMP_Text moveSpeed;

    private int _oldIndexSelectModel = 0;

    public override void Awake()
    {
        base.Awake();
        Instance = this;
    }

    private void OnEnable()
    {
        var numModelActive = 0;
#if UNITY_EDITOR
        PrefData.SetHaveModel(0);
        PrefData.SetHaveModel(1);
#endif

        for (var i = 0; i < modelData.listPlayerData.Count; i++)
        {
            if (PrefData.IsHaveGun(i))
            {
                var newModel =
                    Instantiate(modelData.listPlayerData[i].model.transform.GetChild(0).GetChild(0).gameObject, model);
                modelSelects.Add((newModel, i));
                newModel.transform.localScale = Vector3.one * 150;
                newModel.transform.localRotation = Quaternion.Euler(0, 180, 0);
                newModel.gameObject.SetActive(false);
                var btn = Instantiate(btnSelectPrefabs, content);
                listItemSelects.Add(btn);
                btn.index = numModelActive;
                btn.SetPlayerData = modelData.listPlayerData[i];
                btn.Init();
                numModelActive++;
            }
        }
    }

    public void ChangeUI(int index, PlayerData data)
    {
        nameModel.text = data.name;
        nameModel.gameObject.SetActive(true);
        modelSelects[_oldIndexSelectModel].models.SetActive(false);
        modelSelects[index].models.SetActive(true);
        modelSelects[index].models.GetComponent<Animator>().Play(CONST.HUMAN_ANIMATION_IDLE_NO_GUN);
        _oldIndexSelectModel = index;
        dataUI.SetActive(true);
        hp.text = data.hp + "";
        moveSpeed.text = data.moveSpeed + "";
        btnSelectModel.SetActive(PrefData.player_type != modelSelects[_oldIndexSelectModel].indexInSO);
    }

    public void BtnListener_SelectThisItem()
    {
        PrefData.player_type = modelSelects[_oldIndexSelectModel].indexInSO;
        btnSelectModel.SetActive(false);
    }

    private void OnDisable()
    {
        dataUI.SetActive(false);
        modelSelects[_oldIndexSelectModel].models.SetActive(false);
        nameModel.gameObject.SetActive(false);
        btnSelectModel.SetActive(false);
    }
}