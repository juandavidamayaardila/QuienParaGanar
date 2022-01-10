Imports Microsoft.VisualBasic

Imports System.Globalization
Imports System.Threading

Public Class Culture
    Inherits System.Web.UI.Page


    Protected Overrides Sub InitializeCulture()

        Dim culture As String = String.Empty

        If Not String.IsNullOrEmpty(Request("lang")) Then
            'se obtiene el valor del parametro.
            Dim lang As String = Request("lang").ToLower()
            'salvamos en Session el valor del parametro recibido
            Session("lang") = lang
            'se verifica que cultura se debe de utilizar de acuerdo al valor.
            Select Case lang
                Case "en"
                    Session("lang") = "EN"
                    Session("lang-img") = "Styles/images/usa_32.png"
                    culture = "en-us"
                    Exit Select
                Case "es"
                    Session("lang") = "ES"
                    Session("lang-img") = "Styles/images/col_32.png"
                    culture = "es-co"
                    Exit Select
                Case Else
                    Session("lang") = "ES"
                    Session("lang-img") = "Styles/images/col_32.png"
                    culture = "es-co"
                    Exit Select
            End Select

            Session("culture") = culture

        ElseIf String.IsNullOrEmpty(Session("lang")) Then

            ' se verifica el lenguaje del navegador
            Dim culturaNavegador As CultureInfo = CultureInfo.CreateSpecificCulture(Request.UserLanguages(0))

            Select Case culturaNavegador.TwoLetterISOLanguageName
                Case "en"
                    Session("lang") = "EN"
                    Session("lang-img") = "Styles/images/usa_32.png"
                    culture = "en-us"
                    Exit Select
                Case "es"
                    Session("lang") = "ES"
                    Session("lang-img") = "Styles/images/col_32.png"
                    culture = "es-co"
                    Exit Select
                Case Else
                    Session("lang") = "ES"
                    Session("lang-img") = "Styles/images/col_32.png"
                    culture = "es-co"
                    Exit Select
            End Select

            Session("culture") = culture

        Else

            culture = Session("culture")

        End If



        Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(culture)
        Thread.CurrentThread.CurrentUICulture = New CultureInfo(culture)

        MyBase.InitializeCulture()

    End Sub
End Class
