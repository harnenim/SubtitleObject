using System.Drawing;
using System.Net;
using System.Collections.Generic;

namespace Subtitle
{
    public enum SyncType
    {
        normal,
        frame,
        inner,
    }
    public class SyncAttr
    {
        public int start = 0;
        public int end = int.MaxValue;
        public SyncType startType = SyncType.normal;
        public SyncType endType = SyncType.normal;
        public List<Attr> text;
    }
    public interface ISubtitleObject<SObj>
    {
        string ToTxt();
        string ColorToAttr(string soColor);
        string ColorFromAttr(string attrColor);

        List<Attr> ToAttr();
        SObj FromAttr(List<Attr> attrs);

        SyncAttr ToSync();
        SObj FromSync(SyncAttr sync);
    }
    public interface ISubtitleFile<SObj, FObj>
    {
        string ToTxt();
        FObj FromTxt(string txt);

        List<SyncAttr> ToSync();
        FObj FromSync(List<SyncAttr> sync);
    }

    public class Width
    {
        public static Font DEFAULT_FONT = new Font("맑은 고딕", 72.0F);
        public static Image FAKE_IMAGE = new Bitmap(1, 1);

        public static float GetWidth(string input)
        {
            return GetWidth(input, DEFAULT_FONT);
        }
        public static float GetWidth(string input, Font font)
        {
            Graphics graphics = Graphics.FromImage(FAKE_IMAGE);
            SizeF size0 = graphics.MeasureString("​", font);
            SizeF size = graphics.MeasureString(input + "​", font);
            return size.Width - size0.Width;
        }
        public static float GetWidth(List<Attr> line)
        {
            float width = 0;
            foreach (Attr attr in line)
                width += attr.GetWidth();
            return width;
        }
        public static float[] GetWidths(List<List<Attr>> lines)
        {
            List<float> widths = new List<float>();
            foreach (List<Attr> line in lines)
            {
                widths.Add(GetWidth(line));
            }
            return widths.ToArray();
        }

        public static string GetAppend(float width, float targetWidth)
        {
            return GetAppend(targetWidth - width, false, DEFAULT_FONT);
        }
        public static string GetAppend(float width, float targetWidth, bool isBoth)
        {
            return GetAppend(targetWidth - width, isBoth, DEFAULT_FONT);
        }
        public static string GetAppend(float width, float targetWidth, Font font)
        {
            return GetAppend(targetWidth - width, false, font);
        }
        public static string GetAppend(float targetWidth)
        {
            return GetAppend(targetWidth, false, DEFAULT_FONT);
        }
        public static string GetAppend(float targetWidth, bool isBoth)
        {
            return GetAppend(targetWidth, isBoth, DEFAULT_FONT);
        }
        public static string GetAppend(float targetWidth, Font font)
        {
            return GetAppend(targetWidth, false, font);
        }
        public static string GetAppend(float targetWidth, bool isBoth, Font font)
        {
            if (isBoth) targetWidth /= 2;

            string whiteSpace = "";
            float lastWidth = 0, thisWidth = 0;
            if (thisWidth >= targetWidth) return whiteSpace;

            while (thisWidth < targetWidth)
            {
                lastWidth = thisWidth;
                whiteSpace += "　";
                thisWidth = GetWidth(whiteSpace);
            }

            thisWidth = lastWidth;
            whiteSpace = whiteSpace.Substring(0, whiteSpace.Length - 1);

            while (thisWidth < targetWidth)
            {
                lastWidth = thisWidth;
                whiteSpace += " ";
                thisWidth = GetWidth(whiteSpace);
            }

            if (thisWidth - targetWidth > targetWidth - lastWidth)
                whiteSpace = whiteSpace.Substring(0, whiteSpace.Length - 1);

            return isBoth ? whiteSpace : AppendToRight(whiteSpace);
        }

        public static string AppendToRight(string append)
        {
            int index = append.IndexOf(' ');
            if (index > 0)
                return append.Substring(index) + append.Substring(0, index);
            return append;
        }
    }

