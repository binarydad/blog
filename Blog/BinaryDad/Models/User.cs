﻿using System;

namespace BinaryDad.Models
{
    public class User
    {
        public Guid ID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
