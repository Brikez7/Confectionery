using System;
using System.Collections.Generic;
using System.Linq;
using Confectionery.Mapers;
using Confectionery.Models;
using Confectionery.ViewModels;
using LibraryDatabaseCoffe.Models.DB.Tables;

namespace Confectionery.Mapers
{
    public partial class Mapsters : IMapsters
    {
        public SStaffViewModel MapTo(SweetStaff x)
        {
            return new SStaffViewModel((int)x.StaffId, x.StaffName, x.Classification, x.Price);
        }
        public IEnumerable<SStaffViewModel> MapTo(IEnumerable<SweetStaff> p1)
        {
            return p1 == null ? null : p1.Select<SweetStaff, SStaffViewModel>(funcMain1);
        }
        public User MapTo(RegistrationViewModel x)
        {
            return new User(x.Name, x.Email, x.Password);
        }
        public AutorisationViewModel MapTo(User x)
        {
            return new AutorisationViewModel(x.EmailUser, x.Password);
        }
        public FStaffViewModel Map(SweetStaff x)
        {
            return new FStaffViewModel((int)x.StaffId, x.StaffName, x.DateDeliver, x.Weight, x.Price, x.Calories, x.Classification, x.Company.CompanyName);
        }
        public Order Map(User x)
        {
            return new Order((int)x.UserId, DateTime.Now);
        }
        public BascetViewModel Map(DescriptionOrder x)
        {
            return new BascetViewModel((int)x.DescriptionId, x.AmountSweetStaff, x.SweetStaff.StaffName, x.SweetStaff.Weight, x.SweetStaff.Price, x.SweetStaff.Calories, x.StaffId);
        }
        public IEnumerable<BascetViewModel> Map(IEnumerable<DescriptionOrder> p3)
        {
            return p3 == null ? null : p3.Select<DescriptionOrder, BascetViewModel>(funcMain2);
        }
        
        private SStaffViewModel funcMain1(SweetStaff p2)
        {
            return new SStaffViewModel((int)p2.StaffId, p2.StaffName, p2.Classification, p2.Price);
        }
        
        private BascetViewModel funcMain2(DescriptionOrder p4)
        {
            return new BascetViewModel((int)p4.DescriptionId, p4.AmountSweetStaff, p4.SweetStaff.StaffName, p4.SweetStaff.Weight, p4.SweetStaff.Price, p4.SweetStaff.Calories, p4.StaffId);
        }
    }
}