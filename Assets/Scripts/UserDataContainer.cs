using PlayFab;

public class UserDataContainer
{
    public UserDataContainer(string playFabId, PlayFabAuthenticationContext playFabAuthenticationContext = null)
    {
        PlayFabId = playFabId;
        PlayFabAuthenticationContext = playFabAuthenticationContext;
    }

    public string PlayFabId { get; }
    public PlayFabAuthenticationContext PlayFabAuthenticationContext { get; }
}