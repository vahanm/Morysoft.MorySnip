using System.Globalization;
using System.IO;

namespace Morysoft.MorySnip.Modules;

public static class Settings
{
    public static void SetDefaultSettings()
    {
        var path = DefaultPath;

        if (!Directory.Exists(path))
        {
            if (Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)))
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            }
            else if (Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)))
            {
                path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            }
            else
            {
                path = "";
            }
        }

        DefaultPath = path;

        var cultureName = SettingsApi.GetSetting("CultureCode");
        var found = false;

        if (!String.IsNullOrEmpty(cultureName))
        {
            foreach (var Culture in CultureInfo.GetCultures(CultureTypes.AllCultures))
            {
                if ((Culture.Name ?? "") == (cultureName ?? ""))
                {
                    found = true;
                    break;
                }
            }
        }

        if (!found)
        {
            SettingsApi.SetSetting("CultureCode", CultureInfo.CurrentCulture.Name);
        }
    }

    public static string DefaultPath
    {
        get => SettingsApi.GetSetting(nameof(DefaultPath));
        set => SettingsApi.SetSetting(nameof(DefaultPath), value);
    }

    public static string[] FileTypes => new string[] { "Png", "Bmp", "Emf", "Exif", "Gif", "Ico", "Jpg", "Tiff", "Wmf" };

    public static int FileType
    {
        get => (int)SettingsApi.GetSettingInt(nameof(FileType));
        set => SettingsApi.SetSettingInt(nameof(FileType), value);
    }

    public static string FileTypeString => FileTypes[FileType];

    public static CultureInfo CultureCode
    {
        get => new(SettingsApi.GetSetting("CultureCode")); // CultureInfo.CurrentCulture
        set => SettingsApi.SetSetting("CultureCode", value.Name);
    }

    public static bool CopyPath
    {
        get => SettingsApi.GetSettingBool(nameof(CopyPath), true);
        set => SettingsApi.SetSettingBool(nameof(CopyPath), value);
    }

    public static bool OpenFolder
    {
        get => SettingsApi.GetSettingBool(nameof(OpenFolder), true);
        set => SettingsApi.SetSettingBool(nameof(OpenFolder), value);
    }

    public static bool QuickShotToFile
    {
        get => SettingsApi.GetSettingBool(nameof(QuickShotToFile), true);
        set => SettingsApi.SetSettingBool(nameof(QuickShotToFile), value);
    }

    public static string[] SettingHistory
    {
        get => SettingsApi.GetSettingIDs("History");
        set => SettingsApi.SetSettingIDs("History", value);
    }

    public static string GetSettingHistoryTitle(string Id) => SettingsApi.GetSetting("History_Title_" + Id);

    public static void SetSettingHistoryTitle(string Id, string? value)
    {
        if (String.IsNullOrWhiteSpace(value))
        {
            SettingsApi.RemoveSetting("History_Title_" + Id);
        }
        else
        {
            SettingsApi.SetSetting("History_Title_" + Id, value);
        }
    }

    public static void SettingHistoryAdd(string Id, string Title)
    {
        SettingsApi.SettingAddID("History", Id);
        SetSettingHistoryTitle(Id, Title);
    }

    public static void SettingHistoryRemove(string Id)
    {
        SettingsApi.SettingRemoveID("History", Id);
        SetSettingHistoryTitle(Id, null);
    }
}
