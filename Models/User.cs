﻿namespace Rezervation.Models
{
    public class User
    {

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Phonenumber { get; set; }
        public int RoleId { get; set; }
        public ICollection<Trip> Trips { get; set; }
    }
}
