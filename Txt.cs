using System;
using System.Collections.Generic;

namespace StringFormat {
    public class Txt {

        private static int MaxLength = 0;
        private static int MaxColums = 0;
        private static string[] TableHeader;
        private static List<string> TableRows = new List<string>();
        private static List<int> WidthCell = new List<int>();

        private static string[] TableHeader1 { set => TableHeader = value; }
        public static int MaxColums1 { set => MaxColums = value; }

        public static string RepeatChar(char c, int val) {
            return new string( c, val);
        }
        public static string title(string txt, int t) {
            int length = 80;

            switch (t) {
                case 1:
                    return centeredString($".:{txt}:.", length - 4);
                case 2:
                    return centeredString($"* {txt} *", length - 4);
                case 3:
                    return $"{centeredString(new string('*', txt.Length + 4), length - 2)}\n{centeredString($"* {txt} *", length - 2)}\n{centeredString(new string('*', txt.Length + 4), length - 2)}";
                case 4:
                    return $"{centeredString(new string('.', txt.Length + 4), length - 2)}\n{centeredString($". {txt} .", length - 2)}\n{centeredString(new string('.', txt.Length + 4), length - 2)}";
                case 5:
                    return $"{centeredString(new string('/', txt.Length + 4), length - 2)}\n{centeredString($"/ {txt} /", length - 2)}\n{centeredString(new string('/', txt.Length + 4), length - 2)}";
                default:
                    return txt;

            }
        }


        public static string centeredString(string s, int width) {
            if (s.Length >= width) {
                return s;
            }

            int leftPadding = (width - s.Length) / 2;
            int rightPadding = width - s.Length - leftPadding;

            return new string(' ', leftPadding) + s + new string(' ', rightPadding);
        }

        public static string leftString(string s, int width) {
            int rightPadding = width - s.Length;
            return s + new string(' ', rightPadding);
        }

        public static string rightString(string s, int width) {
            int leftPadding = width - s.Length;
            return new string(' ', leftPadding) + s;
        }

        private static void SetMaxLength(string[] columnas) {
            int aux = 0;
            int i = 0;

            foreach (string col in columnas) {
                int lenght = col.Length;
                if (WidthCell[i] < lenght) WidthCell[i] = lenght;
                i++;
            }
            
            foreach( int col in WidthCell) {
                aux += (col + 3);
            }

            if (MaxLength < aux) MaxLength = aux;
        }

        public static void setHeder(string[] columnas) {
            TableHeader1 = columnas;
            MaxColums1 = columnas.Length;

            foreach(string col in columnas) {
                WidthCell.Add(col.Length);
            }

            SetMaxLength(columnas);
        }

        public static void SetRow(string[] columnas) {

            if(columnas.Length > MaxColums) {
                Console.WriteLine("Error: el numero de columnas es mayor que las de los encavezados");
                return;
            }

            foreach(string col in columnas) {
                TableRows.Add(col);
            }

            SetMaxLength(columnas);
        }

        public static void PrintTable() {

            string stringBuilder = string.Empty;
            int iaux = 0;

            stringBuilder += ($"\n{new string('-', MaxLength)}\n");
            foreach (string col in TableHeader) {
                stringBuilder += ($"| {centeredString(col, WidthCell[iaux])} ");
                iaux++;
            }
            stringBuilder += ($"|\n{new string('-', MaxLength)}\n");


            int aux = 0;
            iaux = 0;
            for(int i=0; i<TableRows.Count; i++) {
                stringBuilder += ($"| {leftString(TableRows[i].ToString(), WidthCell[iaux])} ");
                aux++;
                iaux++;

                if (aux > 2) {
                    stringBuilder += ($"|\n{new string('-', MaxLength)}\n");
                    aux = 0;
                    iaux = 0;
                }
            }


            Console.WriteLine(stringBuilder);
        }
    }
}
