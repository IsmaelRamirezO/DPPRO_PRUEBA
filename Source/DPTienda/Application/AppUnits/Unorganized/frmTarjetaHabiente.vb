Public Class frmTarjetaHabiente

#Region "Variables de instancias"

    Private m_Nombre As String
    Private m_Paterno As String
    Private m_Materno As String
    Private m_NombreCliente As String

#End Region

#Region "Propiedades"

    Public Property Nombre As String
        Get
            Return m_Nombre
        End Get
        Set(ByVal value As String)
            m_Nombre = value
        End Set
    End Property

    Public Property Paterno As String
        Get
            Return m_Paterno
        End Get
        Set(ByVal value As String)
            m_Paterno = value
        End Set
    End Property

    Public Property Materno As String
        Get
            Return m_Materno
        End Get
        Set(ByVal value As String)
            m_Materno = value
        End Set
    End Property

    Public Property NombreCliente As String
        Get
            Return m_NombreCliente
        End Get
        Set(ByVal value As String)
            m_NombreCliente = value
        End Set
    End Property

#End Region

#Region "Metodos y funciones"

    Private Function ValidarCampos() As Boolean
        Dim valido As Boolean = True
        Dim mensaje As String = ""
        If txtNombre.Text.Trim() = "" Then
            valido = False
            mensaje &= "El Nombre" & vbCrLf
        End If
        If txtPaterno.Text.Trim() = "" Then
            valido = False
            mensaje &= "El Apellido Paterno" & vbCrLf
        End If
        If txtMaterno.Text.Trim() = "" Then
            valido = False
            mensaje &= "El Apellido Materno" & vbCrLf
        End If
        If valido = False Then
            MessageBox.Show("Faltan capturar los siguientes campos:" & vbCrLf & mensaje, "Dportenis PRO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        Return valido
    End Function

    Private Sub CargarNombre()
        If ValidarCampos() Then
            Me.Nombre = QuitarSignos(txtNombre.Text.Trim())
            Me.Paterno = QuitarSignos(txtPaterno.Text.Trim())
            Me.Materno = QuitarSignos(txtMaterno.Text.Trim())
            Me.NombreCliente = Me.Nombre & " " & Me.Paterno & " " & Me.Materno
            Me.DialogResult = DialogResult.OK
            Me.Dispose()
        End If
    End Sub
    '--------------------------------------------------------------------
    ' FLIZARRAGA 20/10/2017: Funcion para quitar signos de puntuacion.
    '--------------------------------------------------------------------
    Private Function QuitarSignos(ByVal texto As String) As String
        Dim consignos As String = "áàäéèëíìïóòöúùuñÁÀÄÉÈËÍÌÏÓÒÖÚÙÜÑçÇ|"
        Dim sinsignos As String = "aaaeeeiiiooouuunAAAEEEIIIOOOUUUNcC|"
        For v As Integer = 0 To sinsignos.Length - 1
            Dim i As String = consignos.Substring(v, 1)
            Dim j As String = sinsignos.Substring(v, 1)
            texto = texto.Replace(i, j)
        Next
        Return texto
    End Function

#End Region

#Region "Eventos"

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        CargarNombre()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Dispose()
    End Sub
    
#End Region

    
    
End Class