//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Text;

//namespace Gier.Infrastructure.CrossCutting.Utilities
//{
//    public class PhoneticHelper
//    {
//        #region PROPRIEDADES

//        /// <summary>
//        /// Versão do Algorítmo.
//        /// </summary>
//        public string Version
//        {
//            get { return "1.5"; }
//        }

//        private string[,] ACENTOS = {
//            { "Á", "É", "Í", "Ó", "Ú", "Â", "Ê", "Î", "Ô", "Û", "Ä", "Ë", "Ï", "Ö", "Ü", "À", "È", "Ì", "Ò", "Ù", "Ã", "Õ", "Ç" },
//            { "A", "E", "I", "O", "U", "A", "E", "I", "O", "U", "A", "E", "I", "O", "U", "A", "E", "I", "O", "U", "A", "O", "C" }
//        };

//        private string[] PREPOSICOES = { "A", "AGLI", "AI", "AL", "ALLA",
//                                        "ALLE", "ALLO", "AN", "AND", "AS", "AU", "AUX", "D", "DA", "DAGLI",
//                                        "DAI", "DAL", "DALLA", "DALLE", "DALLO", "DAS", "DAS", "DE", "DEGLI",
//                                        "DEI", "DEL", "DELLA", "DELLE", "DELLO", "DER", "DI", "DIE", "DO", "DOS",
//                                        "DU", "E", "EL", "ET", "GLI", "IL", "LA", "LAS", "LE", "LO", "LOS",
//                                        "LTDA", "LDT", "LT", "LTA", "NA", "NAS", "NEGLI", "NEI", "NEL", "NELLA",
//                                        "NELLE", "NELLO", "NO", "NOS", "NUM", "O", "OF", "SA", "S/A", "S.A.",
//                                        "S. A.", "THE", "UM", "UMA", "UN", "UNA", "UND", "VON" };

//        private string[,] DUPLAS = {
//            { "AA", "BB", "CC", "DD", "EE", "FF", "GG", "HH", "II", "JJ", "KK", "LL", "MM", "NN", "OO", "PP", "KK", "RR", "SS", "TT", "UU", "VV", "WW", "XX", "YY", "ZZ" },
//            { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "K", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" }
//        };

//        private string[,] FONEMAS_LH = { { "LHA", "LHE", "LHI", "LHO", "LHU" }, { "LIA", "LIE", "LI", "LIO", "LIU" } };
//        private string[,] FONEMAS_NH = { { "NHA", "NHE", "NHI", "NHO", "NHU" }, { "NA", "NE", "NI", "NO", "NU" } };
//        private string[,] FONEMAS_1 = { { "SCH", "CH", "SH", "X", "PH" }, { "X", "X", "X", "S", "F" } };
//        private string[,] FONEMAS_2 = { { "W", "Y", "H", "Z" }, { "V", "I", "", "S" } };
//        private string[,] FONEMAS_3 = { { "SS", "SC", "XS", "XC", "KS" }, { "S", "S", "S", "S", "S" } };
//        private string[,] FONEMAS_4 = { { "KT" }, { "T" } };
//        private string[,] FONEMAS_5 = { { "EI", "E" }, { "I", "I" } };
//        private string[,] FONEMAS_6 = { { "OU", "O", "UU" }, { "U", "U", "U" } };
//        private string[,] FONEMAS_7 = { { "Q" }, { "K" } };
//        private string[,] FONEMAS_8 = { { "C" }, { "K" } };

//        #endregion

//        #region CONSTRUTORES

//        public PhoneticHelper() { }

//        #endregion

//        #region MÉTODOS

//        public string Fonetizar(string fonte)
//        {
//            if (fonte != null)
//            {
//                if (fonte.Trim().Length == 0)
//                {
//                    return fonte.Trim();
//                }

//                string[] res = RemoverAcento2(fonte);

//                for (int i = 0; i < res.Length; i++)
//                {
//                    res[i] = RemoveDuplicidades(res[i]);
//                    res[i] = SubsFonemas(res[i]);
//                }

//                return ToString(res).Trim().ToUpper();
//            }
//            else
//            {
//                return string.Empty;
//            }
//        }

