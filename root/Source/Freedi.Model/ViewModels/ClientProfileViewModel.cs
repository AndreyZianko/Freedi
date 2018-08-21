using System.Collections.Generic;

namespace Freedi.Model.ViewModels
{
    public class ClientProfileViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public List<OrderViewModel> Orders { get; set; }
    }
}