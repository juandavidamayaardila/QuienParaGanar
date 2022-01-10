Namespace DataObject

    Public Class Mensajes


        Private codigo As Integer
        Public Property _codigo() As Integer
            Get
                Return codigo
            End Get
            Set(ByVal value As Integer)
                codigo = value
            End Set
        End Property


        Private mensaje As String
        Public Property _mensaje() As String
            Get
                Return mensaje
            End Get
            Set(ByVal value As String)
                mensaje = value
            End Set
        End Property


        Private entregador As String
        Public Property _entregador() As String
            Get
                Return entregador
            End Get
            Set(ByVal value As String)
                entregador = value
            End Set
        End Property

        Private fechaInicial As String
        Public Property _fechaInicial() As String
            Get
                Return fechaInicial
            End Get
            Set(ByVal value As String)
                fechaInicial = value
            End Set
        End Property

        Private fechaFinal As String
        Public Property _fechaFinal() As String
            Get
                Return fechaFinal
            End Get
            Set(ByVal value As String)
                fechaFinal = value
            End Set
        End Property

        Private usuario As String
        Public Property _usuario() As String
            Get
                Return usuario
            End Get
            Set(ByVal value As String)
                usuario = value
            End Set
        End Property

        Private guia As String
        Public Property _guia() As String
            Get
                Return guia
            End Get
            Set(ByVal value As String)
                guia = value
            End Set
        End Property

    End Class
End Namespace
