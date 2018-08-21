﻿using System.Linq;
using Freedi.DataProvider.Entites;
using Freedi.DataProvider.Identity;
using Freedi.DataProvider.Interfaces;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Freedi.DataProvider.Repositories
{
    public class ClientRepository : BaseRepository<ClientRepository>, IClientRepository
    {
        private readonly FreediContext _context;

        public ClientRepository(FreediContext context) : base(context)
        {
            _context = context;
        }

        public void Create(ClientProfile item)
        {
            _context.ClientProfiles.Add(item);
            _context.SaveChanges();
        }

        public ClientProfile GetClientProfile(string userid)
        {
            return _context.ClientProfiles.FirstOrDefault(x => x.Id == userid);
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