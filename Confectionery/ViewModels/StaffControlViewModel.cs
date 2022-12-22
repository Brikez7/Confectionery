﻿namespace Confectionery.ViewModels
{
    public class StaffControlViewModel
    {
        public SweetStaffViewModel? NewStaff { get; set; }
        public List<SweetStaffViewModel> Staffs { get; set; } = new List<SweetStaffViewModel>();
        public AccountViewModel? User { get; set; }
        public StaffControlViewModel()
        {
        }
        public StaffControlViewModel(List<SweetStaffViewModel> staffsList, AccountViewModel user)
        {
            Staffs = staffsList;
            User = user;
        }
    }
}
