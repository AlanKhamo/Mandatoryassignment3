using Microsoft.AspNetCore.SignalR;

namespace Assignment3.Hub
{
    public class KitchenHub :Hub<IKitchenHub>
    {
        public async Task Meassge()
        {
            await Clients.All.KitchenUpdate();
        }

    }
}
