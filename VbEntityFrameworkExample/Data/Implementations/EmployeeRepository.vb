Public Class EmployeeRepository
    Inherits GenericRepository(Of Employee)
    Implements IEmployeeRepository

    Public Sub New(dbContxt As EmployeeDbContext)
        MyBase.New(dbContxt)
    End Sub
End Class
