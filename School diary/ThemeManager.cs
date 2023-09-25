using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace School_diary
{
    public static class ThemeManager
    {
        private static string[] _colorKeys, _textKeys;

        private static Theme _current;

        private static Dictionary<string, Theme> _themes = new Dictionary<string, Theme>();

        public static void Load()
        {
            LoadKeys();

            string[] themeFiles = Directory.GetFiles("Themes");

            foreach (var fileName in themeFiles)
            {
                string name = fileName.Remove(fileName.Length - 12).Remove(0, 7);
                Theme theme = Theme.Parse(File.ReadAllLines(fileName), name);
                _themes.Add(name, theme);
            }

            _current = _themes[Properties.Settings.Default.Theme];
        }

        private static void LoadKeys()
        {
            string[] defaultThemeFile = File.ReadAllLines("Themes/Default.diary-theme", Encoding.UTF8);

            string[] defaultColors = defaultThemeFile.Skip(1).TakeWhile(x => x != "Texts").ToArray();
            string[] defaultTexts = defaultThemeFile.Skip(defaultColors.Length + 1).ToArray();

            _colorKeys = new string[defaultColors.Length];
            _textKeys = new string[defaultTexts.Length];

            for (int i = 0; i < defaultColors.Length; i++)
                _colorKeys[i] = defaultColors[i].Split(':')[0];

            for (int i = 0; i < defaultTexts.Length; i++)
                _textKeys[i] = defaultTexts[i].Split(':')[0];
        }

        public static bool ContainsColorKey(string key)
        { 
            return _colorKeys.Contains(key);
        }

        public static bool ContainsTextKey(string key)
        {
            return _textKeys.Contains(key);
        }

        public static Color MenuButtonsActiveFg => _current.GetColor("MenuButtonsActiveFg");
        public static Color MenuButtonsPassiveFg => _current.GetColor("MenuButtonsPassiveFg");
        public static Color MenuButtonsActiveBg => _current.GetColor("MenuButtonsActiveBg");
        public static Color MenuButtonsPassiveBg => _current.GetColor("MenuButtonsPassiveBg");
        public static Color WindowBg => _current.GetColor("WindowBg");
        public static Color WindowBgOver => _current.GetColor("WindowBgOver");
        public static Color WindowShadows => _current.GetColor("WindowShadows");
        public static Color ControlBoxButtonsFg => _current.GetColor("ControlBoxButtonsFg");
        public static Color EvenLessonNumLabelBg => _current.GetColor("EvenLessonNumLabelBg");
        public static Color OddLessonNumLabelBg => _current.GetColor("OddLessonNumLabelBg");
        public static Color DisabledEvenLessonNumLabelFg => _current.GetColor("DisabledEvenLessonNumLabelFg");
        public static Color DisabledOddLessonNumLabelFg => _current.GetColor("DisabledOddLessonNumLabelFg");
        public static Color LessonNumLabelFg => _current.GetColor("LessonNumLabelFg");

    }

    [Serializable]
    public struct Theme
    {
        public string Name { get; private set; }
        private Dictionary<string, Color> _colors;
        private Dictionary<string, string> _texts;

        public Theme(string name, Dictionary<string, Color> colors, Dictionary<string, string> texts)
        {
            Name = name;
            _colors = colors;
            _texts = texts;
        }

        public Color GetColor(string key)
        {
            if (!ThemeManager.ContainsColorKey(key))
                throw new WrongThemeKeyException(key);

            return _colors[key];
        }

        public string GetText(string key)
        {
            if (!ThemeManager.ContainsTextKey(key))
                throw new WrongThemeKeyException(key);

            return _texts[key];
        }

        public void SetColor(string key, Color color)
        {
            if (!ThemeManager.ContainsColorKey(key))
                throw new WrongThemeKeyException(key);

            _colors[key] = color;
        }

        public void SetText(string key, string text)
        {
            if (!ThemeManager.ContainsTextKey(key))
                throw new WrongThemeKeyException(key);

            _texts[key] = text;
        }

        public static Theme Parse(string[] str, string name)
        {
            string[] strColors = str.Skip(1).TakeWhile(x => x != "Texts--").ToArray();
            string[] strTexts = str.Skip(strColors.Length + 2).ToArray();

            Dictionary<string, Color> colors = new Dictionary<string, Color>();
            Dictionary<string, string> texts = new Dictionary<string, string>();

            foreach (string strColor in strColors)
            {
                string[] color = strColor.Split(':');
                colors.Add(color[0], ColorTranslator.FromHtml(color[1]));
            }

            foreach (string strText in strTexts)
            {
                string[] text = strText.Split(':');
                texts.Add(text[0], text[1]);
            }

            return new Theme(name, colors, texts);
        }
    }

    public class WrongThemeKeyException : Exception
    {
        public override string Message => "Wrong theme key " + _key;

        private string _key;
        public WrongThemeKeyException(string key)
        {
            _key = key;
        }
    }
}