//        public string FonetizarSQL(string strSource, string sqlBreak)
//        {
//            if (string.IsNullOrWhiteSpace(strSource = this.Fonetizar(strSource)))
//                return string.IsNullOrWhiteSpace(sqlBreak) ? null : sqlBreak;

//            return string.Format("{0}{1}{0}", sqlBreak, strSource.Replace(" ", sqlBreak));
//        }

//        public string FonetizarRegEx(string strSource, bool inLine = false)
//        {
//            if (string.IsNullOrWhiteSpace(strSource = this.Fonetizar(strSource)))
//                return ".*";

//            if (inLine)
//                return strSource.Replace(" ", @"\s+?");
//            else
//                return string.Format("{0}{2}{1}", "^", "$", strSource.Replace(" ", @"\s+?"));
//        }

//        public string FonetizarConsulta(string cadeiaEntrada)
//        {

//            // Montando um vetor com a cadeia de entrada, onde cada elemento do
//            // vetor se determina pelo aparecimento de um %
//            if (cadeiaEntrada == null)
//            {
//                cadeiaEntrada = "";
//            }

//            if (cadeiaEntrada.Equals("%"))
//            {
//                return "%";
//            }

//            ArrayList vetorInicial = new ArrayList();
//            StringTokenizer st = new StringTokenizer(cadeiaEntrada, '%');

//            while (st.MoveNext())
//            {
//                string s = st.Current.ToString();
//                vetorInicial.Add(s);
//            }

//            // Vari?el de rotorno.
//            string cadeiaSaida = string.Empty;

//            for (int i = 0; i < vetorInicial.Count; i++)
//            {

//                // percorrendo o vetor at?encontrar uma poss?el palavra.
//                if (!vetorInicial[i].ToString().Trim().Equals("") && !vetorInicial[i].ToString().Trim().Equals("%"))
//                {

//                    // verificando se existe uma posi?o anterior, no caso de existir
//                    // verificando se a mesma ?um operador de '%'.
//                    if (i > 0 && vetorInicial[i - 1].ToString().Equals("%"))
//                    {

//                        // verificando se a posi?o atual ?um ' '.
//                        if (Convert.ToChar(vetorInicial[i].ToString()[0]) == ' ')
//                        {

//                            // neste caso existe um espa? entre o operador de '%' e
//                            // a palavra.
//                            cadeiaSaida += "% " + Fonetizar(vetorInicial[i].ToString());
//                            if (vetorInicial[i].ToString().EndsWith(" "))
//                            {
//                                cadeiaSaida += " ";
//                            }

//                        }
//                        else if (!vetorInicial[i].ToString().Trim().Equals("%"))
//                        {

//                            // neste caso n? existe ' ' entre o operador de '%' e a
//                            // palavra.
//                            cadeiaSaida += "%" + Fonetizar(vetorInicial[i].ToString());

//                            if (vetorInicial[i].ToString().EndsWith(" "))
//                            {
//                                cadeiaSaida += " ";
//                            }

//                        }

//                    }
//                    else
//                    {

//                        cadeiaSaida += Fonetizar(vetorInicial[i].ToString());

//                        if (vetorInicial[i].ToString().EndsWith(" "))
//                        {
//                            cadeiaSaida += " ";
//                        }

//                    }

//                }

//            }

//            if (cadeiaEntrada.Trim().EndsWith("%"))
//            {
//                cadeiaSaida += "%";
//            }

//            if (cadeiaSaida.Equals("%"))
//            {
//                return string.Empty;
//            }

//            return cadeiaSaida;

//        }

//        public string RemoverAcento(string fonte)
//        {

//            if (fonte.Trim().Length == 1)
//            {
//                string res = fonte.ToUpper();
//                return RemoveAcentos(res);
//            }

//            if (fonte.Trim().Length == 0)
//            {
//                return fonte.Trim();
//            }

//            string aux = fonte.ToUpper();
//            aux = RemoveAcentos(aux);

//            string[] arr = ToArray(aux);

//            for (int i = 0; i < arr.Length; i++)
//            {
//                arr[i] = RemoveCharEspeciais(arr[i]);
//            }

