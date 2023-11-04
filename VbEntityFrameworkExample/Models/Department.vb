Imports System.ComponentModel.DataAnnotations

Public Class Department
    Public Property Id() As Integer
    <StringLength(60)>
    Public Property Name() As String
    Public Overridable Property Employees() As List(Of Employee)
End Class
