﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECOLibrary.DTOs.Loan.Responses
{
    public class LoanByIdResponse
    {
        public string Id { get; set; }
        public string BookName { get; set; }
        public string EmployeeName { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }

}
