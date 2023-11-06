Public Class UnitOfWork
    Implements IUnitOfWork

    Private disposed As Boolean
    Private ReadOnly _context As EmployeeDbContext
    Private ReadOnly Property _employees As IEmployeeRepository
    Private ReadOnly Property _departments As IDepartmentRepository
    Public Sub New(context As EmployeeDbContext)
        _context = context
    End Sub

    Public ReadOnly Property Employees As IEmployeeRepository Implements IUnitOfWork.Employees
        Get
            Return IIf(_employees Is Nothing, New EmployeeRepository(_context), _employees)
        End Get
    End Property

    Public ReadOnly Property Departments As IDepartmentRepository Implements IUnitOfWork.Departments
        Get
            Return IIf(_departments Is Nothing, New DepartmentRepository(_context), _departments)
        End Get
    End Property

    Public Sub Dispose() Implements IDisposable.Dispose
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub

    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not disposed AndAlso disposing Then
            _context.Dispose()
            disposed = True
        End If
    End Sub
End Class