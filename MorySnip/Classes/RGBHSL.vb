﻿' This tool is part of the xRay Toolkit and is provided free of charge by Bob Powell.
' This code is not guaranteed to be free from defects or fit for mechantability in any way.
' By using this tool in your own programs you agree to hold Robert W. Powell free from all
' damages direct or incidental that arise from such use.
' You may use this code free of charge in your own projects on condition that you place the
' following paragraph (enclosed in quotes below) in your applications help or about dialog.
' "Portions of this code provided by Bob Powell. Http://www.bobpowell.net"

Imports System
Imports System.Drawing

Public Class RGBHSL
    Public Class HSL
        Public Sub New()
            Me._h = 0
            Me._s = 0
            Me._l = 0
        End Sub 'New

        Private _h As Double
        Private _s As Double
        Private _l As Double

        Public Property H() As Double
            Get
                Return Me._h
            End Get
            Set(value As Double)
                Me._h = value
                Me._h = IIf(Me._h > 1, 1, IIf(Me._h < 0, 0, Me._h))
            End Set
        End Property

        Public Property S() As Double
            Get
                Return Me._s
            End Get
            Set(value As Double)
                Me._s = value
                Me._s = IIf(Me._s > 1, 1, IIf(Me._s < 0, 0, Me._s))
            End Set
        End Property

        Public Property L() As Double
            Get
                Return Me._l
            End Get
            Set(value As Double)
                Me._l = value
                Me._l = IIf(Me._l > 1, 1, IIf(Me._l < 0, 0, Me._l))
            End Set
        End Property
    End Class 'HSL

    Public Sub New()
    End Sub 'New

    '/ <summary>
    '/ Sets the absolute brightness of a colour
    '/ </summary>
    '/ <param name="c">Original colour</param>
    '/ <param name="brightness">The luminance level to impose</param>
    '/ <returns>an adjusted colour</returns>
    Public Shared Function SetBrightness(c As Color, brightness As Double) As Color
        Dim hsl As HSL = RGB_to_HSL(c)
        hsl.L = brightness
        Return HSL_to_RGB(hsl)
    End Function 'SetBrightness

    '/ <summary>
    '/ Modifies an existing brightness level
    '/ </summary>
    '/ <remarks>
    '/ To reduce brightness use a number smaller than 1. To increase brightness use a number larger tnan 1
    '/ </remarks>
    '/ <param name="c">The original colour</param>
    '/ <param name="brightness">The luminance delta</param>
    '/ <returns>An adjusted colour</returns>
    Public Shared Function ModifyBrightness(c As Color, brightness As Double) As Color
        Dim hsl As HSL = RGB_to_HSL(c)
        hsl.L *= brightness
        Return HSL_to_RGB(hsl)
    End Function 'ModifyBrightness

    '/ <summary>
    '/ Sets the absolute saturation level
    '/ </summary>
    '/ <remarks>Accepted values 0-1</remarks>
    '/ <param name="c">An original colour</param>
    '/ <param name="Saturation">The saturation value to impose</param>
    '/ <returns>An adjusted colour</returns>
    Public Shared Function SetSaturation(c As Color, Saturation As Double) As Color
        Dim hsl As HSL = RGB_to_HSL(c)
        hsl.S = Saturation
        Return HSL_to_RGB(hsl)
    End Function 'SetSaturation

    '/ <summary>
    '/ Modifies an existing Saturation level
    '/ </summary>
    '/ <remarks>
    '/ To reduce Saturation use a number smaller than 1. To increase Saturation use a number larger tnan 1
    '/ </remarks>
    '/ <param name="c">The original colour</param>
    '/ <param name="Saturation">The saturation delta</param>
    '/ <returns>An adjusted colour</returns>
    Public Shared Function ModifySaturation(c As Color, Saturation As Double) As Color
        Dim hsl As HSL = RGB_to_HSL(c)
        hsl.S *= Saturation
        Return HSL_to_RGB(hsl)
    End Function 'ModifySaturation

    '/ <summary>
    '/ Sets the absolute Hue level
    '/ </summary>
    '/ <remarks>Accepted values 0-1</remarks>
    '/ <param name="c">An original colour</param>
    '/ <param name="Hue">The Hue value to impose</param>
    '/ <returns>An adjusted colour</returns>
    Public Shared Function SetHue(c As Color, Hue As Double) As Color
        Dim hsl As HSL = RGB_to_HSL(c)
        hsl.H = Hue
        Return HSL_to_RGB(hsl)
    End Function 'SetHue

    '/ <summary>
    '/ Modifies an existing Hue level
    '/ </summary>
    '/ <remarks>
    '/ To reduce Hue use a number smaller than 1. To increase Hue use a number larger tnan 1
    '/ </remarks>
    '/ <param name="c">The original colour</param>
    '/ <param name="Hue">The Hue delta</param>
    '/ <returns>An adjusted colour</returns>
    Public Shared Function ModifyHue(c As Color, Hue As Double) As Color
        Dim hsl As HSL = RGB_to_HSL(c)
        hsl.H *= Hue
        Return HSL_to_RGB(hsl)
    End Function 'ModifyHue

    ''' <summary>
    ''' Converts a colour from HSL to RGB
    ''' </summary>
    ''' <param name="h"></param>
    ''' <param name="l"></param>
    ''' <param name="s"></param>
    ''' <returns>A Color structure containing the equivalent RGB values</returns>
    ''' <remarks>Adapted from the algoritm in Foley and Van-Dam</remarks>
    Public Shared Function HSL_to_RGB(h As Double, l As Double, s As Double) As Color
        Return HSL_to_RGB(New HSL() With {.H = h, .L = l, .S = s})
    End Function

    ''' <summary>
    ''' Converts a colour from HSL to RGB
    ''' </summary>
    ''' <remarks>Adapted from the algoritm in Foley and Van-Dam</remarks>
    ''' <param name="hsl">The HSL value</param>
    ''' <returns>A Color structure containing the equivalent RGB values</returns>
    Public Shared Function HSL_to_RGB(hsl As HSL) As Color
        Dim r As Double = 0
        Dim g As Double = 0
        Dim b As Double = 0
        Dim temp1, temp2 As Double

        If hsl.L = 0 Then
            r = 0
            g = 0
            b = 0
        Else
            If hsl.S = 0 Then
                r = hsl.L
                g = hsl.L
                b = hsl.L
            Else
                temp2 = IIf(hsl.L <= 0.5, hsl.L * (1.0 + hsl.S), hsl.L + hsl.S - hsl.L * hsl.S)
                temp1 = 2.0 * hsl.L - temp2

                Dim t3() As Double = {hsl.H + 1.0 / 3.0, hsl.H, hsl.H - 1.0 / 3.0}
                Dim clr() As Double = {0, 0, 0}
                Dim i As Integer
                For i = 0 To 2
                    If t3(i) < 0 Then
                        t3(i) += 1.0
                    End If
                    If t3(i) > 1 Then
                        t3(i) -= 1.0
                    End If
                    If 6.0 * t3(i) < 1.0 Then
                        clr(i) = temp1 + (temp2 - temp1) * t3(i) * 6.0
                    ElseIf 2.0 * t3(i) < 1.0 Then
                        clr(i) = temp2
                    ElseIf 3.0 * t3(i) < 2.0 Then
                        clr(i) = temp1 + (temp2 - temp1) * (2.0 / 3.0 - t3(i)) * 6.0
                    Else
                        clr(i) = temp1
                    End If
                Next i
                r = clr(0)
                g = clr(1)
                b = clr(2)
            End If
        End If

        Return Color.FromArgb(CInt(255 * r), CInt(255 * g), CInt(255 * b))
    End Function 'HSL_to_RGB

    '
    '/ <summary>
    '/ Converts RGB to HSL
    '/ </summary>
    '/ <remarks>Takes advantage of whats already built in to .NET by using the Color.GetHue, Color.GetSaturation and Color.GetBrightness methods</remarks>
    '/ <param name="c">A Color to convert</param>
    '/ <returns>An HSL value</returns>
    Public Shared Function RGB_to_HSL(c As Color) As HSL
        Dim hsl As New HSL()

        hsl.H = c.GetHue() / 360.0 ' we store hue as 0-1 as opposed to 0-360
        hsl.L = c.GetBrightness()
        hsl.S = c.GetSaturation()

        Return hsl
    End Function 'RGB_to_HSL
End Class 'RGBHSL
