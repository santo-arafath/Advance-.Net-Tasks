using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zero_Hunger.DTOs
{
    public class RequestDTO
    {
        public RequestDTO()
        {


        }
        public int req_id { get; set; }
        public string food_type { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string quantity { get; set; }
        public string max_preservation_time { get; set; }
        public string location { get; set; }
        public string status { get; set; }
        public Nullable<int> rest_id { get; set; }
        public Nullable<int> assigned_employee_id { get; set; }
        public string details_food { get; set; }

        public Nullable<System.DateTime> date_of_order { get; set; }
    }
}