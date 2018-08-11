using System.Collections.Generic;

namespace Subtitle
{
    public class Johap
    {
        private static char[] cho_ = "ᄀᄁᄂᄃᄄᄅᄆᄇᄈᄉᄊᄋᄌᄍᄎᄏᄐᄑᄒ".ToCharArray();
        private static char[] jung = "ᅡᅢᅣᅤᅥᅦᅧᅨᅩᅪᅫᅬᅭᅮᅯᅰᅱᅲᅳᅴᅵ".ToCharArray();
        private static char[] jong = "　ᆨᆩᆪᆫᆬᆭᆮᆯᆰᆱᆲᆳᆴᆵᆶᆷᆸᆹᆺᆻᆼᆽᆾᆿᇀᇁᇂ".ToCharArray();

        public static char[] ToJohap(string origin)
        {
            List<char> result = new List<char>();

            foreach (char c in origin)
            {
                if (c >= '가' && c <= '힣')
                {
                    int cCho_ = ((c - '가') / 588);
                    int cJung = ((c - '가') / 28) % 21;
                    int cJong = ((c - '가') % 28);

                    if (cJong > 0)
                    {
                        result.Add(cho_[cCho_]);
                        result.Add(jung[cJung]);
                        result.Add(jong[cJong]);
                    }
                    else
                    {
                        result.Add(cho_[cCho_]);
                        result.Add(jung[cJung]);
                    }
                }
                else
                    result.Add(c);
            }

            return result.ToArray();
        }
    }

