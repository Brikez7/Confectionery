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
        public SStaffViewModel MapToShortStaff(SweetStaff x)
        {
            return new SStaffViewModel((int)x.StaffId, x.StaffName, x.Classification, x.Price);
        }
        public IEnumerable<SStaffViewModel> MapToShortStaffs(IEnumerable<SweetStaff> p1)
        {
            return p1 == null ? null : p1.Select<SweetStaff, SStaffViewModel>(funcMain1);
        }
        public User MapToRegistratedUser(RegistrationViewModel x)
        {
            return new User(x.Name, x.Email, x.Password);
        }
        public AutorisationViewModel MapToAutorisationUser(User x)
        {
            return new AutorisationViewModel(x.EmailUser, x.Password);
        }
        public FStaffViewModel MapToFullStaff(SweetStaff x)
        {
            return new FStaffViewModel((int)x.StaffId, x.StaffName, x.DateDeliver, x.Weight, x.Price, x.Calories, x.Classification, x.Company.CompanyName);
        }
        public BascetViewModel MapToBascet(DescriptionOrder x)
        {
            return new BascetViewModel((int)x.DescriptionId, x.AmountSweetStaff, x.SweetStaff.StaffName, x.SweetStaff.Weight, x.SweetStaff.Price, x.SweetStaff.Calories, x.StaffId);
        }
        public IEnumerable<BascetViewModel> MapToBascets(IEnumerable<DescriptionOrder> p3)
        {
            return p3 == null ? null : p3.Select<DescriptionOrder, BascetViewModel>(funcMain2);
        }
        public UserViewModel MapToUserAccount(User x)
        {
            return new UserViewModel(new UserAccountView(x.EmailUser, x.NameUser, x.TotalSpent), x.Orders != null ? x.Orders.Select<Order, OrderView>(funcMain3).ToList<OrderView>() : new List<OrderView>());
        }
        
        private SStaffViewModel funcMain1(SweetStaff p2)
        {
            return new SStaffViewModel((int)p2.StaffId, p2.StaffName, p2.Classification, p2.Price);
        }
        
        private BascetViewModel funcMain2(DescriptionOrder p4)
        {
            return new BascetViewModel((int)p4.DescriptionId, p4.AmountSweetStaff, p4.SweetStaff.StaffName, p4.SweetStaff.Weight, p4.SweetStaff.Price, p4.SweetStaff.Calories, p4.StaffId);
        }
        
        private OrderView funcMain3(Order x)
        {
            return new OrderView(x.OrderId ?? -1, x.DateOrder, (float)x.Total, x.StatusOrder, x.DescriptionOrders != null ? x.DescriptionOrders.ToDictionary<DescriptionOrder, string, short>(funcMain4, funcMain5) : new Dictionary<string, short>());
        }
        
        private string funcMain4(DescriptionOrder u)
        {
            return u.SweetStaff.StaffName;
        }
        
        private short funcMain5(DescriptionOrder u)
        {
            return (short)u.AmountSweetStaff;
        }
    }
}