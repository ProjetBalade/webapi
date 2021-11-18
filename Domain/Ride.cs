using System;

namespace Domain
{
    public class Ride
    {
        public int Id { get; set; }
        public String NameRide { get; set; }
        public String Place { get; set; }
        public String Description { get; set; }
        public String Website { get; set; }
        public int Difficulty { get; set; }
        public String Schedule { get; set; }
        public String Photo { get; set; }
        public int Score { get; set; }
        public int IdUser { get; set; }

        public Ride(int idUser)
        {
            IdUser = idUser;

        }

        public Ride()
        {
            
        }
    }
}