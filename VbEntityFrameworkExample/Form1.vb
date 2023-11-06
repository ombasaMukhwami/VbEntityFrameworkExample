Public Class Form1
    Private db As IUnitOfWork
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Async Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ProgressBar1.Visible = True
        CheckedListBox1.Items.Clear()

        Using db = New UnitOfWork(New EmployeeDbContext())
            Dim tt = Await db.Employees.GetAll()
            Dim test = Await db.Departments.GetAll()
            Dim departments = test.ToList().Select(Function(x) New Testing With {
                                                    .Id = x.Id,
                                                    .Name = x.Name
                                                   }).ToList()
            Dim xtend = departments.Select(Function(x) New With {
                                           x.Id, x.Name
                                           }).ToList()

            xtend.ForEach(Sub(x) CheckedListBox1.Items.Add($"{x.Id}-{x.Name}"))
        End Using
        ProgressBar1.Visible = False
    End Sub
End Class



Public Class Testing
    Public Property Id() As Integer
    Public Property Name() As String
    Public Overrides Function ToString() As String
        Return $"{Id}, {Name}"
    End Function
End Class