//            arr = TrataSiglas(arr);
//            return ToString(arr).Trim().ToUpper();

//        }

//        private string[] RemoverAcento2(string fonte)
//        {

//            string res = fonte.ToUpper();
//            res = RemoveAcentos(res);
//            string[] arr = ToArray(res);

//            for (int i = 0; i < arr.Length; i++)
//            {
//                arr[i] = RemoveCharEspeciais(arr[i]);
//            }

//            arr = TrataSiglas(arr);
//            return RemovePreposicoes(arr);

//        }

//        public static string[] ToArray(string s)
//        {

//            string[] p = new string[1] { " " };
//            string[] arr = s.Split(p, StringSplitOptions.None);
//            ArrayList list = new ArrayList();

//            for (int i = 0; i < arr.Length; i++)
//            {
//                if (!arr[i].Trim().Equals(string.Empty))
//                {
//                    list.Add(arr[i]);
//                }
//            }

//            return (string[])list.ToArray(typeof(string));

//        }

//        public static string ToString(string[] s)
//        {

//            string f = s[0];

//            for (int i = 1; i < s.Length; i++)
//            {
//                f = f + " " + s[i];
//            }

//            return f;

//        }

//        private string SubsFonemas(string fonte)
//        {

//            // FONEMA_1
//            if (fonte.Length < 2)
//            {
//                fonte = fonte.Replace('W', 'V');
//                fonte = fonte.Replace('Y', 'I');
//                fonte = fonte.Replace('Z', 'S');
//                fonte = fonte.Replace('Q', 'K');
//                return fonte;
//            }

//            fonte = Replace(fonte, FONEMAS_LH);
//            fonte = Replace(fonte, FONEMAS_NH);
//            fonte = Replace(fonte, FONEMAS_1);
//            fonte = LetraSeguinte6(fonte, 'W', 'U');
//            fonte = ProblemaDoG(fonte);
//            fonte = Replace(fonte, FONEMAS_2);

//            if (fonte.EndsWith("S") && fonte.Length > 1)
//            {
//                char c = Convert.ToChar(fonte[fonte.LastIndexOf('S') - 1]);
//                if (IsVogal(c) || c == 'N' || c == 'M')
//                {
//                    fonte = fonte.Substring(0, fonte.LastIndexOf('S'));
//                }
//            }

//            if (fonte.EndsWith("R") && fonte.Length > 1)
//            {
//                char c = Convert.ToChar(fonte[fonte.LastIndexOf('R') - 1]);
//                if (IsVogal(c))
//                {
//                    fonte = fonte.Substring(0, fonte.LastIndexOf('R'));
//                }
//            }

//            fonte = LetraSeguinte(fonte, 'C', false, 'E', "K");
//            fonte = LetraSeguinte(fonte, 'C', false, 'I', "K");
//            fonte = LetraSeguinte(fonte, 'C', true, 'E', "S");
//            fonte = LetraSeguinte(fonte, 'C', true, 'I', "S");

//            // FONEMA_2
//            fonte = Replace(fonte, FONEMAS_3);
//            if (fonte.StartsWith("S") && fonte.Length > 1)
//            {
//                char c = Convert.ToChar(fonte[1]);
//                if (!IsVogal(c))
//                {
//                    fonte = "IS" + fonte.Substring(1);
//                }
//            }
//            fonte = LetraSeguinte2(fonte, 'B', "BI");
//            fonte = LetraSeguinte2(fonte, 'D', "DI");
//            fonte = LetraSeguinte2(fonte, 'F', "FI");
//            fonte = LetraSeguinte2(fonte, 'P', "PI");
//            fonte = LetraSeguinte2(fonte, 'T', "TI");
//            fonte = LetraSeguinte3(fonte);
//            fonte = LetraSeguinte4(fonte);

//            // FONEMA _3
//            fonte = Replace(fonte, FONEMAS_4);
//            fonte = LetraSeguinte(fonte, 'G', true, 'E', "J");
//            fonte = LetraSeguinte(fonte, 'G', true, 'I', "J");
//            fonte = LetraSeguinte5(fonte, "GU", 'E', "G");
//            fonte = LetraSeguinte5(fonte, "GU", 'I', "G");

