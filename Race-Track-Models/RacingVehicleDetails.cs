using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Race.Track.Models
{
    public class RacingVehicleDetails
    {
        [Required]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Description can be empty.")]
        public string Description { get; set; }
        public int Senstivity { get; set; }
        public int Acceleration { get; set; }
        public int Linearity { get; set; }
        public int HorizonTilt { get; set; }
        public int GearBox { get; set; }
        public int Breaking { get; set; }
        public bool HandBreak { get; set; }
        public bool TowStrap { get; set; }

        [Range(0, 5)]
        public int CanLift { get; set; }
        public string VehichleImagePath { get; set; }
        public bool IsSetToRacingTrack { get; set; }
    }
}
