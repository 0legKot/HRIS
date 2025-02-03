using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

public class Person : Entity {
    // ==== загальна інформація ====
    [Required]
    [MaxLength(50)]
    [Display(Name = "ПІБ")]
    public string PersonName { get; set; } = null!;

    [Required]
    [MaxLength(100)]
    [Display(Name = "Повне ім'я")]
    public string PersonNameFull { get; set; } = null!;

    [Display(Name = "Чоловік")]
    public bool IsMale { get; set; }

    [Display(Name = "Сімейний стан")]
    public bool MaritalStatus { get; set; }

    [Column(TypeName = "date")]
    [Display(Name = "Дата народження")]
    public DateTime BirthDate { get; set; }

    [Required]
    [MaxLength(255)]
    [Display(Name = "Місце проживання")]
    public string Residence { get; set; } = null!;

    [Required]
    [MaxLength(10)]
    [RegularExpression(@"^\d{10}$", ErrorMessage = "Номер телефону повинен мiстити 10 цифр.")]
    [Display(Name = "Номер телефону")]
    public string PhoneNumber { get; set; } = null!;

    [Display(Name = "Військова реєстрація")]
    public bool MilitaryRegistrationStatus { get; set; }

    [Display(Name = "Пенсіонер")]
    public bool IsPensioner { get; set; }

    [Display(Name = "Наявність дітей")]
    public bool HasChildren { get; set; }

    // ==== паспортні дані ====
    [Required]
    [MaxLength(10)]
    [RegularExpression(@"^\d{10}$", ErrorMessage = "Ідентифікаційний номер повинен мiстити 10 цифр.")]
    [Display(Name = "Ідентифікаційний номер")]
    public string IdentificationNumber { get; set; } = null!;

    [Required]
    [MaxLength(6)]
    [RegularExpression(@"^\d{6}$", ErrorMessage = "Номер паспорта повинен мiстити 6 цифр.")]
    [Display(Name = "Номер паспорта")]
    public string PassportNumber { get; set; } = null!;

    [Required]
    [MaxLength(2)]
    [Display(Name = "Серія паспорта")]
    public string PassportSeries { get; set; } = null!;

    [Column(TypeName = "date")]
    [Display(Name = "Дата видачі паспорта")]
    public DateTime PassportIssueDate { get; set; }

    [Required]
    [MaxLength(100)]
    [Display(Name = "Місце видачі паспорта")]
    public string PassportIssuePlace { get; set; } = null!;

    // ==== освіта ====
    [MaxLength(30)]
    [Display(Name = "Освіта")]
    public string? PersonEducation { get; set; }

    [MaxLength(30)]
    [Display(Name = "Кваліфікація")]
    public string? PersonQualification { get; set; }

    [MaxLength(50)]
    [Display(Name = "Номер диплома")]
    public string? DiplomaNumber { get; set; }

    [Column(TypeName = "date")]
    [Display(Name = "Дата закінчення")]
    public DateTime? DateOfGraduation { get; set; }

    [MaxLength(20)]
    [Display(Name = "Категорія")]
    public string? Category { get; set; }

    [MaxLength(20)]
    [Display(Name = "Розряд")]
    public string? Discharge { get; set; }

    [Display(Name = "Факультет")]
    public int? FacultyId { get; set; }

    [Display(Name = "Наукове звання")]
    public int? ScientificTitleId { get; set; }

    [Display(Name = "Науковий ступінь")]
    public int? ScientificDegreeId { get; set; }

    [Display(Name = "Спеціальність")]
    public int? SpecialtyId { get; set; }

    // ==== інвалідність ====
    [Display(Name = "Інвалідність")]
    public bool IsDisabled { get; set; }

    [Display(Name = "Група інвалідності")]
    public int? DisabilityGroup { get; set; }

    [MaxLength(50)]
    [Display(Name = "Свідоцтво інвалідності")]
    public string? DisabledCertificate { get; set; }

    // ==== навігаційні властивості ====
    [Display(Name = "Факультет")]
    public Faculty? Faculty { get; set; }

    [Display(Name = "Наукове звання")]
    public ScientificTitle? ScientificTitle { get; set; }

    [Display(Name = "Науковий ступінь")]
    public ScientificDegree? ScientificDegree { get; set; }

    [Display(Name = "Спеціальність")]
    public Specialty? Specialty { get; set; }

    [Display(Name = "Співробітники")]
    public ICollection<Employee>? Employees { get; set; }

    [Display(Name = "Прикази про прийом на роботу")]
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

            Employees ??= new List<Employee>();
            Employees.Clear();
            foreach (var item in copy.Employees ?? new List<Employee>()) {
                Employees.Add(item);
            }

            EmploymentOrders ??= new List<EmploymentOrder>();
            EmploymentOrders.Clear();
            foreach (var item in copy.EmploymentOrders ?? new List<EmploymentOrder>()) {
                EmploymentOrders.Add(item);
            }
        }
    }
}