//            // FONEMA_4
//            fonte = Replace(fonte, FONEMAS_5);
//            fonte = LetraSeguinte6(fonte, 'L', 'U');

//            // fonema 5
//            fonte = Replace(fonte, FONEMAS_6);
//            fonte = LetraSeguinte6(fonte, 'N', ' ');
//            fonte = LetraSeguinte6(fonte, 'M', ' ');
//            fonte = LetraSeguinte5(fonte, "QU", 'I', "K");

//            // FONEMA 6
//            fonte = Replace(fonte, FONEMAS_7);
//            fonte = LetraSeguinte2(fonte, 'G', "GI");

//            char aux = Convert.ToChar(fonte[fonte.Length - 1]);

//            if (!IsVogal(aux))
//            {
//                fonte = fonte + "I";
//            }

//            fonte = LetraSeguinte6(fonte, 'R', ' ');
//            fonte = RemoveDuplicidades(fonte);

//            // Trata o 'K'
//            fonte = Replace(fonte, FONEMAS_8);
//            return fonte;

//        }

//        private bool IsVogal(char c)
//        {
//            return (c == 'A') || (c == 'E') || (c == 'I') || (c == 'O') || (c == 'U');
//        }

//        private string LetraSeguinte6_(string fonte, char lp, string subs)
//        {

//            char[] f = fonte.ToCharArray();

//            for (int i = 0; i < f.Length; i++)
//            {
//                if (f[i] == lp)
//                {
//                    if (i < f.Length - 1)
//                    {
//                        if (!IsVogal(f[i + 1]))
//                        {
//                            fonte = ReplaceFirst(fonte, "" + lp, subs);
//                        }
//                    }
//                }
//            }

//            for (int i = 1; i < f.Length; i++)
//            {
//                if (f[i] == lp)
//                {
//                    if (i > 0)
//                    {
//                        if (IsVogal(f[i - 1]))
//                        {
//                            fonte = ReplaceFirst(fonte, "" + lp, subs);
//                        }
//                    }
//                }
//            }

//            return fonte;

//        }

//        private string ReplaceFirst(string original, string oldValue, string newValue)
//        {
//            int loc = original.IndexOf(oldValue);
//            return original.Remove(loc, oldValue.Length).Insert(loc, newValue);
//        }

//        private string LetraSeguinte6(string fonte, char lp, char subs)
//        {

//            if (subs == ' ')
//            {
//                subs = '#';
//            }

//            char[] f = fonte.ToCharArray();

//            for (int i = 1; i < f.Length; i++)
//            {

//                if (f[i] == lp)
//                {

//                    if (i < f.Length - 1)
//                    {
//                        if (IsVogal(f[i - 1]) && !IsVogal(f[i + 1]))
//                        {
//                            f[i] = subs;
//                        }
//                    }
//                    else
//                    {
//                        if (IsVogal(f[i - 1]))
//                        {
//                            f[i] = subs;
//                        }
//                    }
//                }
//            }

//            return new string(f).Replace("#", "");

//        }

//        private string LetraSeguinte100(string fonte, string lp, char arr, string subs)
//        {

//            char[] f = fonte.ToCharArray();

//            for (int i = 0; i < f.Length - 2; i++)
//            {
//                if (f[i] == Convert.ToChar(lp[0]))
//                {
//                    if (f[i + 2] == arr)
//                    {
//                        fonte = ReplaceFirst(fonte, lp, subs);
//                    }
//                }
//            }

//            return fonte;

//        }

//        private string LetraSeguinte5(string fonte, string lp, char arr, string subs)
//        {

//            char[] f = fonte.ToCharArray();

//            for (int i = 0; i < f.Length - 2; i++)
//            {

//                if (f[i] == Convert.ToChar(lp[0]))
//                {

//                    if (f[i + 1] == Convert.ToChar(lp[1]))
//                    {

//                        if (f[i + 2] == arr)
//                        {
//                            fonte = ReplaceFirst(fonte, lp, subs);
//                        }

//                    }

//                }

//            }

//            return fonte;

//        }

