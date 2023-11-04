Imports System.Data.Entity

Public Class EmployeeDbContext
    Inherits DbContext

    Public Sub New()
        MyBase.New("SQLServerConnectionString")
        Me.Configuration.LazyLoadingEnabled = False
    End Sub

    Public Overridable Property Departments() As DbSet(Of Department)
    Public Overridable Property Employees() As DbSet(Of Employee)

End Class
