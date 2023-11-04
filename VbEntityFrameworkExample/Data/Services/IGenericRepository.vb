Imports System.Linq.Expressions

Public Interface IGenericRepository(Of T As {Class})
    Function GetAll() As Task(Of IEnumerable(Of T))
    Function GetAll(predicate As Expression(Of Func(Of T, Boolean))) As Task(Of IEnumerable(Of T))
    Function GetById(id As Integer) As Task(Of T)
    Function Find(predicate As Expression(Of Func(Of T, Boolean))) As Task(Of T)

End Interface
