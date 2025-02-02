using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class DismissalOrder : Entity {

    [Column(TypeName = "date")]
    public DateTime DismissalDate { get; set; }

    public int EmployeeId { get; set; }
    public Employee? Employee { get; set; }

    public override void Copy(Entity entity) {
        var copy = entity as DismissalOrder;
        if (copy != null) {
            DismissalDate = copy.DismissalDate;
            EmployeeId = copy.EmployeeId;
        }
    }
}
