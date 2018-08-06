Imports System.Globalization

Public Module Settings
    Public Property Setting(Name As String, Optional [Default] As String = "") As String
        Get
            Return GetSetting(Application.CompanyName, Application.ProductName, Name, [Default])
        End Get
        Set(ByVal value As String)
            SaveSetting(Application.CompanyName, Application.ProductName, Name, value)
        End Set
    End Property

    Public Sub RemoveSetting(Name As String)
        If Not String.IsNullOrWhiteSpace(Setting(Name)) Then DeleteSetting(Application.CompanyName, Application.ProductName, Name)
    End Sub

    Public Property SettingInt(Name As String, Optional [Default] As Long = 0) As Long
        Get
            Return Val(Setting(Name, [Default]))
        End Get
        Set(ByVal value As Long)
            Setting(Name) = value
        End Set
    End Property

    Public Property SettingIDs(Name As String) As String()
        Get
            'Return Array.ConvertAll(Setting(Name, "0").Split(";"), New Converter(Of String, Long)(Function(a) CLng(a)))
            Dim tmp As String = Setting(Name)
            If String.IsNullOrWhiteSpace(tmp) Then
                Return New String() {}
            Else
                Return tmp.Trim(";").Split(";")
            End If
        End Get
        Set(ByVal value As String())
            Setting(Name) = String.Join(";", value)
        End Set
    End Property

    Public Sub SettingAddID(Name As String, Id As String)
        If Not (";" & Setting(Name)).Replace(";", " ") Like "% " & Id & " %" Then
            Setting(Name) = Setting(Name).Trim(";") & ";" & Id
        End If
    End Sub

    Public Sub SettingRemoveID(Name As String, Id As String)
        Setting(Name) = (";" & Setting(Name) & ";").Replace(";" & Id & ";", "").Trim(";")
    End Sub

    Public Sub SetDefaultSettings()
        Dim Path As String = DefaultPath

        If Not IO.Directory.Exists(Path) Then
            If IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.MyPictures) Then
                Path = My.Computer.FileSystem.SpecialDirectories.MyPictures
            Else
                If IO.Directory.Exists(My.Computer.FileSystem.SpecialDirectories.MyDocuments) Then
                    Path = My.Computer.FileSystem.SpecialDirectories.MyDocuments
                Else
                    Path = ""
                End If
            End If
        End If

        DefaultPath = Path

        Dim CultureName As String = Setting("CultureCode")
        Dim Found As Boolean = False

        If Not String.IsNullOrEmpty(CultureName) Then
            For Each Culture As CultureInfo In CultureInfo.GetCultures(CultureTypes.AllCultures)
                If Culture.Name = CultureName Then
                    Found = True
                    Exit For
                End If
            Next
        End If

        If Not Found Then
            Setting("CultureCode") = CultureInfo.CurrentCulture.Name
        End If
    End Sub

    Public Property DefaultPath() As String
        Get
            Return Setting("DefaultPath")
        End Get
        Set(ByVal value As String)
            Setting("DefaultPath") = value
        End Set
    End Property

    Public ReadOnly Property FileTypes As String()
        Get
            Return New String() {"Png", "Bmp", "Emf", "Exif", "Gif", "Ico", "Jpg", "Tiff", "Wmf"}
        End Get
    End Property

    Public Property FileType As Integer
        Get
            Return SettingInt("FileType")
        End Get
        Set(value As Integer)
            SettingInt("FileType") = value
        End Set
    End Property

    Public ReadOnly Property FileTypeString As String
        Get
            Return FileTypes(FileType)
        End Get
    End Property

    Public Property ShareQuality As Integer
        Get
            Return SettingInt("ShareQuality")
        End Get
        Set(value As Integer)
            SettingInt("ShareQuality") = value
        End Set
    End Property

    Public Property CultureCode() As CultureInfo
        Get
            Return New CultureInfo(Setting("CultureCode")) 'CultureInfo.CurrentCulture
        End Get
        Set(ByVal value As CultureInfo)
            Setting("CultureCode") = value.Name
        End Set
    End Property

    Public Property CopyPath As Boolean
        Get
            Return SettingInt("CopyPath", 1)
        End Get
        Set(value As Boolean)
            SettingInt("CopyPath") = value
        End Set
    End Property

    Public Property OpenFolder As Boolean
        Get
            Return SettingInt("OpenFolder", 1)
        End Get
        Set(value As Boolean)
            SettingInt("OpenFolder") = value
        End Set
    End Property

    Public Property SettingHistory() As String()
        Get
            Return SettingIDs("History")
        End Get
        Set(ByVal value As String())
            SettingIDs("History") = value
        End Set
    End Property

    Public Property SettingHistoryTitle(Id As String) As String
        Get
            Return Setting("History_Title_" & Id)
        End Get
        Set(value As String)
            If String.IsNullOrWhiteSpace(value) Then

                RemoveSetting("History_Title_" & Id)
            Else
                Setting("History_Title_" & Id) = value
            End If
        End Set
    End Property

    Public Sub SettingHistoryAdd(Id As String, Title As String)
        SettingAddID("History", Id)
        SettingHistoryTitle(Id) = Title
    End Sub

    Public Sub SettingHistoryRemove(Id As String)
        SettingRemoveID("History", Id)
        SettingHistoryTitle(Id) = Nothing
    End Sub
End Module
