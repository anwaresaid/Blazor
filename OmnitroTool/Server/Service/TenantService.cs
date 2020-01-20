using Microsoft.EntityFrameworkCore;
using OmnitroTool.Server.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OmnitroTool.Server.Service
{
    public class TenantService
    {
        private omniservicesintContext _db;
        public TenantService(omniservicesintContext dbContext)
        {
            this._db = dbContext;
        }
        public async Task<List<string>> GetTenants()
        {
            var tenants = await _db.Tenants
                .Select(x => x.CompanyTitle).ToListAsync();
            return tenants;
        }
    }
}
