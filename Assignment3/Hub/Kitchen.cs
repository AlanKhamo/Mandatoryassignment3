using Microsoft.AspNetCore.SignalR;

namespace Assignment3.Hub
{
    public class Kitchen :Hub<IKitchen>
    {
        public async Task Meassge()
        {
            await Clients.All.KitchenUpdate();
        }

    }
}
