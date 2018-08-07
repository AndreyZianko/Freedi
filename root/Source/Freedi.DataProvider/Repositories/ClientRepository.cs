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

        public ClientRepository(FreediContext context) : base(context)
        {
            
            _context = context;
      
        }

        public void Create(ClientProfile item)
        {
            _context.ClientProfiles.Add(item);
            _context.SaveChanges();
        }
        public ApplicationUserManager UserManager()
        {
            return new ApplicationUserManager(new UserStore<ApplicationUser>(_context));
        }
        public ApplicationRoleManager RoleManager()
        {
            return new ApplicationRoleManager(new RoleStore<ApplicationRole>(_context));
        }
    }
}
