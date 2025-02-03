using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class StaffSchedule : Entity {

    public int UnitId { get; set; }
    public Unit? Unit { get; set; }

    public int PositionId { get; set; }
    public Position? Position { get; set; }

    [Column(TypeName = "decimal(6,2)")]
    [Display(Name = "Кiлкiсть посад")]
    public decimal NumberOfPositions { get; set; }

    [Column(TypeName = "decimal(6,2)")]
    [Display(Name = "Кiлкiсть зайнятих посад")]
    public decimal NumberOfPositionsOccupied { get; set; }

    public override void Copy(Entity entity) {
        var copy = entity as StaffSchedule;
        if (copy != null) {
            UnitId = copy.UnitId;
            PositionId = copy.PositionId;
            NumberOfPositions = copy.NumberOfPositions;
            NumberOfPositionsOccupied = copy.NumberOfPositionsOccupied;
        }
    }
}
