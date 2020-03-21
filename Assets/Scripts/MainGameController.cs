using MokomoGames;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using Zenject;

public class MainGameController : MonoBehaviour
{
    [Inject] private IMasterDataRepository _masterDataRepository;
    private MasterSequencer masterSequencer;
    public static UserDataContainer UserDataContainer { get; private set; }

    private void Start()
    {
        masterSequencer = FindObjectOfType<MasterSequencer>();
        masterSequencer.AllDisplay(false);

        async void OnLoggedIn(LoginResult result)
        {
            UserDataContainer = new UserDataContainer(result.PlayFabId, result.AuthenticationContext);
            _masterDataRepository.LoadAllTable();
            masterSequencer.ChangeSequenceWithLoading(
                () => _masterDataRepository.AllLoaded,
                MasterSequencer.SequencerType.Title);
        }

        void OnError(PlayFabError error)
        {
        }

#if UNITY_EDITOR
        LoginProvider.LoginByEditor("TestUser1", OnLoggedIn, OnError);
#elif UNITY_ANDROID || UNITY_IPHONE
        LoginProvider.LoginByMobile(OnLoggedIn, OnError);
#endif
        masterSequencer.ChangeSequenceWithLoading(
            () => UserDataContainer != null,
            MasterSequencer.SequencerType.Title);
    }

    private void Update()
    {
        masterSequencer.Tick();
    }
}