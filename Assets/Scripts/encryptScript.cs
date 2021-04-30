using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Security.Cryptography;
using System.IO;
using System.Text;

//source of the XOR algorithm: https://www.codingame.com/playgrounds/11117/simple-encryption-using-c-and-xor-technique
public class encryptScript : MonoBehaviour
{
    public static string EncryptDecrypt(string szPlainText, int szEncryptionKey)
    {
        StringBuilder szInputStringBuild = new StringBuilder(szPlainText);
        StringBuilder szOutStringBuild = new StringBuilder(szPlainText.Length);
        char Textch;
        for (int iCount = 0; iCount < szPlainText.Length; iCount++)
        {
            Textch = szInputStringBuild[iCount];
            Textch = (char)(Textch ^ szEncryptionKey);
            szOutStringBuild.Append(Textch);
        }
        return szOutStringBuild.ToString();
    }
}
