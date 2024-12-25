using System.Linq;
using System.Net;
using System.Threading.Tasks;
using QuickSend.Exceptions;
using QuickSend.Models;
using QuickSend.ResourcesNamespace;
using QuickSend.Services;
using QuickSend.UtilityCollection;
using ReactiveUI;

namespace QuickSend.ViewModels;

public class WelcomeScreenViewModel : ViewModelBase
{
    private string _username = string.Empty;
    
    private string Username 
    { 
        get => _username;
        set
        {
            _username = value;
            this.RaisePropertyChanged(nameof(IsSubmitEnabled));
        } 
    }

    private bool IsSubmitEnabled => !string.IsNullOrEmpty(Username) && !string.IsNullOrWhiteSpace(Username) && !Username.Any(char.IsWhiteSpace);

    private void Submit()
    {
        IPAddress? ownIp = null;
        Task.Run(async () =>
        {
#if DEBUG
            ownIp = await Utilities.GetLocalIpAddressAsync();
#else
            ownIp = await Utilities.GetIpAddressAsync();
#endif
        }).Wait();
        if (ownIp is null)
            throw new InvalidIpException("Own IP is null!");

        string id = Utilities.EncryptID(Username, ownIp);
        ApplicationVariables.MetaData!.LocalUser = new User(id, Username, Resources.MattBlue.ToUint32(), id, true)
        {
            IsOnline = true
        };

        if (MainWindowViewModel.Instance is { } instance)
            instance.IsWelcomeScreenVisible = false;
        
        ApplicationVariables.MetaData.IsFirstLogin = false;
        DataManager.SaveData(ApplicationVariables.MetaData, Utilities.MetaDataPath);
    }
}