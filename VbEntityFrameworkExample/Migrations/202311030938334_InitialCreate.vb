Imports System
Imports System.Data.Entity.Migrations
Imports Microsoft.VisualBasic

Namespace Migrations
    Public Partial Class InitialCreate
        Inherits DbMigration
    
        Public Overrides Sub Up()
            CreateTable(
                "dbo.Departments",
                Function(c) New With
                    {
                        .Id = c.Int(nullable := False, identity := True),
                        .Name = c.String(maxLength := 60)
                    }) _
                .PrimaryKey(Function(t) t.Id)
            
            CreateTable(
                "dbo.Employees",
                Function(c) New With
                    {
                        .Id = c.Int(nullable := False, identity := True),
                        .FirstName = c.String(maxLength := 60),
                        .LastName = c.String(maxLength := 60),
                        .Gender = c.String(maxLength := 10),
                        .Salary = c.Decimal(nullable := False, precision := 18, scale := 2),
                        .DepartmentId = c.Int(nullable := False)
                    }) _
                .PrimaryKey(Function(t) t.Id) _
                .ForeignKey("dbo.Departments", Function(t) t.DepartmentId, cascadeDelete := True) _
                .Index(Function(t) t.DepartmentId)
            
        End Sub
        
        Public Overrides Sub Down()
            DropForeignKey("dbo.Employees", "DepartmentId", "dbo.Departments")
            DropIndex("dbo.Employees", New String() { "DepartmentId" })
            DropTable("dbo.Employees")
            DropTable("dbo.Departments")
        End Sub
    End Class
End Namespace
