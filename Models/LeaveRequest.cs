namespace LeaveManagementSystem.Models
{
    public class LeaveRequest
    {
        public int Id { get; set; }               // Primary key
        public string EmployeeName { get; set; }  // Employee applying leave
        public string Reason { get; set; }        // Leave reason
        public DateTime StartDate { get; set; }   // Start date
        public DateTime EndDate { get; set; }     // End date
        public string Status { get; set; } = "Pending"; // Pending/Approved/Rejected
    }
}
