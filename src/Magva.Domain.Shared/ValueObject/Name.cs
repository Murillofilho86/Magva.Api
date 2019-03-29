﻿namespace Magva.Domain.Shared.ValueObject
{
    public class Name
    {
 
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}