    public class Typing
    {
        public enum Mode
        {
            typewriter,
            keyboard,
        }
        public enum Cursor
        {
            invisible,
            visible,
            hangeul,
        }
        public static char[] ToType(string origin, Mode mode)
        {
            return ToType(Johap.ToJohap(origin), mode);
        }
        public static char[] ToType(char[] johap, Mode mode)
        {
            char[] result = null;
            switch (mode)
            {
                case Mode.typewriter:
                    result = ToTypeTypewriter(johap);
                    break;
                case Mode.keyboard:
                    result = ToTypeKeyboard(johap);
                    break;
            }
            return result;
        }
        private static char[] ToTypeTypewriter(char[] johap)
        {
            List<char> result = new List<char>();
            foreach (char c in johap)
            {
                switch (c)
                {
                    case 'ᅪ': result.Add('ᅩ'); result.Add('ᅡ'); break;
                    case 'ᅫ': result.Add('ᅩ'); result.Add('ᅢ'); break;
                    case 'ᅬ': result.Add('ᅩ'); result.Add('ᅵ'); break;
                    case 'ᅯ': result.Add('ᅮ'); result.Add('ᅥ'); break;
                    case 'ᅰ': result.Add('ᅮ'); result.Add('ᅦ'); break;
                    case 'ᅱ': result.Add('ᅮ'); result.Add('ᅵ'); break;
                    case 'ᅴ': result.Add('ᅳ'); result.Add('ᅵ'); break;
                    default: result.Add(c); break;
                }
            }
            return result.ToArray();
        }
        private static char[] ToTypeKeyboard(char[] johap)
        {
            List<char> result = new List<char>();
            foreach (char c in johap)
            {
                switch (c)
                {
                    case 'ᄀ': result.Add('ㄱ'); break;
                    case 'ᄁ': result.Add('ㄲ'); break;
                    case 'ᄂ': result.Add('ㄴ'); break;
                    case 'ᄃ': result.Add('ㄷ'); break;
                    case 'ᄄ': result.Add('ㄸ'); break;
                    case 'ᄅ': result.Add('ㄹ'); break;
                    case 'ᄆ': result.Add('ㅁ'); break;
                    case 'ᄇ': result.Add('ㅂ'); break;
                    case 'ᄈ': result.Add('ㅃ'); break;
                    case 'ᄉ': result.Add('ㅅ'); break;
                    case 'ᄊ': result.Add('ㅆ'); break;
                    case 'ᄋ': result.Add('ㅇ'); break;
                    case 'ᄌ': result.Add('ㅈ'); break;
                    case 'ᄍ': result.Add('ㅉ'); break;
                    case 'ᄎ': result.Add('ㅊ'); break;
                    case 'ᄏ': result.Add('ㅋ'); break;
                    case 'ᄐ': result.Add('ㅌ'); break;
                    case 'ᄑ': result.Add('ㅍ'); break;
                    case 'ᄒ': result.Add('ㅎ'); break;
                    case 'ᅡ': result.Add('ㅏ'); break;
                    case 'ᅢ': result.Add('ㅐ'); break;
                    case 'ᅣ': result.Add('ㅑ'); break;
                    case 'ᅤ': result.Add('ㅒ'); break;
                    case 'ᅥ': result.Add('ㅓ'); break;
                    case 'ᅦ': result.Add('ㅔ'); break;
                    case 'ᅧ': result.Add('ㅕ'); break;
                    case 'ᅨ': result.Add('ㅖ'); break;
                    case 'ᅩ': result.Add('ㅗ'); break;
                    case 'ᅪ': result.Add('ㅗ'); result.Add('ㅏ'); break;
                    case 'ᅫ': result.Add('ㅗ'); result.Add('ㅐ'); break;
                    case 'ᅬ': result.Add('ㅗ'); result.Add('ㅣ'); break;
                    case 'ᅭ': result.Add('ㅛ'); break;
                    case 'ᅮ': result.Add('ㅜ'); break;
                    case 'ᅯ': result.Add('ㅜ'); result.Add('ㅓ'); break;
                    case 'ᅰ': result.Add('ㅜ'); result.Add('ㅔ'); break;
                    case 'ᅱ': result.Add('ㅜ'); result.Add('ㅣ'); break;
                    case 'ᅲ': result.Add('ㅠ'); break;
                    case 'ᅳ': result.Add('ㅡ'); break;
                    case 'ᅴ': result.Add('ㅡ'); result.Add('ㅣ'); break;
                    case 'ᅵ': result.Add('ㅣ'); break;
                    case 'ᆨ': result.Add('ㄱ'); break;
                    case 'ᆩ': result.Add('ㄲ'); break;
                    case 'ᆪ': result.Add('ㄱ'); result.Add('ㅅ'); break;
                    case 'ᆫ': result.Add('ㄴ'); break;
                    case 'ᆬ': result.Add('ㄴ'); result.Add('ㅈ'); break;
                    case 'ᆭ': result.Add('ㄴ'); result.Add('ㅎ'); break;
                    case 'ᆮ': result.Add('ㄷ'); break;
                    case 'ᆯ': result.Add('ㄹ'); break;
                    case 'ᆰ': result.Add('ㄹ'); result.Add('ㄱ'); break;
                    case 'ᆱ': result.Add('ㄹ'); result.Add('ㅁ'); break;
                    case 'ᆲ': result.Add('ㄹ'); result.Add('ㅂ'); break;
                    case 'ᆳ': result.Add('ㄹ'); result.Add('ㅅ'); break;
                    case 'ᆴ': result.Add('ㄹ'); result.Add('ㅌ'); break;
                    case 'ᆵ': result.Add('ㄹ'); result.Add('ㅍ'); break;
                    case 'ᆶ': result.Add('ㄹ'); result.Add('ㅎ'); break;
                    case 'ᆷ': result.Add('ㅁ'); break;
                    case 'ᆸ': result.Add('ㅂ'); break;
                    case 'ᆹ': result.Add('ㅂ'); result.Add('ㅅ'); break;
                    case 'ᆺ': result.Add('ㅅ'); break;
                    case 'ᆻ': result.Add('ㅆ'); break;
                    case 'ᆼ': result.Add('ㅇ'); break;
                    case 'ᆽ': result.Add('ㅈ'); break;
                    case 'ᆾ': result.Add('ㅊ'); break;
                    case 'ᆿ': result.Add('ㅋ'); break;
                    case 'ᇀ': result.Add('ㅌ'); break;
                    case 'ᇁ': result.Add('ㅍ'); break;
                    case 'ᇂ': result.Add('ㅎ'); break;
                    case 'ㄳ': result.Add('ㄱ'); result.Add('ㅅ'); break;
                    case 'ㄵ': result.Add('ㄴ'); result.Add('ㅈ'); break;
                    case 'ㄶ': result.Add('ㄴ'); result.Add('ㅎ'); break;
                    case 'ㄺ': result.Add('ㄹ'); result.Add('ㄱ'); break;
                    case 'ㄻ': result.Add('ㄹ'); result.Add('ㅁ'); break;
                    case 'ㄼ': result.Add('ㄹ'); result.Add('ㅂ'); break;
                    case 'ㄽ': result.Add('ㄹ'); result.Add('ㅅ'); break;
                    case 'ㄿ': result.Add('ㄹ'); result.Add('ㅍ'); break;
                    case 'ㄾ': result.Add('ㄹ'); result.Add('ㅌ'); break;
                    case 'ㅀ': result.Add('ㄹ'); result.Add('ㅎ'); break;
                    case 'ㅄ': result.Add('ㅂ'); result.Add('ㅅ'); break;
                    default: result.Add(c); break;
                }
            }
            return result.ToArray();
        }

