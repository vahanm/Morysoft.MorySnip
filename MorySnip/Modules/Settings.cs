using System;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Morysoft.MorySnip
{
    public static class Settings
    {
        public static string get_Setting(string Name, string Default = "") => Interaction.GetSetting(Application.CompanyName, Application.ProductName, Name, Default);

        public static void set_Setting(string Name, string value, string Default = "") => Interaction.SaveSetting(Application.CompanyName, Application.ProductName, Name, value);

        public static void RemoveSetting(string Name)
        {
            if (!String.IsNullOrWhiteSpace(get_Setting(Name)))
            {
                Interaction.DeleteSetting(Application.CompanyName, Application.ProductName, Name);
            }
        }

        public static long get_SettingInt(string Name, long Default = 0) => (long)Conversion.Val(get_Setting(Name, Conversions.ToString(Default)));

        public static void set_SettingInt(string Name, long value, long Default = 0) => set_Setting(Name, value.ToString());

        public static string[] get_SettingIDs(string Name)
        {
            // Return Array.ConvertAll(Setting(Name, "0").Split(";"), New Converter(Of String, Long)(Function(a) CLng(a)))
            string tmp = get_Setting(Name);
            if (String.IsNullOrWhiteSpace(tmp))
            {
                return new string[] { };
            }
            else
            {
                return tmp.Trim(';').Split(';');
            }
        }

        public static void set_SettingIDs(string Name, string[] value) => set_Setting(Name, String.Join(";", value));

        public static void SettingAddID(string Name, string Id)
        {
            if (!LikeOperator.LikeString((";" + get_Setting(Name)).Replace(";", " "), "% " + Id + " %", CompareMethod.Binary))
            {
                set_Setting(Name, get_Setting(Name).Trim(';') + ";" + Id);
            }
        }

        public static void SettingRemoveID(string Name, string Id) => set_Setting(Name, (";" + get_Setting(Name) + ";").Replace(";" + Id + ";", "").Trim(';'));

        public static void SetDefaultSettings()
        {
            string path = DefaultPath;

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

            string CultureName = get_Setting("CultureCode");
            bool Found = false;

            if (!String.IsNullOrEmpty(CultureName))
            {
                foreach (var Culture in CultureInfo.GetCultures(CultureTypes.AllCultures))
                {
                    if ((Culture.Name ?? "") == (CultureName ?? ""))
                    {
                        Found = true;
                        break;
                    }
                }
            }

            if (!Found)
            {
                set_Setting("CultureCode", CultureInfo.CurrentCulture.Name);
            }
        }

        public static string DefaultPath
        {
            get => get_Setting("DefaultPath");
            set => set_Setting("DefaultPath", value);
        }

        public static string[] FileTypes => new string[] { "Png", "Bmp", "Emf", "Exif", "Gif", "Ico", "Jpg", "Tiff", "Wmf" };

        public static int FileType
        {
            get => (int)get_SettingInt(nameof(FileType));
            set => set_SettingInt(nameof(FileType), value);
        }

        public static string FileTypeString => FileTypes[FileType];

        public static int ShareQuality
        {
            get => (int)get_SettingInt("ShareQuality");
            set => set_SettingInt("ShareQuality", value);
        }

        public static CultureInfo CultureCode
        {
            get => new CultureInfo(get_Setting("CultureCode")); // CultureInfo.CurrentCulture
            set => set_Setting("CultureCode", value.Name);
        }

        public static bool CopyPath
        {
            get => get_SettingInt(nameof(CopyPath), 1) != 0;
            set => set_SettingInt(nameof(CopyPath), value ? 1 : 0);
        }

        public static bool OpenFolder
        {
            get => get_SettingInt(nameof(OpenFolder), 1) != 0;
            set => set_SettingInt(nameof(OpenFolder), value ? 1 : 0);
        }

        public static string[] SettingHistory
        {
            get => get_SettingIDs("History");
            set => set_SettingIDs("History", value);
        }

        public static string get_SettingHistoryTitle(string Id) => get_Setting("History_Title_" + Id);

        public static void set_SettingHistoryTitle(string Id, string value)
        {
            if (String.IsNullOrWhiteSpace(value))
            {
                RemoveSetting("History_Title_" + Id);
            }
            else
            {
                set_Setting("History_Title_" + Id, value);
            }
        }

        public static void SettingHistoryAdd(string Id, string Title)
        {
            SettingAddID("History", Id);
            set_SettingHistoryTitle(Id, Title);
        }

        public static void SettingHistoryRemove(string Id)
        {
            SettingRemoveID("History", Id);
            set_SettingHistoryTitle(Id, null);
        }
    }
}
