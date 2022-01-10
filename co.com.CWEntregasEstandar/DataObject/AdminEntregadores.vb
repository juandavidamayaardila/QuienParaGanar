Namespace DataObject

    Public Class AdminEntregadores


        Private codigo As Integer
        Public Property _codigo() As Integer
            Get
                Return codigo
            End Get
            Set(ByVal value As Integer)
                codigo = value
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


        Private telefono As String
        Public Property _telefono() As String
            Get
                Return telefono
            End Get
            Set(ByVal value As String)
                telefono = value
            End Set
        End Property

        Private email As String
        Public Property _email() As String
            Get
                Return email
            End Get
            Set(ByVal value As String)
                email = value
            End Set
        End Property

        Private clave As String
        Public Property _clave() As String
            Get
                Return clave
            End Get
            Set(ByVal value As String)
                clave = value
            End Set
        End Property

        Private activo As String
        Public Property _activo() As String
            Get
                Return activo
            End Get
            Set(ByVal value As String)
                activo = value
            End Set
        End Property
       

    End Class
End Namespace
