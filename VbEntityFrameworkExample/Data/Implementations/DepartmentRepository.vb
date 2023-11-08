Imports System.Data.Entity
Imports System.Linq.Expressions

Public Class DepartmentRepository
    Inherits GenericRepository(Of Department)
    Implements IDepartmentRepository

    Public Sub New(dbContxt As EmployeeDbContext)
        MyBase.New(dbContxt)
    End Sub
    Public ReadOnly Property EmpContext() As EmployeeDbContext
        Get
            Return TryCast(_dbContext, EmployeeDbContext)
        End Get
    End Property
    Public Overrides Async Function GetAll() As Task(Of IEnumerable(Of Department))
        Return Await EmpContext.Departments.Include(Function(x) x.Employees).ToListAsync()
    End Function
End Class