//        private string LetraSeguinte4(string fonte)
//        {

//            char[] f = fonte.ToCharArray();

//            for (int i = 0; i < f.Length - 2; i++)
//            {

//                if (f[i] == 'R')
//                {

//                    if (f[i + 1] == 'S')
//                    {

//                        if (!IsVogal(f[i + 2]))
//                        {
//                            fonte = ReplaceFirst(fonte, "RS", "S");
//                        }

//                    }

//                }

//            }

//            return fonte;

//        }

//        private string LetraSeguinte3(string fonte)
//        {

//            char[] f = fonte.ToCharArray();
//            fonte = string.Empty;

//            for (int i = 0; i < f.Length - 1; i++)
//            {

//                if (f[i] == 'X')
//                {
//                    if (!IsVogal(f[i + 1]))
//                    {
//                        fonte = fonte + 'S';
//                    }
//                    else
//                    {
//                        fonte = fonte + f[i];
//                    }
//                }
//                else
//                {
//                    fonte = fonte + f[i];
//                }
//            }

//            return fonte + f[f.Length - 1];

//        }

//        private string LetraSeguinte2(string fonte, char lp, string subst)
//        {

//            char[] f = fonte.ToCharArray();
//            fonte = string.Empty;

//            for (int i = 0; i < f.Length - 1; i++)
//            {
//                if (f[i] == lp)
//                {
//                    if (!IsVogal(f[i + 1]) && f[i + 1] != 'L' && f[i + 1] != 'R')
//                    {
//                        fonte = fonte + subst;
//                    }
//                    else
//                    {
//                        fonte = fonte + f[i];
//                    }
//                }
//                else
//                {
//                    fonte = fonte + f[i];
//                }
//            }

//            return fonte + f[f.Length - 1];

//        }

//        private string LetraSeguinte(string fonte, char lp, bool seguidade, char arr, string subst)
//        {

//            char[] f = fonte.ToCharArray();
//            fonte = string.Empty;

//            for (int i = 0; i < f.Length - 1; i++)
//            {
//                if (f[i] == lp)
//                {
//                    if (seguidade && f[i + 1] == arr)
//                    {
//                        fonte = fonte + subst;
//                    }
//                    else
//                    {
//                        fonte = fonte + f[i];
//                    }
//                }
//                else
//                {
//                    fonte = fonte + f[i];
//                }
//            }

//            return fonte + f[f.Length - 1];

//        }

//        private string ProblemaDoG(string fonte)
//        {

//            if (fonte.StartsWith("AGN") || fonte.StartsWith("VAGN"))
//            {
//                fonte = fonte.Replace("AGN", "AGUIN");
//            }

//            char[] f = fonte.ToCharArray();
//            fonte = string.Empty;

//            for (int i = 0; i < f.Length - 1; i++)
//            {
//                if (f[i] == 'G')
//                {
//                    if (IsVogal(f[i + 1]))
//                    {
//                        fonte = fonte + f[i];
//                    }
//                }
//                else
//                {
//                    fonte = fonte + f[i];
//                }
//            }

//            return fonte + f[f.Length - 1];

//        }

//        private string Replace(string fonte, string[,] lp)
//        {

//            for (int i = 0; i < lp.GetLength(1); i++)
//            {
//                fonte = fonte.Replace(lp[0, i], lp[1, i]);
//            }

//            return fonte;
//        }

//        private string RemoveDuplicidades(string fonte)
//        {


//            for (int i = 0; i < DUPLAS.Length / 2; i++)
//            {
//                while (fonte.IndexOf(DUPLAS[0, i]) > -1)
//                {
//                    fonte = fonte.Replace(DUPLAS[0, i], DUPLAS[1, i]);
//                }
//            }


//            return fonte;

//        }

//        private string[] RemovePreposicoes(string[] arr)
//        {

//            ArrayList list = new ArrayList();

//            for (int i = 0; i < arr.Length; i++)
//            {

//                bool teste = false;

//                for (int j = 0; j < PREPOSICOES.Length; j++)
//                {
//                    if (arr[i].Equals(PREPOSICOES[j]))
//                    {
//                        teste = true;
//                        break;
//                    }
//                }

