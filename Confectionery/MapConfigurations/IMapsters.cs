using Confectionery.Models;
using Confectionery.ViewModels;
using LibraryDatabaseCoffe.Models.DB.Tables;
using Mapster;

namespace Confectionery.Mapers
{
    [Mapper]
    public interface IMapsters 
    {
        public SStaffViewModel MapToShortStaff(SweetStaff sweetStaff);
        public IEnumerable<SStaffViewModel> MapToShortStaffs(IEnumerable<SweetStaff> enumerable);
        public User MapToRegistratedUser(RegistrationViewModel sweetStaff);
        public AutorisationViewModel MapToAutorisationUser(User sweetStaff);
        public FStaffViewModel MapToFullStaff(SweetStaff sweetStaff);
        public BascetViewModel MapToBascet(DescriptionOrder sweetStaff);
        public IEnumerable<BascetViewModel> MapToBascets(IEnumerable<DescriptionOrder> sweetStaff);
        public UserViewModel MapToUserAccount(User user);
    }
}
