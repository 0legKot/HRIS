using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Employee : Entity {

    public int EmployeePersonId { get; set; }
    public Person? EmployeePerson { get; set; }

    public int PositionId { get; set; }
    public Position? Position { get; set; }

    public int UnitId { get; set; }
    public Unit? Unit { get; set; }

    [Column(TypeName = "date")]
    public DateTime? DateEmployment { get; set; }

    [Column(TypeName = "date")]
    public DateTime? DateDismissal { get; set; }

    [Column(TypeName = "decimal(10,2)")]
    public decimal EmployeeWorkingRate { get; set; }


    public ICollection<DismissalOrder>? DismissalOrders { get; set; }
    public ICollection<JobChangeOrder>? JobChangeOrders { get; set; }

    public override void Copy(Entity entity) {
        var copy = entity as Employee;
        if (copy != null) {
            EmployeePersonId = copy.EmployeePersonId;
            PositionId = copy.PositionId;
            UnitId = copy.UnitId;
            DateEmployment = copy.DateEmployment;
            DateDismissal = copy.DateDismissal;
            EmployeeWorkingRate = copy.EmployeeWorkingRate;
            DismissalOrders ??= [];
            DismissalOrders.Clear();
            foreach (var item in copy.DismissalOrders ?? []) {
                DismissalOrders.Add(item);
            }
            JobChangeOrders ??= [];
            JobChangeOrders.Clear();
            foreach (var item in copy.JobChangeOrders ?? []) {
                JobChangeOrders.Add(item);
            }
        }
    }
}
