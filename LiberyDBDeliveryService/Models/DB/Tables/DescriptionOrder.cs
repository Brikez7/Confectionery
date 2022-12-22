namespace LibraryDatabaseCoffe.Models.DB.Tables
{
    public class DescriptionOrder
    {
        public int UserId { get; set; }
        public int? DescriptionId{ get; set; }
        public int? Orderid { get; set; }
        public int AmountSweetStaff { get; set; }   
        public int StaffId { get; set; }
        //(System.Int32 order_id, System.Int32 staff_id, System.Int16 amount, System.Int32 description_id, System.Int32 user_id)
        public DescriptionOrder(int amountSweetStaff, int staffId,int user_id)
        {
            AmountSweetStaff = amountSweetStaff;
            StaffId = staffId;
            UserId = user_id;
        }

        public DescriptionOrder(int order_id, int staff_id, short amount, int description_id, int user_id)
        {
            UserId = user_id;
            DescriptionId = description_id;
            Orderid = order_id;
            AmountSweetStaff = amount;
            StaffId = staff_id;
        }

        public Order? Order { get; set; }
        public SweetStaff? SweetStaff { get; set; }
    }
}
