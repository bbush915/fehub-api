using System;

namespace FEHub.Entity.Interfaces;

public interface ITrackable
{
    DateTime CreatedAt { get; set; }
    string CreatedBy { get; set; }
    DateTime ModifiedAt { get; set; }
    string ModifiedBy { get; set; }
    int Version { get; set; }
}