//                if (!teste)
//                {
//                    list.Add(arr[i]);
//                }

//            }

//            if (list.Count != 0)
//            {
//                return (string[])list.ToArray(typeof(string));
//            }
//            else
//            {
//                return arr;
//            }

//        }

//        public string RemoveEspacos(string fonte)
//        {

//            if (fonte.Contains("  "))
//            {
//                string[] list = fonte.Split(' ');

//                string fonteAux = string.Empty;

//                for (int i = 0; i < list.Length; i++)
//                {
//                    if (!string.IsNullOrEmpty(list[i]))
//                    {
//                        fonteAux += list[i].ToString().Trim() + " ";
//                    }
//                }
//                return fonteAux.Trim();

//            }

//            return fonte;
//        }

//        private string RemoveAcentos(string fonte)
//        {

//            for (int j = 0; j < ACENTOS.GetLength(1); j++)
//            {
//                fonte = fonte.Replace("" + ACENTOS[0, j], "" + ACENTOS[1, j]);
//            }

//            return fonte;

//        }

//        private string RemoveCharEspeciais(string s_)
//        {

//            char[] nnn = s_.ToCharArray();
//            string s = string.Empty;

//            for (int i = 0; i < nnn.Length; i++)
//            {
//                s = s + ToNumeroOuLetra(nnn[i]);
//            }

//            string c_ = string.Empty;

//            for (int i = 0; i < s.Length; i++)
//            {
//                char c = Convert.ToChar(s[i]);
//                if ((c >= 65 && c <= 90))
//                {
//                    c_ = c_ + c;
//                }
//            }

//            return c_;

//        }

//        private string ToNumeroOuLetra(char c)
//        {

//            if (c == '0')
//            {
//                return "ZERO";
//            }
//            else if (c == '1')
//            {
//                return "UM";
//            }
//            else if (c == '2')
//            {
//                return "DOIS";
//            }
//            else if (c == '3')
//            {
//                return "TRES";
//            }
//            else if (c == '4')
//            {
//                return "QUATRO";
//            }
//            else if (c == '5')
//            {
//                return "CINCO";
//            }
//            else if (c == '6')
//            {
//                return "SEIS";
//            }
//            else if (c == '7')
//            {
//                return "SETE";
//            }
//            else if (c == '8')
//            {
//                return "OITO";
//            }
//            else if (c == '9')
//            {
//                return "NOVE";
//            }

//            return string.Empty + c;

//        }

//        private string[] TrataSiglas(string[] fonte)
//        {

//            ArrayList list = new ArrayList();

//            for (int i = 0; i < fonte.Length; i++)
//            {
//                if (fonte[i].Length == 1)
//                {
//                    string s = fonte[i] + "U";
//                    int c = 1;
//                    while (i + c < fonte.Length && fonte[i + c].Length == 1)
//                    {
//                        s = s + fonte[i + c] + "U";
//                        c++;
//                    }
//                    i = i + c - 1;
//                    list.Add(s);
//                }
//                else
//                {
//                    list.Add(fonte[i]);
//                }

//            }

//            return (string[])list.ToArray(typeof(string));

//        }

//        # endregion
//    }

//    /// <summary>
//    /// Classe de origem Java, utilizada na fonetização.
//    /// </summary>
//    public class StringTokenizer : IEnumerable, IEnumerator
//    {
//        # region PROPRIEDADES

//        private string[] tokensizedStrs;
//        private int index = -1;

//        # endregion

//        #region CONSTRUTORES

//        public StringTokenizer(string target, char token)
//        {
//            tokensizedStrs = target.Split(token);
//        }

//        #endregion

//        #region MÉTODOS

//        public IEnumerator GetEnumerator()
//        {
//            return this;
//        }

//        public object Current
//        {
//            get { return tokensizedStrs[index]; }
//        }

//        public bool MoveNext()
//        {

//            if (++index >= tokensizedStrs.Length)
//            {
//                return false;
//            }
//            else
//            {
//                return true;
//            }

//        }

//        public void Reset()
//        {
//            index = -1;
//        }

//        #endregion
//    }
//}
