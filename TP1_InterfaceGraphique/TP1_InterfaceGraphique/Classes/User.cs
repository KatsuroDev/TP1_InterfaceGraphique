﻿namespace TP1_InterfaceGraphique
{
    public class User
    {
        public int Id;
        public string FirstName;
        public string LastName;
        public string Password;

        public override string ToString()
        {
            return $"{Id} - {LastName}, {FirstName}";
        }
    }
}
