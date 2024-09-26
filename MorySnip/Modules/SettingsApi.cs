using System;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Morysoft.MorySnip.Modules;

public static class SettingsApi
{
    public static string GetSetting(string name, string defaultValue = "") => Interaction.GetSetting(Application.CompanyName, Application.ProductName, name, defaultValue) ?? defaultValue;

    public static string[] GetSettingIDs(string name)
    {
        // Return Array.ConvertAll(Setting(Name, "0").Split(";"), New Converter(Of String, Long)(Function(a) CLng(a)))
        var tmp = GetSetting(name);

        return String.IsNullOrWhiteSpace(tmp)
            ? Array.Empty<string>()
            : tmp.Trim(';').Split(';');
    }

    public static long GetSettingInt(string name, long defaultValue = 0) => (long)Conversion.Val(GetSetting(name, Conversions.ToString(defaultValue)));

    public static bool GetSettingBool(string name, bool defaultValue = false) => GetSettingInt(name, defaultValue ? 1 : 0) != 0;

    public static void SetSettingBool(string name, bool value) => SetSettingInt(name, value ? 1 : 0);

    public static void RemoveSetting(string name)
    {
        if (!String.IsNullOrWhiteSpace(GetSetting(name)))
        {
            Interaction.DeleteSetting(Application.CompanyName, Application.ProductName, name);
        }
    }

    public static void SetSetting(string name, string value) => Interaction.SaveSetting(Application.CompanyName, Application.ProductName, name, value);

    public static void SetSettingIDs(string Name, string[] value) => SetSetting(Name, String.Join(";", value));

    public static void SetSettingInt(string name, long value) => SetSetting(name, value.ToString());

    public static void SettingAddID(string Name, string Id)
    {
        if (!LikeOperator.LikeString((";" + GetSetting(Name)).Replace(";", " "), "% " + Id + " %", CompareMethod.Binary))
        {
            SetSetting(Name, $"{GetSetting(Name).Trim(';')};{Id}");
        }
    }

    public static void SettingRemoveID(string Name, string Id) => SetSetting(Name, (";" + GetSetting(Name) + ";").Replace(";" + Id + ";", "").Trim(';'));
}