    public class Attr
    {
        public string text = "";
        public bool b = false; // Bold
        public bool i = false; // Italic
        public bool u = false; // Underline
        public int fs = 0;     // FontSize
        public string fn = ""; // FontName
        public string fc = ""; // Fontcolor
        public int fade = 0;
        public TypingAttr typing = null;
        public class TypingAttr
        {
            public Typing.Mode mode = Typing.Mode.keyboard;
            public Typing.Cursor cursor = Typing.Cursor.visible;
            public int start = 0;
            public int end = 0;
            public TypingAttr(Typing.Mode mode)
            {
                this.mode = mode;
            }
            public TypingAttr(Typing.Mode mode, int start, int end)
            {
                this.mode = mode;
                this.start = start;
                this.end = end;
            }
        }

        public Attr() { }
        public Attr(Attr old)
        {
            text = "";
            b = old.b;
            i = old.i;
            u = old.u;
            fs = old.fs;
            fn = old.fn;
            fc = old.fc;
            fade = old.fade;
            typing = old.typing;
        }

        public float GetWidth() { return Width.GetWidth(text, new Font((fn.Length > 0 ? fn : Width.DEFAULT_FONT.Name), (fs > 0 ? fs : Width.DEFAULT_FONT.Size))); }
        public static float[] GetWidths(List<Attr> attrs)
        {
            List<float> widths = new List<float>();
            float width = 0;
            int index = 0;
            foreach (Attr attr in attrs)
            {
                if ((index = attr.text.IndexOf('\n')) >= 0)
                {
                    width += new Attr(attr) { text = attr.text.Substring(0, index) }.GetWidth();
                    widths.Add(width);
                    width += new Attr(attr) { text = attr.text.Substring(index) }.GetWidth();
                }
                else
                {
                    width += attr.GetWidth();
                }
            }
            widths.Add(width);
            return widths.ToArray();
        }

        public static List<Attr> FromSubtitle<T>(ISubtitleObject<T> subtitle)
        {
            return subtitle.ToAttr();
        }
        public static List<List<Attr>> LinesFromSubtitle<T>(ISubtitleObject<T> subtitle)
        {
            List<Attr> attrs = FromSubtitle(subtitle);

            List<List<Attr>> lines = new List<List<Attr>>();
            List<Attr> line = new List<Attr>();
            int index = 0;
            lines.Add(line);
            foreach (Attr attr in attrs)
            {
                if ((index = attr.text.IndexOf('\n')) >= 0)
                {
                    line.Add(new Attr(attr) { text = attr.text.Substring(0, index) });
                    lines.Add(line = new List<Attr>());
                    line.Add(new Attr(attr) { text = attr.text.Substring(index) });
                }
                else
                {
                    line.Add(attr);
                }
            }
            return lines;
        }
        public static void ToSubtitle<T>(List<Attr> attrs, ISubtitleObject<T> subtitle)
        {
            subtitle.FromAttr(attrs);
        }

        public string ToHtml()
        {
            if (text == null | text.Length == 0)
                return "";

            string css = "";
            if (b) css += "font-weight: bold;";
            if (i) css += "font-style: italic;";
            if (u) css += "font-decoration: underline;";
            if (fs > 0) css += "font-size: " + fs + "px; line-height: " + (11 + 4 * fs) + "px;";
            if (fn != null && fn.Length > 0) css += "font-family: '" + fn + "';";
            if (fc != null && fc.Length > 0) css += "color: #" + fc + ";";
            return "<span" + (css.Length > 0 ? " style=\"" + css + "\"" : "") + ">"
                + WebUtility.HtmlEncode(text).Replace(" ", "&nbsp;").Replace("\n", "​<br>​")
                + "</span>";
        }
        public static string ToHtml(List<Attr> attrs)
        {
            string result = "";
            foreach (Attr attr in attrs)
                result += attr.ToHtml();
            return result;
        }
    }
}
