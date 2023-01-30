using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using TMPro;
using PlayFab;

internal sealed class UICanvas : MonoBehaviourPunCallbacks
{
    [SerializeField] private Button _playfabButtonRequest;
    [SerializeField] private Button _photonButtonConnect;
    [SerializeField] private Button _photonButtonDisconnect;
    [SerializeField] private TMP_Text _playfabStatus;
    [SerializeField] private TMP_Text _playfabMessage;
    [SerializeField] private TMP_Text _photonStatus;
    [SerializeField] private TMP_Text _photonMessage;
}
