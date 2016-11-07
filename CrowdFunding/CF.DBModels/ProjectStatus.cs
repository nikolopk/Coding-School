// <auto-generated>
// ReSharper disable ConvertPropertyToExpressionBody
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable InconsistentNaming
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable RedundantNameQualifier
// ReSharper disable RedundantOverridenMember
// ReSharper disable UseNameofExpression
// TargetFrameworkVersion = 4.51
#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning

namespace CF.DBModels
{

    // ProjectStatus
    public class ProjectStatus
    {
        public int Id { get; set; } // Id (Primary key)
        public string Name { get; set; } // Name (length: 50)

        // Reverse navigation
        public virtual System.Collections.Generic.ICollection<Project> Projects { get; set; } // Project.FK_Project_ProjectStatus

        public ProjectStatus()
        {
            Projects = new System.Collections.Generic.List<Project>();
        }
    }

}
// </auto-generated>
