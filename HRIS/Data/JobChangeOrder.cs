using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class JobChangeOrder : Entity {

    public int EmployeeId { get; set; }
    public Employee? Employee { get; set; }

    public int NewPositionId { get; set; }
    public Position? NewPosition { get; set; }

    public int NewUnitId { get; set; }
    public Unit? NewUnit { get; set; }

    [Column(TypeName = "date")]
    public DateTime JobChangeDate { get; set; }

    [Column(TypeName = "decimal(3,2)")]
    public decimal NewWorkingRates { get; set; }
    public override void Copy(Entity entity) {
        var copy = entity as JobChangeOrder;
        if (copy != null) {
            EmployeeId = copy.EmployeeId;
            NewPositionId = copy.NewPositionId;
            NewUnitId = copy.NewUnitId;
            JobChangeDate = copy.JobChangeDate;
            NewWorkingRates = copy.NewWorkingRates;
        }
    }
}
