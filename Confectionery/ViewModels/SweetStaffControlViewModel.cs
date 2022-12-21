namespace Confectionery.ViewModels
{
    public class SweetStaffControlViewModel
    {
        public SweetStaffViewModel? NewSweetStaffView { get; set; }
        public List<SweetStaffViewModel> SweetStaffViewModels { get; set; }

        public SweetStaffControlViewModel(List<SweetStaffViewModel> sweetStaffViewModels)
        {
            SweetStaffViewModels = sweetStaffViewModels;
        }
    }
}
