using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

public class Person : Entity {

    // ==== general info ====
    [Required]
    [MaxLength(50)]
    public string PersonName { get; set; } = null!;

    [Required]
    [MaxLength(100)]
    public string PersonNameFull { get; set; } = null!;

    public bool IsMale { get; set; }
    public bool MaritalStatus { get; set; }

    [Column(TypeName = "date")]
    public DateTime BirthDate { get; set; }

    [Required]
    [MaxLength(255)]
    public string Residence { get; set; } = null!;

    [Required]
    [MaxLength(10)]
    [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be 10 digits.")]
    public string PhoneNumber { get; set; } = null!;

    public bool MilitaryRegistrationStatus { get; set; }
    public bool IsPensioner { get; set; }
    public bool HasChildren { get; set; }

    // ==== passport info ====
    [Required]
    [MaxLength(10)]
    [RegularExpression(@"^\d{10}$", ErrorMessage = "Identification number must be 10 digits.")]
    public string IdentificationNumber { get; set; } = null!;

    [Required]
    [MaxLength(6)]
    [RegularExpression(@"^\d{6}$", ErrorMessage = "Passport number must be 6 digits.")]
    public string PassportNumber { get; set; } = null!;

    [Required]
    [MaxLength(2)]
    public string PassportSeries { get; set; } = null!;

    [Column(TypeName = "date")]
    public DateTime PassportIssueDate { get; set; }

    [Required]
    [MaxLength(100)]
    public string PassportIssuePlace { get; set; } = null!;

    // ==== education info ====
    [MaxLength(30)]
    public string? PersonEducation { get; set; }

    [MaxLength(30)]
    public string? PersonQualification { get; set; }

    [MaxLength(50)]
    public string? DiplomaNumber { get; set; }

    [Column(TypeName = "date")]
    public DateTime? DateOfGraduation { get; set; }

    [MaxLength(20)]
    public string? Category { get; set; }

    [MaxLength(20)]
    public string? Discharge { get; set; }

    public int? FacultyId { get; set; }
    public int? ScientificTitleId { get; set; }
    public int? ScientificDegreeId { get; set; }
    public int? SpecialtyId { get; set; }

    // ==== disability info ====
    public bool IsDisabled { get; set; }
    public int? DisabilityGroup { get; set; }

    [MaxLength(50)]
    public string? DisabledCertificate { get; set; }


    public Faculty? Faculty { get; set; }
    public ScientificTitle? ScientificTitle { get; set; }
    public ScientificDegree? ScientificDegree { get; set; }
    public Specialty? Specialty { get; set; }

    public ICollection<Employee>? Employees { get; set; }

    public ICollection<EmploymentOrder>? EmploymentOrders { get; set; }

    public override void Copy(Entity entity) {
        var copy = entity as Person;
        if (copy != null) {
            PersonName = copy.PersonName;
            PersonNameFull = copy.PersonNameFull;
            IsMale = copy.IsMale;
            MaritalStatus = copy.MaritalStatus;
            BirthDate = copy.BirthDate;
            Residence = copy.Residence;
            PhoneNumber = copy.PhoneNumber;
            MilitaryRegistrationStatus = copy.MilitaryRegistrationStatus;
            IsPensioner = copy.IsPensioner;
            HasChildren = copy.HasChildren;
            IdentificationNumber = copy.IdentificationNumber;
            PassportNumber = copy.PassportNumber;
            PassportSeries = copy.PassportSeries;
            PassportIssueDate = copy.PassportIssueDate;
            PassportIssuePlace = copy.PassportIssuePlace;
            PersonEducation = copy.PersonEducation;
            PersonQualification = copy.PersonQualification;
            DiplomaNumber = copy.DiplomaNumber;
            DateOfGraduation = copy.DateOfGraduation;
            Category = copy.Category;
            Discharge = copy.Discharge;
            FacultyId = copy.FacultyId;
            ScientificTitleId = copy.ScientificTitleId;
            ScientificDegreeId = copy.ScientificDegreeId;
            SpecialtyId = copy.SpecialtyId;
            IsDisabled = copy.IsDisabled;
            DisabilityGroup = copy.DisabilityGroup;
            DisabledCertificate = copy.DisabledCertificate;
            Employees ??= [];
            Employees.Clear();
            foreach (var item in copy.Employees ?? []) {
                Employees.Add(item);
            }
            EmploymentOrders ??= [];
            EmploymentOrders.Clear();
            foreach (var item in copy.EmploymentOrders ?? []) {
                EmploymentOrders.Add(item);
            }
        }
    }
}
