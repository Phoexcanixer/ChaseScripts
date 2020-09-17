using UnityEngine;
using Common.Singleton;
using Chase;
using Chase.Table;
using Chase.Pieces;
using System.Collections;

public class BoardManage : ExSingleton<BoardManage>
{
    public ESelectGame eSelectGame;
    public ESelectStartColor eTurnPlayer;
    public Material guideMat, firstPlayerMat, secondPlayerMat, selectionFirstMat, selectionSecondMat;
    public DetailBox[] detailBoxes; // All Box

    #region Property
    public BasePieces presentPieces { get; set; } // PresentSelectPiece
    public BoxManage presentTargetBox { get; set; } // PresentSelectSlot

    public ChaseManage chaseManage { get; private set; }
    #endregion

    #region Chase
    public SubBoardMovePieces subBoardMovePieces = new SubBoardMovePieces();
    #endregion

    [ContextMenu("SetSlotBoxes")]
    void SetSlotBoxes()
    {
        for (int i = 0; i < detailBoxes.Length; i++)
        {
            for (int j = 0; j < detailBoxes[i].boxManages.Length; j++)
            {
                detailBoxes[i].boxManages[j].slot = new Vector2Int(i, j);
                detailBoxes[i].boxManages[j].name = $"Box[{i}][{j}]";
            }
        }
    }
    void Start()
    {
        switch (eSelectGame)
        {
            case ESelectGame.Chase: chaseManage = gameObject.AddComponent<ChaseManage>().ExecuteStart(); break;
            default:
                break;
        }
    }
    public void SwichTurn()
    {
        subBoardMovePieces.ClearBorad();
        presentPieces = null;
        presentTargetBox = null;

        eTurnPlayer = ~(eTurnPlayer - 1);

    }
}
