using System;

namespace BarberShop.Service.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public Customer CustomerId { get; set; }
        public DateTime DateTime { get; set; }
    }
}