using Confectionery.Models;
using Confectionery.ViewModels;
using LibraryDatabaseCoffe.Models.DB.Tables;
using Mapster;

namespace Confectionery.Mapers
{
    [Mapper]
    public interface IMapsters 
    {
        public SStaffViewModel MapTo(SweetStaff sweetStaff);
        public IEnumerable<SStaffViewModel> MapTo(IEnumerable<SweetStaff> enumerable);
        public User MapTo(RegistrationViewModel sweetStaff);
        public AutorisationViewModel MapTo(User sweetStaff);
        public FStaffViewModel Map(SweetStaff sweetStaff);
        public Order Map(User sweetStaff);
        public BascetViewModel Map(DescriptionOrder sweetStaff);
        public IEnumerable<BascetViewModel> Map(IEnumerable<DescriptionOrder> sweetStaff);
    }
}
