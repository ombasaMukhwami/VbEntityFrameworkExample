Imports System.ComponentModel.DataAnnotations

Public Class Employee
    Public Property Id() As Integer
    <StringLength(60)>
    Public Property FirstName() As String
    <StringLength(60)>
    Public Property LastName() As String
    <StringLength(10)>
    Public Property Gender() As String

    Public Property Salary() As Decimal

    Public Property DepartmentId() As Integer
    Public Overridable Property Department() As Department
End Class

