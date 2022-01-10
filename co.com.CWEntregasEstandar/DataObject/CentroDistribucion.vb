Namespace DataObject

    Public Class CentroDistribucion


        Private codigo As Integer
        Public Property _codigo() As Integer
            Get
                Return codigo
            End Get
            Set(ByVal value As Integer)
                codigo = value
            End Set
        End Property


        Private descripcion As String
        Public Property _descripcion() As String
            Get
                Return descripcion
            End Get
            Set(ByVal value As String)
                descripcion = value
            End Set
        End Property

    End Class
End Namespace
