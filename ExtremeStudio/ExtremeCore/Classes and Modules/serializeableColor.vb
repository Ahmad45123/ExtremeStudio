﻿Imports System.Drawing

Public Class serializeableColor
    Public Property R As Integer
    Public Property G As Integer
    Public Property B As Integer
    Public Property A As Integer

    Public Function getColor() As Color
        Return Color.FromArgb(A, R, G, B)
    End Function

    Public Sub setColor(clr As Color)
        A = clr.A
        R = clr.R
        G = clr.G
        B = clr.B
    End Sub
End Class
