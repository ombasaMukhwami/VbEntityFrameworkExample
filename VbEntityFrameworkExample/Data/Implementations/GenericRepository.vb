Imports System.Data.Entity
Imports System.Linq.Expressions

Public Class GenericRepository(Of T As {Class})
    Implements IGenericRepository(Of T)

    Private ReadOnly _dbContext As EmployeeDbContext
    Private _table As DbSet(Of T)
    Public Sub New(dbContxt As EmployeeDbContext)
        _dbContext = dbContxt
        _table = _dbContext.Set(Of T)
    End Sub
    Public Async Function GetAll() As Task(Of IEnumerable(Of T)) Implements IGenericRepository(Of T).GetAll
        Return Await _table.ToListAsync()
    End Function

    Public Async Function GetAll(predicate As Expression(Of Func(Of T, Boolean))) As Task(Of IEnumerable(Of T)) Implements IGenericRepository(Of T).GetAll
        Return Await _table.Where(predicate).ToListAsync()
    End Function

    Public Async Function GetById(id As Integer) As Task(Of T) Implements IGenericRepository(Of T).GetById
        Return Await _table.FindAsync(id)
    End Function

    Public Async Function Find(predicate As Expression(Of Func(Of T, Boolean))) As Task(Of T) Implements IGenericRepository(Of T).Find
        Return Await _table.Where(predicate).FirstOrDefaultAsync()
    End Function
End Class
