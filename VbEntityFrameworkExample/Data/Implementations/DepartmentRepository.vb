Public Class DepartmentRepository
    Inherits GenericRepository(Of Department)
    Implements IDepartmentRepository

    Public Sub New(dbContxt As EmployeeDbContext)
        MyBase.New(dbContxt)
    End Sub
End Class
