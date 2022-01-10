Namespace DataObject

    Public Class itemsCombo


        Private valor As String
        Public Property _valor() As String
            Get
                Return valor
            End Get
            Set(ByVal value As String)
                valor = value
            End Set
        End Property


        Private nombre As String
        Public Property _nombre() As String
            Get
                Return nombre
            End Get
            Set(ByVal value As String)
                nombre = value
            End Set
        End Property

        Sub New(ByVal valor As String, ByVal nombre As String)
            Me.valor = valor
            Me.nombre = nombre
        End Sub

    End Class

End Namespace
