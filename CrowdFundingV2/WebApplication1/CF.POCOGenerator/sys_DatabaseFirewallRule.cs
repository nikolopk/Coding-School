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

namespace CF.POCOGenerator
{

    // database_firewall_rules
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.24.0.0")]
    public class sys_DatabaseFirewallRule
    {
        public int Id { get; set; } // id
        public string Name { get; set; } // name (length: 128)
        public string StartIpAddress { get; set; } // start_ip_address (length: 45)
        public string EndIpAddress { get; set; } // end_ip_address (length: 45)
        public System.DateTime CreateDate { get; set; } // create_date
        public System.DateTime ModifyDate { get; set; } // modify_date
    }

}
// </auto-generated>