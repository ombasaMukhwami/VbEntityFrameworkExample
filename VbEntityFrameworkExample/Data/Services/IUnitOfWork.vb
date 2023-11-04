Public Interface IUnitOfWork
    Inherits IDisposable
    ReadOnly Property Employees As IEmployeeRepository
    ReadOnly Property Departments As IDepartmentRepository
End Interface
