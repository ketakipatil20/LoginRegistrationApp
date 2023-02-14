using FormRollOffRepo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormRollOffRepo.Reository
{
    public class UserDetails : IUserDetails
    {
        private readonly OurExcelDataContext OurExcelDataContext;

        public UserDetails(OurExcelDataContext ourExcelData)
        {
            this.OurExcelDataContext = ourExcelData;
        }

        public async Task<Usertable> AddUserAsync(Usertable user)
        {
            await OurExcelDataContext.AddAsync(user);
            await OurExcelDataContext.SaveChangesAsync();
            return user;
        }
        public async Task<IEnumerable<Usertable>> GetData()
        {
            return await OurExcelDataContext.Usertables.ToListAsync();
        }

    }
}