        public static List<string> ToType(string origin, Mode mode, Cursor cursor)
        {
            List<string> result = new List<string>();
            char[] type = Johap.ToJohap(origin);
            if (mode == Mode.keyboard) type = ToType(type, mode);

            Typing typing = new Typing(mode, cursor);
            result.Add(typing.Out());
            foreach (char c in type)
            {
                typing.Type(c);
                result.Add(typing.Out());
            }
            return result;
        }

        private static char[] cho = "ㄱㄲㄴㄷㄸㄹㅁㅂㅃㅅㅆㅇㅈㅉㅊㅋㅌㅍㅎ".ToCharArray();
        private static int NCho(char c)
        {
            switch (c)
            {
                case 'ㄱ': return 0;
                case 'ㄲ': return 1;
                case 'ㄴ': return 2;
                case 'ㄷ': return 3;
                case 'ㄸ': return 4;
                case 'ㄹ': return 5;
                case 'ㅁ': return 6;
                case 'ㅂ': return 7;
                case 'ㅃ': return 8;
                case 'ㅅ': return 9;
                case 'ㅆ': return 10;
                case 'ㅇ': return 11;
                case 'ㅈ': return 12;
                case 'ㅉ': return 13;
                case 'ㅊ': return 14;
                case 'ㅋ': return 15;
                case 'ㅌ': return 16;
                case 'ㅍ': return 17;
                case 'ㅎ': return 18;
            }
            return 0;
        }
        private static int NJong(char c)
        {
            switch (c)
            {
                //		case '　' : return 0;
                case 'ㄱ': return 1;
                case 'ㄲ': return 2;
                case 'ㄳ': return 3;
                case 'ㄴ': return 4;
                case 'ㄵ': return 5;
                case 'ㄶ': return 6;
                case 'ㄷ': return 7;
                case 'ㄹ': return 8;
                case 'ㄺ': return 9;
                case 'ㄻ': return 10;
                case 'ㄼ': return 11;
                case 'ㄽ': return 12;
                case 'ㄾ': return 13;
                case 'ㄿ': return 14;
                case 'ㅀ': return 15;
                case 'ㅁ': return 16;
                case 'ㅂ': return 17;
                case 'ㅄ': return 18;
                case 'ㅅ': return 19;
                case 'ㅆ': return 20;
                case 'ㅇ': return 21;
                case 'ㅈ': return 22;
                case 'ㅊ': return 23;
                case 'ㅋ': return 24;
                case 'ㅌ': return 25;
                case 'ㅍ': return 26;
                case 'ㅎ': return 27;
            }
            return 0;
        }
        public delegate void TypeFunc(char c);
        private void TypeTypewriter(char c)
        {
            if (c >= 'ᄀ' && c <= 'ᄒ')
            {
                // 초성
                if (typing != ' ') typed += typing;
                typing = c;
            }
            else if (c >= 'ᅡ' && c <= 'ᅵ')
            {
                // 중성
                if (typing >= 'ᄀ' && typing <= 'ᄒ')
                {
                    typing = (char)('가' + ((typing - 'ᄀ') * 588) + ((c - 'ᅡ') * 28));
                    return;
                }

                // 이중중성
                if (typing >= '고' && typing <= '흐')
                {
                    switch (((typing - '가') / 28) % 21)
                    {
                        case ('고' - '가') / 28:
                            if (c == 'ᅡ') { typing = (char)(typing + 28 * 1); return; }
                            if (c == 'ᅢ') { typing = (char)(typing + 28 * 2); return; }
                            if (c == 'ᅵ') { typing = (char)(typing + 28 * 3); return; }
                            break;
                        case ('구' - '가') / 28:
                            if (c == 'ᅥ') { typing = (char)(typing + 28 * 1); return; }
                            if (c == 'ᅦ') { typing = (char)(typing + 28 * 2); return; }
                            if (c == 'ᅵ') { typing = (char)(typing + 28 * 3); return; }
                            break;
                        case ('그' - '가') / 28:
                            if (c == 'ᅵ') { typing = (char)(typing + 28 * 1); return; }
                            break;
                    }
                }

                // 이중모음
                switch (typing)
                {
                    case 'ᅩ':
                        if (c == 'ᅡ') { typing = 'ᅪ'; return; }
                        if (c == 'ᅢ') { typing = 'ᅫ'; return; }
                        if (c == 'ㅣ') { typing = 'ᅬ'; return; }
                        break;
                    case 'ᅮ':
                        if (c == 'ᅥ') { typing = 'ᅯ'; return; }
                        if (c == 'ᅦ') { typing = 'ᅰ'; return; }
                        if (c == 'ᅵ') { typing = 'ᅱ'; return; }
                        break;
                    case 'ᅳ':
                        if (c == 'ᅵ') { typing = 'ᅴ'; return; }
                        break;
                }

                if (typing != ' ') typed += typing;
                typing = c;
            }
            else if (c >= 'ᆨ' && c <= 'ᇂ')
            {
                // 종성
                if (typing >= '가' && typing <= '히' && (typing % 28 == '가' % 28))
                {
                    typing = (char)(typing + (c - 'ᆨ' + 1));
                }
                else
                {
                    typed += typing;
                    typed += c;
                    typing = ' ';
                }
            }
            else
            {
                if (typing != ' ') typed += typing;
                typed += c;
                typing = ' ';
            }
        }
        private void TypeKeyboard(char c)
        {
            if (c >= 'ㄱ' && c <= 'ㅎ')
            {
                if (typing >= '가' && typing <= '히')
                {
                    if (typing % 28 == '가' % 28)
                    {
                        // 종성
                        switch (c)
                        {
                            case 'ㄱ': typing = (char)(typing + ('각' - '가')); return;
                            case 'ㄲ': typing = (char)(typing + ('갂' - '가')); return;
                            case 'ㄴ': typing = (char)(typing + ('간' - '가')); return;
                            case 'ㄷ': typing = (char)(typing + ('갇' - '가')); return;
                            case 'ㄹ': typing = (char)(typing + ('갈' - '가')); return;
                            case 'ㅁ': typing = (char)(typing + ('감' - '가')); return;
                            case 'ㅂ': typing = (char)(typing + ('갑' - '가')); return;
                            case 'ㅅ': typing = (char)(typing + ('갓' - '가')); return;
                            case 'ㅆ': typing = (char)(typing + ('갔' - '가')); return;
                            case 'ㅇ': typing = (char)(typing + ('강' - '가')); return;
                            case 'ㅈ': typing = (char)(typing + ('갖' - '가')); return;
                            case 'ㅊ': typing = (char)(typing + ('갗' - '가')); return;
                            case 'ㅋ': typing = (char)(typing + ('갘' - '가')); return;
                            case 'ㅌ': typing = (char)(typing + ('같' - '가')); return;
                            case 'ㅍ': typing = (char)(typing + ('갚' - '가')); return;
                            case 'ㅎ': typing = (char)(typing + ('갛' - '가')); return;
                        }
                    }
                    else
                    {
                        // 이중종성
                        switch ((typing - '가') % 28)
                        {
                            case '각' - '가':
                                if (c == 'ㅅ') { typing = (char)(typing + 2); return; }
                                break;
                            case '간' - '가':
                                if (c == 'ㅈ') { typing = (char)(typing + 1); return; }
                                if (c == 'ㅎ') { typing = (char)(typing + 2); return; }
                                break;
                            case '갈' - '가':
                                if (c == 'ㄱ') { typing = (char)(typing + 1); return; }
                                if (c == 'ㅁ') { typing = (char)(typing + 2); return; }
                                if (c == 'ㅂ') { typing = (char)(typing + 3); return; }
                                if (c == 'ㅅ') { typing = (char)(typing + 4); return; }
                                if (c == 'ㅌ') { typing = (char)(typing + 5); return; }
                                if (c == 'ㅍ') { typing = (char)(typing + 6); return; }
                                if (c == 'ㅎ') { typing = (char)(typing + 7); return; }
                                break;
                        }
                    }
                }

                // 이중자음
                switch (typing)
                {
                    case 'ㄱ':
                        if (c == 'ㅅ') { typing = 'ㄳ'; return; }
                        break;
                    case 'ㄴ':
                        if (c == 'ㅈ') { typing = 'ㄵ'; return; }
                        if (c == 'ㅎ') { typing = 'ㄶ'; return; }
                        break;
                    case 'ㄹ':
                        if (c == 'ㄱ') { typing = 'ㄺ'; return; }
                        if (c == 'ㅁ') { typing = 'ㄻ'; return; }
                        if (c == 'ㅂ') { typing = 'ㄼ'; return; }
                        if (c == 'ㅅ') { typing = 'ㄽ'; return; }
                        if (c == 'ㅌ') { typing = 'ㄾ'; return; }
                        if (c == 'ㅍ') { typing = 'ㄿ'; return; }
                        if (c == 'ㅎ') { typing = 'ㅀ'; return; }
                        break;
                }

                // 자음
                if (typing != ' ') typed += typing;
                typing = c;
            }
            else if (c >= 'ㅏ' && c <= 'ㅣ')
            {
                // 중성
                if (typing >= 'ㄱ' && typing <= 'ㅎ')
                {
                    typing = (char)('가' + (NCho(typing) * 588) + ((c - 'ㅏ') * 28));
                    return;
                }

                if (typing >= '가' && typing <= '힣')
                {
                    // 이중중성
                    switch (((typing - '가') / 28) % 21)
                    {
                        case ('고' - '가') / 28:
                            if (c == 'ㅏ') { typing = (char)(typing + 28 * 1); return; }
                            if (c == 'ㅐ') { typing = (char)(typing + 28 * 2); return; }
                            if (c == 'ㅣ') { typing = (char)(typing + 28 * 3); return; }
                            break;
                        case ('구' - '가') / 28:
                            if (c == 'ㅓ') { typing = (char)(typing + 28 * 1); return; }
                            if (c == 'ㅔ') { typing = (char)(typing + 28 * 2); return; }
                            if (c == 'ㅣ') { typing = (char)(typing + 28 * 3); return; }
                            break;
                        case ('그' - '가') / 28:
                            if (c == 'ㅣ') { typing = (char)(typing + 28 * 1); return; }
                            break;
                    }

                    // 앞 글자 종성을 초성으로 가져오기
                    switch ((typing - '가') % 28)
                    {
                        case 00/*가-가*/: break;
                        case 01/*각-가*/: typed += (char)(typing - 01); typing = (char)('가' + NCho('ㄱ') * 588 + (c - 'ㅏ') * 28); return;
                        case 02/*갂-가*/: typed += (char)(typing - 02); typing = (char)('가' + NCho('ㄲ') * 588 + (c - 'ㅏ') * 28); return;
                        case 03/*갃-가*/: typed += (char)(typing - 02); typing = (char)('가' + NCho('ㅅ') * 588 + (c - 'ㅏ') * 28); return;
                        case 04/*간-가*/: typed += (char)(typing - 04); typing = (char)('가' + NCho('ㄴ') * 588 + (c - 'ㅏ') * 28); return;
                        case 05/*갅-가*/: typed += (char)(typing - 01); typing = (char)('가' + NCho('ㅈ') * 588 + (c - 'ㅏ') * 28); return;
                        case 06/*갆-가*/: typed += (char)(typing - 02); typing = (char)('가' + NCho('ㅎ') * 588 + (c - 'ㅏ') * 28); return;
                        case 07/*갇-가*/: typed += (char)(typing - 07); typing = (char)('가' + NCho('ㄷ') * 588 + (c - 'ㅏ') * 28); return;
                        case 08/*갈-가*/: typed += (char)(typing - 08); typing = (char)('가' + NCho('ㄹ') * 588 + (c - 'ㅏ') * 28); return;
                        case 09/*갉-가*/: typed += (char)(typing - 01); typing = (char)('가' + NCho('ㄱ') * 588 + (c - 'ㅏ') * 28); return;
                        case 10/*갊-가*/: typed += (char)(typing - 02); typing = (char)('가' + NCho('ㅁ') * 588 + (c - 'ㅏ') * 28); return;
                        case 11/*갋-가*/: typed += (char)(typing - 03); typing = (char)('가' + NCho('ㅂ') * 588 + (c - 'ㅏ') * 28); return;
                        case 12/*갌-가*/: typed += (char)(typing - 04); typing = (char)('가' + NCho('ㅅ') * 588 + (c - 'ㅏ') * 28); return;
                        case 13/*갍-가*/: typed += (char)(typing - 05); typing = (char)('가' + NCho('ㅌ') * 588 + (c - 'ㅏ') * 28); return;
                        case 14/*갎-가*/: typed += (char)(typing - 06); typing = (char)('가' + NCho('ㅍ') * 588 + (c - 'ㅏ') * 28); return;
                        case 15/*갏-가*/: typed += (char)(typing - 07); typing = (char)('가' + NCho('ㅎ') * 588 + (c - 'ㅏ') * 28); return;
                        case 16/*감-가*/: typed += (char)(typing - 16); typing = (char)('가' + NCho('ㅁ') * 588 + (c - 'ㅏ') * 28); return;
                        case 17/*갑-가*/: typed += (char)(typing - 17); typing = (char)('가' + NCho('ㅂ') * 588 + (c - 'ㅏ') * 28); return;
                        case 18/*값-가*/: typed += (char)(typing - 01); typing = (char)('가' + NCho('ㅅ') * 588 + (c - 'ㅏ') * 28); return;
                        case 19/*갓-가*/: typed += (char)(typing - 19); typing = (char)('가' + NCho('ㅅ') * 588 + (c - 'ㅏ') * 28); return;
                        case 20/*갔-가*/: typed += (char)(typing - 20); typing = (char)('가' + NCho('ㅆ') * 588 + (c - 'ㅏ') * 28); return;
                        case 21/*강-가*/: typed += (char)(typing - 21); typing = (char)('가' + NCho('ㅇ') * 588 + (c - 'ㅏ') * 28); return;
                        case 22/*갖-가*/: typed += (char)(typing - 22); typing = (char)('가' + NCho('ㅈ') * 588 + (c - 'ㅏ') * 28); return;
                        case 23/*갗-가*/: typed += (char)(typing - 23); typing = (char)('가' + NCho('ㅊ') * 588 + (c - 'ㅏ') * 28); return;
                        case 24/*갘-가*/: typed += (char)(typing - 24); typing = (char)('가' + NCho('ㅋ') * 588 + (c - 'ㅏ') * 28); return;
                        case 25/*같-가*/: typed += (char)(typing - 25); typing = (char)('가' + NCho('ㅌ') * 588 + (c - 'ㅏ') * 28); return;
                        case 26/*갚-가*/: typed += (char)(typing - 26); typing = (char)('가' + NCho('ㅍ') * 588 + (c - 'ㅏ') * 28); return;
                        case 27/*갛-가*/: typed += (char)(typing - 27); typing = (char)('가' + NCho('ㅎ') * 588 + (c - 'ㅏ') * 28); return;
                    }
                }

                // 이중모음
                switch (typing)
                {
                    case 'ㅗ':
                        if (c == 'ㅏ') { typing = 'ㅘ'; return; }
                        if (c == 'ㅐ') { typing = 'ㅙ'; return; }
                        if (c == 'ㅣ') { typing = 'ㅚ'; return; }
                        break;
                    case 'ㅜ':
                        if (c == 'ㅓ') { typing = 'ㅝ'; return; }
                        if (c == 'ㅔ') { typing = 'ㅞ'; return; }
                        if (c == 'ㅣ') { typing = 'ㅟ'; return; }
                        break;
                    case 'ㅡ':
                        if (c == 'ㅣ') { typing = 'ㅢ'; return; }
                        break;
                }

                // 모음
                if (typing != ' ') typed += typing;
                typing = c;
            }
            else
            {
                if (typing != ' ') typed += typing;
                typed += c;
                typing = ' ';
            }
        }

