Imports System
Imports System.Drawing
Imports System.Drawing.Bitmap
Imports System.Drawing.Imaging.Metafile
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports System.Runtime.InteropServices
Imports DportenisPro.DPTienda.ApplicationUnits.TwainGUI.vb.TwainLib
Imports DportenisPro.DPTienda.ApplicationUnits.TwainGUI.vb.GdiPlusLib
Imports MODI
Public Class SCANIFE
    Implements IMessageFilter

    <DllImport("kernel32.dll", ExactSpelling:=True)> Friend Shared Function GlobalLock(ByVal handle As IntPtr) As IntPtr
    End Function
    <DllImport("kernel32.dll", ExactSpelling:=True)> Friend Shared Function GlobalFree(ByVal handle As IntPtr) As IntPtr
    End Function
    <DllImport("kernel32.dll", CharSet:=CharSet.Auto)> Public Shared Sub OutputDebugString(ByVal outstr As String)
    End Sub

    Private vimg As Bitmap
    Private vimgrecorte As Bitmap
    Private vnombre_ife() As String
    Private vdireccion_ife() As String
    Private vfechnac_ife As String()
    Private vmesnac_ife As String
    Private vannonac_ife As String
    Private msgfilter As Boolean
    Private milayout As MODI.Layout
    Private WithEvents midoc As MODI.Document
    Private tw As Twain
    Private bmpptr As IntPtr
    Private pixptr As IntPtr
    Private bmi As TwainGui.BITMAPINFOHEADER
    Private bmprect As Rectangle
    Private dibhand As IntPtr

    <STAThread()> Shared Sub Main()
        If (Twain.ScreenBitDepth < 15) Then
            MessageBox.Show("Need high/true-color video mode!", "Screen Bit Depth", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
    End Sub
    Public Property imagen() As Bitmap
        Get
            Return vimg
        End Get
        Set(ByVal Value As Bitmap)
            vimg = Value
        End Set
    End Property
    Public Property imagenrecorte() As Bitmap
        Get
            Return vimgrecorte
        End Get
        Set(ByVal Value As Bitmap)
            vimgrecorte = Value
        End Set
    End Property

    Public Property nombre_ife() As String()
        Get
            Return vnombre_ife
        End Get
        Set(ByVal Value() As String)
            vnombre_ife = Value
        End Set
    End Property

    Public Property direccion_ife() As String()
        Get
            Return vdireccion_ife
        End Get
        Set(ByVal Value() As String)
            vdireccion_ife = Value
        End Set
    End Property

    Public Property fechnac_ife() As String()
        Get
            Return vfechnac_ife
        End Get
        Set(ByVal Value As String())
            vfechnac_ife = Value
        End Set
    End Property

    Public Sub AdquirirImagen()
        If (Not msgfilter) Then
            msgfilter = True
            Application.AddMessageFilter(Me)
        End If
        tw.Acquire()
    End Sub

    Public Function SelControlador()
        tw.Select()
    End Function

    Public Sub New(ByVal hwndp As IntPtr)
        tw = New Twain
        tw.Init(hwndp)
    End Sub

    Private Sub EndingScan()
        If (msgfilter) Then
            Application.RemoveMessageFilter(Me)
            msgfilter = False
        End If
    End Sub


    Protected Function GetPixelInfo(ByVal bmpptr As IntPtr) As IntPtr
        bmi = New TwainGui.BITMAPINFOHEADER

        Marshal.PtrToStructure(bmpptr, bmi)

        bmprect.X = bmprect.Y = 0
        bmprect.Width = bmi.biWidth
        bmprect.Height = bmi.biHeight

        If (bmi.biSizeImage = 0) Then
            bmi.biSizeImage = Int((((bmi.biWidth * bmi.biBitCount) + 31) & Hex(Not (31))) / 2 ^ 3) * bmi.biHeight
        End If

        Dim p As Integer = bmi.biClrUsed
        If ((p = 0) And (bmi.biBitCount <= 8)) Then
            p = Int(1 * 2 ^ bmi.biBitCount)
        End If
        p = (p * 4) + bmi.biSize + CType(bmpptr.ToInt32, Integer)
        Return New IntPtr(p)
    End Function

    Public Sub dibimagen(ByVal objimagen As Bitmap)
        objimagen = vimg
    End Sub


    Public Function PreFilterMessage(ByRef m As Message) As Boolean Implements IMessageFilter.PreFilterMessage
        Dim cmd As TwainCommand = tw.PassMessage(m)
        If (cmd = TwainCommand.Not) Then
            Return False
        End If

        Select Case cmd
            Case TwainCommand.CloseRequest
                EndingScan()
                tw.CloseSrc()
            Case TwainCommand.CloseOk
                EndingScan()
                tw.CloseSrc()
            Case TwainCommand.DeviceEvent
            Case TwainCommand.TransferReady

                Try
                    Dim img As IntPtr = tw.TransferPictures()
                    EndingScan()
                    tw.CloseSrc()
                    bmpptr = GlobalLock(img)
                    pixptr = GetPixelInfo(bmpptr)
                    Gdip.SaveDIBAs("C:\Scanner.bmp", bmpptr, pixptr)

                    vimg = Gdip.BitmapFromDIB(bmpptr, pixptr)
                    If Not vimg Is Nothing Then
                        vimg.Save("C:\ScannerBMP.bmp")
                        MsgBox("La imagen se ha obtenido... pulse 'Obtener datos'")
                    End If
                Catch ex As Exception
                    MsgBox(ex.ToString)
                End Try
        End Select
        Return True
    End Function
    Public Function GetNombre() As String()
        Try
            Dim rect As New Rectangle(0, 98, 250, 50)
            ReDim vnombre_ife(3)
            Dim nombreife As String
            'vimg.FromFile("C:\ScannerBMP.bmp")
            vimgrecorte = vimg.Clone(rect, vimg.PixelFormat)

            vimgrecorte.Save("C:\Nombre.bmp")
            vimgrecorte = Nothing

            midoc = New MODI.Document
            midoc.Create("C:\Nombre.bmp")
            midoc.OCR(MiLANGUAGES.miLANG_SPANISH)
            milayout = midoc.Images(0).Layout

            nombreife = milayout.Text
            vnombre_ife = nombreife.Split(Microsoft.VisualBasic.vbCrLf)
            vnombre_ife(0) = vnombre_ife(0).Replace("4", "A")
            vnombre_ife(0) = vnombre_ife(0).Replace("1", "I")
            vnombre_ife(0) = vnombre_ife(0).Replace("0", "O")
            vnombre_ife(0) = vnombre_ife(0).Replace(".", "")
            vnombre_ife(0) = vnombre_ife(0).Replace("$", "S")
            vnombre_ife(0).Trim()

            vnombre_ife(1) = vnombre_ife(1).Replace("4", "A")
            vnombre_ife(1) = vnombre_ife(1).Replace("1", "I")
            vnombre_ife(1) = vnombre_ife(1).Replace("0", "O")
            vnombre_ife(1) = vnombre_ife(1).Replace(".", "")
            vnombre_ife(1) = vnombre_ife(1).Replace("$", "S")
            vnombre_ife(1).Trim()

            vnombre_ife(2) = vnombre_ife(2).Replace("4", "A")
            vnombre_ife(2) = vnombre_ife(2).Replace("1", "I")
            vnombre_ife(2) = vnombre_ife(2).Replace("0", "O")
            vnombre_ife(2) = vnombre_ife(2).Replace(".", "")
            vnombre_ife(2) = vnombre_ife(2).Replace("$", "S")
            vnombre_ife(2).Trim()


            midoc.Close()
            milayout = Nothing
            midoc = Nothing

            Return vnombre_ife

        Catch ex As Exception
            MsgBox("El nombre no se ha digitalizado correctamente." + ex.ToString)
        End Try
    End Function

    Public Function GetDireccion() As String()
        Try
            Dim dir(), cdedo(), dir2 As String
            ReDim dir(4)
            ReDim cdedo(2)
            ReDim vdireccion_ife(6)
            Dim numero, codpos As Integer
            Dim rect As New Rectangle(0, 162, 333, 51)
            vimgrecorte = vimg.Clone(rect, vimg.PixelFormat)

            vimgrecorte.Save("C:\Direccion.bmp")
            vimgrecorte = Nothing

            midoc = New MODI.Document
            midoc.Create("C:\Direccion.bmp")
            midoc.OCR(MiLANGUAGES.miLANG_SPANISH)
            milayout = midoc.Images(0).Layout

            dir2 = milayout.Text

            dir = dir2.Split(Microsoft.VisualBasic.vbCrLf)
            dir(0).Trim()
            dir(1).Trim()
            dir(2).Trim()

            'obtener(numero)
            numero = dir(0).LastIndexOf(" ")
            'numero = dir(0).Length
            vdireccion_ife(0) = dir(0).Substring(numero + 1, dir(0).Length - (numero + 1))
            vdireccion_ife(0) = vdireccion_ife(0).Replace(".", "")

            'obtener calle
            vdireccion_ife(1) = dir(0).Substring(0, numero - 2)
            vdireccion_ife(1) = vdireccion_ife(1).Replace(".", "")
            vdireccion_ife(1) = vdireccion_ife(1).Replace("$", "S")

            'obtener cod postal
            codpos = dir(1).Length
            vdireccion_ife(2) = dir(1).Substring(codpos - 5, 5)
            vdireccion_ife(2) = vdireccion_ife(2).Replace(".", "")
            vdireccion_ife(2) = vdireccion_ife(2).Replace("$", "5")

            'obtner colonia
            vdireccion_ife(3) = dir(1).Substring(1, codpos - 6)
            vdireccion_ife(3) = vdireccion_ife(3).Replace(".", "")
            vdireccion_ife(3) = vdireccion_ife(3).Replace("$", "S")

            'separar ciudad y estado
            cdedo = dir(2).Split(" ")

            'obtener ciudad
            '''''''''''''''''vdireccion_ife(4) = dir(2).Substring(1, dir(2).Length - 1)
            vdireccion_ife(4) = cdedo(0).Substring(1, cdedo(0).Length - 1)
            vdireccion_ife(4) = vdireccion_ife(4).Replace("4", "A")
            vdireccion_ife(4) = vdireccion_ife(4).Replace("1", "I")
            vdireccion_ife(4) = vdireccion_ife(4).Replace("0", "O")
            vdireccion_ife(4) = vdireccion_ife(4).Replace(".", "")
            vdireccion_ife(4) = vdireccion_ife(4).Replace("$", "S")
            vdireccion_ife(4).Trim()

            'obtener estado
            vdireccion_ife(5) = cdedo(1)
            vdireccion_ife(5) = vdireccion_ife(5).Replace("4", "A")
            vdireccion_ife(5) = vdireccion_ife(5).Replace("1", "I")
            vdireccion_ife(5) = vdireccion_ife(5).Replace("0", "O")
            vdireccion_ife(5) = vdireccion_ife(5).Replace(",", "")
            vdireccion_ife(5) = vdireccion_ife(5).Replace(".", "")
            vdireccion_ife(5) = vdireccion_ife(5).Replace("$", "S")
            vdireccion_ife(5).Trim()

            midoc.Close()
            milayout = Nothing
            midoc = Nothing

            Return vdireccion_ife
        Catch ex As Exception
            MsgBox("La dirección no se ha digitalizado correctamente." + ex.ToString)
        End Try


    End Function

    Public Function GetFechNacimiento() As String()
        Dim fech, anno, mes, dia, annoact As String
        Dim anno2, annoact2 As Integer
        ReDim vfechnac_ife(2)
        Dim rect As New Rectangle(118, 225, 300, 30)
        vimgrecorte = vimg.Clone(rect, vimg.PixelFormat)

        vimgrecorte.Save("C:\Fechnac.bmp")
        vimgrecorte = Nothing

        midoc = New MODI.Document
        midoc.Create("C:\Fechnac.bmp")
        midoc.OCR(MiLANGUAGES.miLANG_SPANISH)
        milayout = midoc.Images(0).Layout

        fech = milayout.Text.Replace(Microsoft.VisualBasic.vbCrLf, " ")
        fech = fech.Replace(" ", "")
        anno = fech.Substring(6, 2)
        anno = anno.Replace("O", "0")
        anno = anno.Replace("I", "1")
        anno = anno.Replace("B", "8")
        anno = anno.Replace("T", "7")
        anno = anno.Replace("A", "4")
        anno = anno.Replace(".", "")

        mes = fech.Substring(8, 2)
        mes = mes.Replace("O", "0")
        mes = mes.Replace("I", "1")
        mes = mes.Replace("B", "8")
        mes = mes.Replace("T", "7")
        mes = mes.Replace("A", "4")
        mes = mes.Replace(".", "")

        dia = fech.Substring(10, 2)
        dia = dia.Replace("O", "0")
        dia = dia.Replace("I", "1")
        dia = dia.Replace("B", "8")
        dia = dia.Replace("T", "7")
        dia = dia.Replace("A", "4")
        dia = dia.Replace(".", "")

        annoact = DateString.Substring(6, 4)


        Try
            anno2 = Int32.Parse(anno)
            annoact2 = Int32.Parse(annoact)

            'AGREGAR 99 ó 20 al año
            If (2000 + anno2) < annoact2 Then
                If (annoact2 - (2000 + anno) < 17) Then
                    anno = "19" + anno
                ElseIf (annoact - (1900 + anno) > 99) Then
                    anno = "20" + anno
                End If
            Else
                anno = "19" + anno
            End If
        Catch ex As Exception
            MsgBox("La fecha de nacimiento no se ha digitalizado correctamente." + ex.ToString)
            anno = "00" + anno
        End Try

        vfechnac_ife(0) = dia + "/" + mes + "/" + anno
        vfechnac_ife(1) = fech  'contiene la clave de elector

        midoc.Close()
        milayout = Nothing
        midoc = Nothing

        Return vfechnac_ife
    End Function
End Class
