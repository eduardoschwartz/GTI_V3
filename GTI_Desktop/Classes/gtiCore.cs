using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using GTI_Desktop.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace GTI_Desktop.Classes {
    public static class gtiCore {
        public enum eTweakMode { Normal, AllLetters, AllLettersAllCaps, AllLettersAllSmall, AlphaNumeric, AlphaNumericAllCaps, AlphaNumericAllSmall, IntegerPositive, DecimalPositive };
        public enum LocalEndereco { Imovel, Empresa, Cidadao }
        private static byte[] key = new byte[8] { 1, 2, 3, 4, 5, 6, 7, 8 };
        private static byte[] iv = new byte[8] { 1, 2, 3, 4, 5, 6, 7, 8 };

        private static string _up;
        private static string _baseDados;
        private static string _ul;

        public static string BaseDados { get => _baseDados; set => _baseDados = value; }
        public static string Ul { get => _ul; set => _ul = value; }
        public static string Up { get => _up; set => _up = value; }
        

        public static List<ToolStripMenuItem> GetItems(MenuStrip menuStrip) {
            List<ToolStripMenuItem> myItems = new List<ToolStripMenuItem>();
            foreach (ToolStripMenuItem i in menuStrip.Items) {
                GetMenuItems(i, myItems);
            }
            return myItems;
        }
               
        private static void GetMenuItems(ToolStripMenuItem item, List<ToolStripMenuItem> items) {
            items.Add(item);
            foreach (ToolStripItem i in item.DropDownItems) {
                if (i is ToolStripMenuItem) {
                    GetMenuItems((ToolStripMenuItem)i, items);
                }
            }
        }

        public static void Ocupado(Form frm) {
            Forms.Main f1 = (Forms.Main)Application.OpenForms["Main"];
            f1.LedGreen.Enabled = false;
            f1.LedRed.Enabled = true;
            f1.Refresh();
            frm.Cursor = Cursors.WaitCursor;
            frm.Refresh();
            System.Windows.Forms.Application.DoEvents();
        }

        public static void Liberado(Form frm) {
            Forms.Main f1 = (Forms.Main)Application.OpenForms["Main"];
            f1.LedGreen.Enabled = true;
            f1.LedRed.Enabled = false;
            frm.Cursor = Cursors.Default;
            frm.Refresh();
            System.Windows.Forms.Application.DoEvents();
        }

        private static bool IsCAPS(int nKey) {
            bool bRet = false;
            if (nKey > 64 && nKey < 91)
                bRet = true;
            return bRet;
        }

        private static bool IsSmall(int nKey) {
            bool bRet = false;
            if (nKey > 96 && nKey < 123)
                bRet = true;
            return bRet;
        }

        private static bool IsDigit(int nKey) {
            bool bRet = false;
            if (nKey > 47 && nKey < 58)
                bRet = true;
            return bRet;
        }

        public static bool IsNumeric(System.Object Expression) {
            if (Expression == null || Expression is DateTime)
                return false;

            if (Expression is Int16 || Expression is Int32 || Expression is Int64 || Expression is Decimal || Expression is Single || Expression is Double || Expression is Boolean)
                return true;

            try {
                if (Expression is string)
                    Double.Parse(Expression as string);
                else
                    Double.Parse(Expression.ToString());
                return true;
            } catch { } // just dismiss errors but return false
            return false;
        }

        private static bool Doubled(string s1, string s2) {
            bool bRet = false;
            if (s1.EndsWith(s2))
                bRet = true;
            return bRet;
        }

        public static char Tweak(System.Windows.Forms.TextBox txt, char sKey, eTweakMode Mode, int DecimalPlaces) {
            int nKey = Convert.ToInt16(sKey);
            char ch = (char)nKey;
            int Curpos = txt.SelectionStart;
            int nPos = 0;

            if (nKey == 8)
                return (ch);

            switch (Mode) {
                case eTweakMode.Normal:
                    return (ch);
                case eTweakMode.AllLetters:
                    if (IsCAPS(nKey) || IsSmall(nKey))
                        return (ch);
                    break;
                case eTweakMode.AllLettersAllCaps:
                    if (IsCAPS(nKey))
                        return (ch);
                    if (IsSmall(nKey)) {
                        nKey -= 32;
                        return (Convert.ToChar(nKey));
                    }
                    break;
                case eTweakMode.AllLettersAllSmall:
                    if (IsSmall(nKey))
                        return (ch);
                    if (IsCAPS(nKey)) {
                        nKey += 32;
                        return (Convert.ToChar(nKey));
                    }
                    break;
                case eTweakMode.AlphaNumeric:
                    if (IsCAPS(nKey) || IsSmall(nKey) || IsDigit(nKey))
                        return (ch);
                    break;
                case eTweakMode.IntegerPositive:
                    if (IsDigit(nKey))
                        return (ch);
                    break;
                case eTweakMode.DecimalPositive:
                    if (IsDigit(nKey)) {
                        if (txt.Text.Length == 0)
                            return (ch);
                        nPos = txt.Text.IndexOf(",", 0);
                        if (nPos == -1)
                            return (ch);
                        else {
                            if (txt.TextLength - txt.Text.IndexOf(",", 1) < DecimalPlaces + 1)
                                return (ch);
                        }
                    }
                    if (txt.Text.Length == 0)
                        return (ch);
                    nPos = txt.Text.IndexOf(",", 0);
                    if (ch == ',' && nPos == -1)
                        return (ch);
                    break;
                default:
                    return (ch);
            }//End switch
            ch = '\0';
            return (ch);
        }//End tweak()

        public static bool IsDate(String date) {
            try {
                DateTime dt = DateTime.Parse(date);
                return true;
            } catch {
                return false;
            }
        }

        public static string ExtractNumber(string original) {
            return new string(original.Where(c => Char.IsDigit(c)).ToArray());
        }

        public static bool IsEmptyDate(string sDate) {
            if (sDate == "__/__/____" | sDate == "  /  /" | sDate == "" | sDate == "  /  /    ")
                return (true);
            else
                return (false);
        }

        /// <summary>Retorna o nome de login do usuário conectado ou que conectou por último.
        /// </summary>
        /// <returns>Nome de Login</returns>
        public static string Retorna_Last_User() {
            return Properties.Settings.Default.LastUser;
        }

        /// <summary>Retorna a string de conexão.
        /// </summary>
        /// <returns>Nome da Conexão</returns>
        public static string Connection_Name() {
            string connString = "";
            Ul = "everest"; Up = "gtisys";
            Main f1 = (Main)Application.OpenForms["Main"];
            try {
                BaseDados = f1.sbDataBase.Text;
                connString = CreateConnectionString(Properties.Settings.Default.ServerName, BaseDados, Ul, Up);
            } catch (Exception) {
            }
            return connString;
        }

        /// <summary>Retorna a data base do sistema conforme exibida na tela principal.
        /// </summary>
        /// <returns>Date DataBase</returns>
        public static DateTime Retorna_Data_Base_Sistema() {
            Main f1 = (Main)Application.OpenForms["MainForm"];
            return f1.ReturnDataBaseValue();
        }

        public static bool Valida_CPF(string cpf) {

            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;

            int soma;
            int resto;

            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");

            if (cpf.Length != 11) {
                return false;
            }
            tempCpf = cpf.Substring(0, 9);

            soma = 0;

            for (int i = 0; i < 9; i++) {
                soma += int.Parse(tempCpf[i].ToString()) * (multiplicador1[i]);
            }
            resto = soma % 11;

            if (resto < 2) {
                resto = 0;
            } else {
                resto = 11 - resto;
            }

            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            int soma2 = 0;

            for (int i = 0; i < 10; i++) {
                soma2 += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            }

            resto = soma2 % 11;

            if (resto < 2) {
                resto = 0;
            } else {
                resto = 11 - resto;
            }

            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }

        public static bool Valida_CNPJ(string vrCNPJ) {
            string CNPJ = vrCNPJ.Replace(".", "");
            CNPJ = CNPJ.Replace("/", "");
            CNPJ = CNPJ.Replace("-", "");
            int[] digitos, soma, resultado;
            int nrDig;
            string ftmt;
            bool[] CNPJOk;

            ftmt = "6543298765432";
            digitos = new int[14];
            soma = new int[2];
            soma[0] = 0;
            soma[1] = 0;
            resultado = new int[2];
            resultado[0] = 0;
            resultado[1] = 0;
            CNPJOk = new bool[2];
            CNPJOk[0] = false;
            CNPJOk[1] = false;

            try {
                for (nrDig = 0; nrDig < 14; nrDig++) {
                    digitos[nrDig] = int.Parse(
                        CNPJ.Substring(nrDig, 1));
                    if (nrDig <= 11)
                        soma[0] += (digitos[nrDig] * int.Parse(ftmt.Substring(nrDig + 1, 1)));

                    if (nrDig <= 12)

                        soma[1] += (digitos[nrDig] * int.Parse(ftmt.Substring(nrDig, 1)));
                }

                for (nrDig = 0; nrDig < 2; nrDig++) {
                    resultado[nrDig] = (soma[nrDig] % 11);
                    if ((resultado[nrDig] == 0) || (
                         resultado[nrDig] == 1))
                        CNPJOk[nrDig] = (digitos[12 + nrDig] == 0);
                    else
                        CNPJOk[nrDig] = (digitos[12 + nrDig] == (11 - resultado[nrDig]));
                }

                return (CNPJOk[0] && CNPJOk[1]);
            } catch {
                return false;
            }
        }

        public static bool Valida_Email(string Email) {
            Regex rg = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");

            if (rg.IsMatch(Email)) {
                return true;
            } else {
                return false;
            }
        }

        public static string StringRight(string value, int length) {
            return value.Substring(value.Length - length);
        }

        public static string CreateConnectionString(string ServerName, string DataBaseName, string LoginName, string Pwd) {
            SqlConnectionStringBuilder sqlBuilder = new SqlConnectionStringBuilder();

            sqlBuilder.DataSource = ServerName;
            sqlBuilder.InitialCatalog = DataBaseName;
            sqlBuilder.IntegratedSecurity = true;
            sqlBuilder.UserID = LoginName;
            sqlBuilder.Password = Pwd;

            return sqlBuilder.ConnectionString;
        }

        public static string Encrypt(string clearText) {
            SymmetricAlgorithm algorithm = DES.Create();
            ICryptoTransform transform = algorithm.CreateEncryptor(key, iv);
            byte[] inputbuffer = Encoding.Unicode.GetBytes(clearText);
            byte[] outputBuffer = transform.TransformFinalBlock(inputbuffer, 0, inputbuffer.Length);
            return Convert.ToBase64String(outputBuffer);
        }

        public static string Decrypt(string cipherText) {
            SymmetricAlgorithm algorithm = DES.Create();
            ICryptoTransform transform = algorithm.CreateDecryptor(key, iv);
            byte[] inputbuffer = Convert.FromBase64String(cipherText);
            byte[] outputBuffer = transform.TransformFinalBlock(inputbuffer, 0, inputbuffer.Length);
            return Encoding.Unicode.GetString(outputBuffer);
        }

        public static bool GetBinaryAccess(int index) {
            string _acesso = GtiTypes.UserBinary;
            if (_acesso.Substring(index - 1, 1) == "1")
                return true;
            else
                return false;
        }


    }

    public class MySR : ToolStripSystemRenderer {
        public MySR() { }

        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e) {
            if (e.ToolStrip.GetType() == typeof(ToolStrip)) {
                // skip render border
            } else {
                // do render border
                base.OnRenderToolStripBorder(e);
            }
        }
    }

}