        public delegate string OutputFunc();
        private string OutputWithNoCursor()
        {
            if (typing == ' ') return typed;
            return typed + typing;
        }
        private string OutputWithCursor()
        {
            return typed + "<U>" + typing + "</U>";
        }
        private string OutputWithCursorOnlyHangeul()
        {
            if ((typing >= 'ㄱ' && typing <= 'ㅎ')
             || (typing >= 'ㅏ' && typing <= 'ㅣ')
             || (typing >= '가' && typing <= '힣')
             || (typing >= 'ᄀ' && typing <= 'ᄒ')
             || (typing >= 'ᅡ' && typing <= 'ᅵ')
             || (typing >= 'ᆨ' && typing <= 'ᇂ'))
                return OutputWithCursor();
            else
                return OutputWithNoCursor();
        }

        public string typed = "";
        public char typing = ' ';
        public TypeFunc Type;
        public OutputFunc Out;
        public Typing(Mode mode, Cursor cursor)
        {
            switch (mode)
            {
                case Mode.typewriter:
                    Type = TypeTypewriter;
                    break;
                case Mode.keyboard:
                    Type = TypeKeyboard;
                    break;
            }
            switch (cursor)
            {
                case Cursor.invisible:
                    Out = OutputWithNoCursor;
                    break;
                case Cursor.visible:
                    Out = OutputWithCursor;
                    break;
                case Cursor.hangeul:
                    Out = OutputWithCursorOnlyHangeul;
                    break;
            }
        }
    }
}
