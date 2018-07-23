using Freedi.DataProvider.Entites;
using Freedi.DataProvider.Identity;
using Freedi.DataProvider.Interfaces;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freedi.DataProvider.Repositories
{ 
    public class ClientRepository : BaseRepository<ClientRepository>,IClientRepository
    {
        private FreediContext _context;
        public ApplicationUserManager UserManager { get; }
        public ApplicationRoleManager RoleManager { get; }

        public ClientRepository(FreediContext context) : base(context)
        {
            
            _context = context;
            UserManager = new ApplicationUserManager(new UserStore<ApplicationUser>(_context));
            RoleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(_context));
        }

        public void Create(ClientProfile item)
        {
            _context.ClientProfiles.Add(item);
            _context.SaveChanges();
        }
    }
}
