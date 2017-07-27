// “Copyright (C) 2009-2016 Association Réseau Phast”
// This file is part of ParserIO.
// ParserIO is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.

// ParserIO is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.

// You should have received a copy of the GNU General Public License
// along with ParserIO.  If not, see <http://www.gnu.org/licenses/>.
//
//For more information, please consult the ParserIO web site at
//<http://parserio.codeplex.com>
//
// ParserIO_functions.cs (ParserIO_functions.ParserIO_functions)

// [fr] Voir les commentaires précédent dans Form1.cs (CIOdm_parser.Form1)
// [en] See previous comments in Form1.cs (CIOdm_parser.Form1)

// 04/06/10 Version 0.6
// 04/06/10 NC [fr] Déplacé les fonctions de parsing vers une DLL
//             [en] Moved the parsing functions to a DLL

// 06/07/10 Version 0.7
// 06/07/10 NC [fr] Supporté la subType HIBC Primary/Secondary
//             [en] Supported variant HIBC Primary/Secondary

// 15/07/10 Version 0.8
// 15/07/10 NC [fr] Vérifié la clé EAN 13
//             [en] Checked the EAN 13 key
// 15/07/10 NC [fr] Transformé la bibliothèque de classes en objet COM
//             [en] Transformed the class library into a COM object
// 16/07/10 NC [fr] Evité les appels redondants de Type et subType
//             [fr] Avoided redundant calls of Type and subType

// 20/07/10 Version 0.8.1
// 20/07/10 NC [fr] Corrigé un bug signalé par DU dans le calcul de la clé EAN 13
//             [en] Fixed a bug pointed by DU in EAN 13 key calculation

// 20/07/10 Version 0.8.2
// 22/07/10 NC [fr] Corrigé la modification précédente
//             [en] Fixed the preceding modification

// 07/09/10 Version 0.9
// 07/09/10 NC [fr] Supporté les subTypes GS1-128 240 et 240.10
//             [en] Supported variants GS1-128 240 and 240.10
// 07/09/10 NC [fr] Ajouté une fonction Reference
//             [en] Added a "Reference" function

// 20/10/10 Version 0.11
// 20/10/10 NC [fr] Evité une exception avec les codes HIBC comme +E1215463140001/
//             [en] Avoided exception with HIBC codes like +E1215463140001/
// 20/10/10 NC [fr] Nettoyé les codes GS1-128 comme (01)28711428075339
//             [en] Cleansed GS1-128 codes like (01)28711428075339
// 20/10/10 NC [fr] Nettoyé les codes HIBC comme *+H1091611810*
//             [en] Cleansed HIBC codes like *+H1091611810*
// 20/10/10 NC [fr] Dans l'AI 17 de GS1-128, supporté les dates fautives comme 201412
//             [en] In GS1-128 AI 17, supported incorrect dates like 201412
// 21/10/10 NC [fr] Supporté la subType GS1-128 01.240
//             [en] Supported variant GS1-128 01.240
// 21/10/10 NC [fr] Corrigé un bug concernant les subTypes HIBC Primary/Secondary
//             [en] Fixed a bug concerning HIBC Primary/Secondary variants

// 30/11/10 Version 0.12
// 30/11/10 DU [fr] Corrigé un bug concernant les subTypes HIBC Primary/Secondary
//             [en] Fixed a bug concerning HIBC Primary/Secondary variants
// 30/11/10 DU [fr] Supporté la subType GS1-128 01.15.10
//             [en] Supported variant GS1-128 01.15.10

// 07/12/10 Version 0.13
// 07/12/10 DU [fr] Développé CheckGS1Key
//             [en] Developped CheckGS1Key
// 07/12/10 DU [fr] Supporté les subTypes GS1-128 17, 17.10, 17.30, 01.17.21
//             [en] Supported variants GS1-128 17, 17.10, 17.30, 01.17.21
// 07/12/10 NC [fr] Essayé d'intégrer les modifications suggérées par l'équipe chinoise pour COM
//             [en] Tried to integrate the modifications suggested by the Chinese team for COM

// 14/12/10 Version 0.15
// 14/12/10 DU [fr] Révisé Cleanse
//             [en] Revised Cleanse
// 14/12/10 DU [fr] Révisé CheckGS1Key
//             [en] Revised CheckGS1Key
// 14/12/10 DU [fr] Corrigé un bug concernant les subTypes HIBC Primary dont la clé est "/"
//             [en] Fixed a bug concerning HIBC Primary variants whose key is "/"
// 14/12/10 NC [fr] Numéroté les fonctions pour COM
//             [en] Assigned numbers to functions for COM

// 17/12/10 Version 0.17
// 17/12/10 DU [fr] Renomé le nom de l'interface en IParser_functions
//             [en] Renamed the name of the interface to IParser_functions
// 17/12/10 DU [fr] Changé le libellé du type pour un code non standard de ??? à NaS (Not a Standard)
//             [en] Changed the label type for a non-standard code from ??? to NaS (Not a Standard)

// 24/01/11 Version 0.19
// 24/01/11 DU [fr] Rendu la méthode Type plus robuste avec les codes GS1-128 qui commencent avec l'AI 01
//             [en] Upgraded the Type method to improve the process of GS1-128 codes starting with AI 01
// 24/01/11 DU [fr] Développé la méthode CheckSSCCKey
//             [en] Developped the CheckSSCCKey method
// 24/01/11 DU [fr] Développé la méthode SSCC
//             [en] Developped the SSCC method
// 24/01/11 DU [fr] Développé la méthode CONTENT
//             [en] Developped the CONTENT method
// 24/01/11 DU [fr] Supporté la subType GS1-128 01.11
//             [en] Supported the variant GS1-128 01.11

// 25/02/11 Version 0.21
// 25/02/11 DU [fr] Mis à jour de la méthode Clease pour remplacer "(240)" avec "240"
//             [en] Upgraded the Cleanse method to remplace "(240)" with "240"
// 25/02/11 DU [fr] Mis à jour de la méthode Clease pour remplacer "(22)" avec "22"
//             [en] Upgraded the Cleanse method to remplace "(22)" with "22"
// 25/02/11 DU [fr] Revisé la méthode Type concernant l'identification des subTypes GS1-128 93, GS1-128 240.10 et GS1-128 10
//             [en] Revided the Type method about the GS1-128 93, GS1-128 240.10 et GS1-128 10 variants identification
// 25/02/11 DU [fr] Développé la méthode VARCOUNT
//             [en] Developped the VARCOUNT method
// 25/02/11 DU [fr] Développé la méthode COUNT
//             [en] Developped the COUNT method
// 25/02/11 DU [fr] Développé la méthode Quantite
//             [en] Developped the Quantite method
// 25/02/11 DU [fr] Corrigé un bug concernant l'identification du Lot dans un code HIBC Primary/Secondary
// 25/02/11 DU [en] Fixed a bug about the batch identification for a HIBC Primary/Secondary code

// 16/03/11 Version 0.23
// 07/03/11 DU [fr] Corrigé un bug dans l'interface IParser
//             [en] Fixed a bug in the IParser interface
// 11/03/11 DU [fr] Corrigé un bug concernant l'identification du Lot dans un code HIBC Primary/Secondary
//             [en] Fixed a bug about the batch identification for a HIBC Primary/Secondary code
// 11/03/11 DU [fr] Supporté la subType GS1-128 01.11.17.30
//             [en] Supported the variant GS1-128 01.11.17.30
// 11/03/11 DU [fr] Développé la méthode PRODDATE
//             [en] Developped the PRODDATE method
// 11/03/11 DU [fr] Développé la méthode BESTBEFORE
//             [en] Developped the BESTBEFORE method
// 11/03/11 DU [fr] Développé la méthode Serial
//             [en] Developped the Serial method
// 11/03/11 DU [fr] Développé la méthode VARIANT
//             [en] Developped the VARIANT method

// 01/04/11 Version 0.25
// 01/04/11 DU [fr] Supporté la subType GS1-128 11.17.10
//             [en] Supported the variant GS1-128 11.17.10
// 05/04/11 DU [fr] Ajouté la licence LGPLv3
//             [en] Added the license LGPLv3
// 13/04/11 DU [fr] Modifié la méthode dateRaw en Expiry
//             [en] Changed the dateRaw method to Expiry method
// 13/04/11 DU [fr] Modifié la méthode DateNormale en NormalizedExpiry
//             [en] Changed the DateNormale to NormalizedExpiry
// 13/04/11 DU [fr] Développé la méthode NormalizedPRODDATE
//             [en] Developped the NormalizedPRODDATE method
// 13/04/11 DU [fr] Développé la méthode NormalizedBESTBEFORE
//             [en] Developped the NormalizedBESTBEFORE method
//
// 26/08/11 Version 0.27
// 26/08/11 DU [fr] Ajouté des commentaires pour améliorer la lisibilité de la méthode subType
//             [en] Added comments to improve the Variant method leggibility
// 26/08/11 DU [fr] Supporté la subType GS1-128 02.17.37
//             [en] Supported the variant GS1-128 02.17.37 
// 26/08/11 DU [fr] Corrigé un bug (01.17.10.10) dans la méthode subType
//             [en] Fixed a bug (01.17.10.10) in the Variant method
// 26/08/11 DU [fr] Changé l'ordre entre SSCC et Serial dans l'interface IParserIO
//             [en] Changed ordre between SSCC and Serial in IParserIO interface
// 26/08/11 DU [fr] Affiché la quantité si le code est une subType HIBC Secondary.$$.9
//             [en] Viewed quantity for a HIBC Secondary.$$.9 barcode
// 13/09/11 DU [fr] Ajouté la méthode ACL
//             [en] Added ACL method
// 20/09/11 DU [fr] Ajouté le paramétre subType aux méthodes Entreprise et Produit
//             [en] Added variant parameter to Entreprise and Produit methods
// 20/09/11 DU [fr] Ajouté la méthode Family
//             [en] Added Family method
// 21/09/11 DU [fr] Ajouté la méthode LPP
//             [en] Added LPP method            
// 22/09/11 DU [fr] Ajouté la méthode CIP
//             [en] Added CIP method
// 22/09/11 DU [fr] Ajouté la méthode UCD
//             [en] Added UCD method
// 29/09/11 DU [fr] Ajouté la méthode ADDITIONALID
//             [en] Added ADDITIONALID method
// 05/10/11 DU [fr] Changé le nom de la méthode Variante en SubType
//             [en] Changed name method from Variante to SubType
//
//
// 26/01/12 Version 0.29
// 26/01/12 DU [fr] Mis à jour la méthode Cleanse
//             [en] Updated Clease method
// 26/01/12 DU [fr] Supporté la variante GS1-128 01.240 dans la méthode ADDITIONALID
//             [en] Supported the variant GS1-128 01.240 in the ADDITIONALID method
// 26/01/12 DU [fr] Supporté la variante GS1-128 17.21
//             [en] Supported the variant GS1-128 12.21
// 26/01/12 DU [fr] Developpé la méthode CIP
//             [en] Developed CIP method
// 26/01/12 DU [fr] Supporté le subType 005 (Chris Eyes Company), Référence, Serial, Date d'expiration
//             [en] Supported subType 005 (Chris Eyes Company), Reference, Serial, Expiry
// 27/01/12 DU [fr] Supporté le subType 006 (COUSIN BIOSERV Company), Référence, Lot
//             [en] Supported subType 005 (COUSIN BIOSERV Company), Reference, Lot
// 01/02/12 DU [fr] Supporté le subType 007 (BARD France Company), Référence, Lot, Date d'expiration
//             [en] Supported subType 007 (BARD France Company), Reference, Lot, Expiry
// 01/02/12 DU [fr] Supporté le subType 008 (PHYSIOL France Company), Référence
//             [en] Supported subType 008 (PHYSIOL France Company), Reference
// 01/02/12 DU [fr] Supporté le subType 009 (Arthrex Company), Référence
//             [en] supported subType 009 (Arthrex Company), Reference
// 01/02/12 DU [fr] Supporté le subType 010 (Arthrex Company), Lot
//             [en] supported subType 010 (Arthrex Company), Lot
// 01/02/12 DU [fr] Supporté le subType 011 (Arthrex Company), Quantité
//             [en] supported subType 011 (Arthrex Company), Quantity
// 02/02/12 DU [fr] Supporté le subType 012 (SEM (Sciences Et Medecine) Company), Référence, Lot
//             [en] supported subType 012 (SEM (Sciences Et Medecine) Company), Reference, Lot
// 02/02/12 DU [fr] Supporté le subType 013 (ABS BOLTON Company), Référence
//             [en] Supported subType 013 (ABS BOLTON Company), Reference
// 02/02/12 DU [fr] Supporté le subType 014 (CHIRURGIE OUEST / EUROSILICONE / SORMED Company), Référence
//             [en] Supported subType 014 (CHIRURGIE OUEST / EUROSILICONE / SORMED Company), Reference
// 10/02/12 DU [fr] Compilé avec le .NET Framework 4.0
//             [en] Build with .NET Framework 4.0
//
//
// 21/11/12 Version 1.0.0.0
// 21/11/12 DU [fr] Developpé la méthode containsBL
//             [en] Developed containsBL method
// 21/11/12 DU [fr] Developpé la méthode indexOfBL
//             [en] Developed indexOfBL method
// 21/11/12 DU [fr] Mis à jour la méthode Type
//             [en] Updated Type method
// 26-30/11/12 DU [fr] Mis à jour ma méthode SubType
//                [en] Updated SubType method
// 01-13/12/12 DU [fr] Mis à jour les différents méthodes en utilisant indexOfBL
//                [en] Updated diffent methods to use indexOfBL
// 18-01-2013 DU [fr] Supporté Type=NaS et SubType=15
//               [en] Supported Type=NaS and SubType=15
//
// 05-06-2013 DU [fr] Mis à jour la méthode SubType (variante 012)
//               [en] Updated SubType method (012 variant)
//
// 08-26-2013 DU [fr] Vérifie HIBC Key (+A123BJC5D6E71G - Exemple Appendix B - ANSI/HIBC 2.3)
//               [en] Check HIBC Key (+A123BJC5D6E71G  - Example Appendix B - ANSI/HIBC 2.3)
//              
// 08-26-2013 DU [fr] Developpé la méthode containsOrMayContainId
//               [en] Developped the containsOrMayContainId methode
//
// 08-27-2013 DU [fr] Développé les outils pour gérer les FCN1 et BL pour GS1             
//               [en] Developped the tools for handler FCN1 and BL GS1 functions  
//
// 09-24-2013 DU [fr] Amélioré la méghode HIBC Key
//               [en] Enhanched HIBC Key method
//               [fr] Amélioré la méthode Lot en utilsant indexOfBL
//               [en] Enhanched Lot method using indexOfBL    
//
// 06-12-2013 Version 1.0.0.1
// 06-12-2013 DU [fr] Corrigé quelque bug
//               [en] Fixed some bug
//
// 04-04-2014 Version 1.0.0.2
// 04-04-2014 DU [fr] Corrigé quelque bug
//               [en] Fixed some bug
//
// 12-05-2014 Version 1.0.0.3
// 12-05-2014 DU [fr] Corrigé quelque bug dans la méthode containsSymbologyId
//               [en] Fixed some bug in containsSymbologyId method
//
// 03-06-2014 Version 1.0.0.4
// 03-06-2014 DU [fr] Corrigé quelque bug dans la méthode Type
//               [en] Fixed some bug in Type method 
// 12-11-2014 DU [fr] Corrigé quelque bug dans la méthode SubType
//               [en] Fixed some bug in SubType method
// 12-11-2014 DU [fr] Ajouté la méthode UPN
//               [en] Added UPN method
// 12-11-2014 DU [fr] Ajouté la méthode EAN
//               [en] Added EAN method
//
// 24-06-2015 Version 1.0.0.5
// 24-06-2015 DU [fr] Corrigé bug #163 dans la méthode subType
//               [en] Fixed bug #163 in subType method
// 24-06-2015 DU [fr] Corrigé bug #164 dans la méthode subType
//               [en] Fixed bug #164 in subType method
// 24-06-2015 DU [fr] Corrigé bug #166 dans la méthode subType
//               [en] Fixed bug #166 in subType method
// 24-06-2015 DU [fr] Corrigé bug #167 dans la méthode subType
//               [en] Fixed bug #167 in subType method
// 24-06-2015 DU [fr] Ajouté la méthode NaSIdParamName
//               [en] Added NaSIdParamName method
//
// 22-10-2015 Version 1.0.0.6
// 22-10-2015 DU [fr] Ecrite la nouvelle méthode subType
//               [en] Rewrite subType method
//
// 30-10-2015 DU [fr] Révision du code
//               [en] Code revised
//
// 12-11-2015 DU [fr] Ajouté la méthode UDI
//               [en] Added UDI méthod
//
// 18-03-2016 Version 1.0.0.7
// 18-03-2016 DU [fr] Début de la mise en conformité au standard HIBC 2.5
//               [en] Start to develop HIBC 2.5 features
//
// 2016-0601 Version 1.0.0.10
//               [en] Add GetFullInformationSet
//
// TODO [fr] Eviter d'utiliser System.Globalization
//      [en] Avoid to use System.Globalization


using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Reflection;
using ParserIO.DAO;

[assembly: AssemblyKeyFile("ParserIO.Core.snk")]
namespace ParserIO.Core
{
    [Guid("EAA4976A-45C3-4BC5-BC0B-E474F4C3C83F")]
    // InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IFunctions
    {
        [DispId(1)]
        string ACL(string code);
        [DispId(2)]
        string ACL(string code, string type, string subType); //1
        [DispId(3)]
        string ADDITIONALID(string code);
        [DispId(4)]
        string ADDITIONALID(string code, string type, string subType); //2
        [DispId(5)]
        string BESTBEFORE(string code);
        [DispId(6)]
        string BESTBEFORE(string code, string type, string subType); //3
        [DispId(7)]
        string CIP(string code);
        [DispId(8)]
        string CIP(string code, string type, string subType); //4
        [DispId(9)]
        string Company(string code);
        [DispId(10)]
        string Company(string code, string type, string subType);  //5
        [DispId(11)]
        bool containsOrMayContainId(string code, string type, string subType); //6
        [DispId(12)]
        string CONTENT(string code);
        [DispId(13)]
        string CONTENT(string code, string type, string subType);  //7
        [DispId(14)]
        string COUNT(string code);
        [DispId(15)]
        string COUNT(string code, string type, string subType);  //8
        [DispId(16)]
        string Expiry(string code);
        [DispId(17)]
        string Expiry(string code, string type, string subType);  //9
        [DispId(18)]
        string Family(string code);
        [DispId(19)]
        string Family(string code, string type, string subType);  //10
        [DispId(20)]
        string GTIN(string code);
        [DispId(21)]
        string GTIN(string code, string type, string subType);  //11
        [DispId(22)]
        string LIC(string code);
        [DispId(23)]
        string LIC(string code, string type, string subType);  //12
        [DispId(24)]
        string Lot(string code);
        [DispId(25)]
        string Lot(string code, string type, string subType);  //13
        [DispId(26)]
        string LPP(string code);
        [DispId(27)]
        string LPP(string code, string type, string subType);  //14
        [DispId(28)]
        string NaS7(string code);
        [DispId(29)]
        string NaS7(string code, string type, string subType);  //15
        [DispId(30)]
        string NormalizedBESTBEFORE(string code);
        [DispId(31)]
        string NormalizedBESTBEFORE(string code, string type, string subType);  //16
        [DispId(32)]
        string NormalizedExpiry(string code);
        [DispId(33)]
        string NormalizedExpiry(string code, string type, string subType);  //17
        [DispId(34)]
        string NormalizedPRODDATE(string code);
        [DispId(35)]
        string NormalizedPRODDATE(string code, string type, string subType);  //18
        [DispId(36)]
        string PCN(string code);
        [DispId(37)]
        string PCN(string code, string type, string subType);  //19
        [DispId(38)]
        string PRODDATE(string code);
        [DispId(39)]
        string PRODDATE(string code, string type, string subType);  //20
        [DispId(40)]
        string Product(string code);
        [DispId(41)]
        string Product(string code, string type, string subType);  //21
        [DispId(42)]
        string Quantity(string code);
        [DispId(43)]
        string Quantity(string code, string type, string subType);  //22
        [DispId(44)]
        string Reference(string code);
        [DispId(45)]
        string Reference(string code, string type, string subType);  //23
        [DispId(46)]
        string Serial(string code);
        [DispId(47)]
        string Serial(string code, string type, string subType);  //24
        [DispId(48)]
        string SSCC(string code);
        [DispId(49)]
        string SSCC(string code, string type, string subType);  //25
        [DispId(50)]
        string SubType(string code);
        [DispId(51)]
        string SubType(string code, string type);  //26
        [DispId(52)]
        string Type(string code);  //27
        [DispId(53)]
        string UoM(string code);
        [DispId(54)]
        string UoM(string code, string type, string subType);  //29
        [DispId(55)]
        string UPN(string code);
        [DispId(56)]
        string UPN(string code, string type, string subType);
        [DispId(57)]
        string VARCOUNT(string code);
        [DispId(58)]
        string VARCOUNT(string code, string type, string subType);  //30
        [DispId(59)]
        string VARIANT(string code);
        [DispId(60)]
        string VARIANT(string code, string type, string subType);  //31
        [DispId(61)]
        string EAN(string code);
        [DispId(62)]
        string EAN(string code, string type, string subType);
        [DispId(63)]
        string SymbologyID(string code);
        [DispId(64)]
        string NaSIdParamName(string type, string subType);
        [DispId(65)]
        string UDI(string code, string type, string subType);
        [DispId(66)]
        InformationSet GetFullInformationSet(string code);
    }

    [Guid("7BD20046-DF8C-44A6-8F6B-687FAA26FA71"),
      InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface ParserIO_Core_events
    {
    }

    [Guid("0D53A3E8-E51A-49C7-944E-E72A2064F938"),
      ClassInterface(ClassInterfaceType.AutoDual),
      ComVisible(true)]
    // [fr] Verifier si  ComVisible(true) est utile
    // [en] Check if ComVisible(true) is useful or not
    //[ProgId("ParserIO_functions")]



    public class Functions : IFunctions
    {
        private static string hibcASDlist = "(/14D|/16D|/S)";
        private static int[] _month_days = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        private static System.Collections.Generic.List<char> nValuesAssignmets = new System.Collections.Generic.List<char>
        {
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '-', '.', ' ', '$', '/', '+', '%'
        };

        private static bool Alphabetic(char c)
        // [fr] Pas utilisé la classe Char du .Net Framework pour faciliter la transposition dans un autre langage
        // [en] Not used the Char class of the .Net Framewort to facilitate the translation into another language
        {
            return (
              c == 'A' |
              c == 'B' |
              c == 'C' |
              c == 'D' |
              c == 'E' |
              c == 'F' |
              c == 'G' |
              c == 'H' |
              c == 'I' |
              c == 'J' |
              c == 'K' |
              c == 'L' |
              c == 'M' |
              c == 'N' |
              c == 'O' |
              c == 'P' |
              c == 'Q' |
              c == 'R' |
              c == 'S' |
              c == 'T' |
              c == 'U' |
              c == 'V' |
              c == 'W' |
              c == 'X' |
              c == 'Y' |
              c == 'Z');
        }

        public InformationSet GetFullInformationSet(string code)
        {
            InformationSet result = new InformationSet();
            result.executeResult = 0;
            result.AdditionalInformation = ""; //Todo
            result.Type = Type(code);
            result.SubType = SubType(code, result.Type);
            result.ACL = ACL(code, result.Type, result.SubType);
            result.ADDITIONALID = ADDITIONALID(code, result.Type, result.SubType);
            result.BESTBEFORE = BESTBEFORE(code, result.Type, result.SubType);
            result.CIP = CIP(code, result.Type, result.SubType);
            result.Company = Company(code, result.Type, result.SubType);
            result.ContainsOrMayContainId = containsOrMayContainId(code, result.Type, result.SubType);
            result.CONTENT = CONTENT(code, result.Type, result.SubType);
            result.COUNT = COUNT(code, result.Type, result.SubType);
            result.EAN = EAN(code, result.Type, result.SubType);
            result.Expiry = Expiry(code, result.Type, result.SubType);
            result.Family = Family(code, result.Type, result.SubType);
            result.GTIN = GTIN(code, result.Type, result.SubType);
            result.INTERNAL_91 = "";
            result.INTERNAL_92 = "";
            result.INTERNAL_93 = "";
            result.INTERNAL_94 = "";
            result.INTERNAL_95 = "";
            result.INTERNAL_96 = "";
            result.INTERNAL_97 = "";
            result.INTERNAL_98 = "";
            result.INTERNAL_99 = "";
            result.LIC = LIC(code, result.Type, result.SubType);
            result.Lot = Lot(code, result.Type, result.SubType);
            result.LPP = LPP(code, result.Type, result.SubType);
            result.NaS7 = NaS7(code, result.Type, result.SubType);
            result.NormalizedBESTBEFORE = NormalizedBESTBEFORE(code, result.Type, result.SubType);
            result.NormalizedExpiry = NormalizedExpiry(code, result.Type, result.SubType);
            result.NormalizedPRODDATE = NormalizedPRODDATE(code, result.Type, result.SubType);
            result.PCN = PCN(code, result.Type, result.SubType);
            result.PRODDATE = PRODDATE(code, result.Type, result.SubType);
            result.Product = Product(code, result.Type, result.SubType);
            result.Quantity = Quantity(code, result.Type, result.SubType);
            result.Reference = Reference(code, result.Type, result.SubType);
            result.NaSIdParamName = NaSIdParamName(result.Type, result.SubType);
            result.Serial = Serial(code, result.Type, result.SubType);
            result.SSCC = SSCC(code, result.Type, result.SubType);
            result.SymbologyID = SymbologyID(code);
            result.UDI = UDI(code, result.Type, result.SubType);
            result.UoM = UoM(code, result.Type, result.SubType);
            result.UPN = UPN(code, result.Type, result.SubType);
            result.VARCOUNT = VARCOUNT(code, result.Type, result.SubType);
            result.VARIANT = VARIANT(code, result.Type, result.SubType);

            return result;
        }

        public string SymbologyID(string code)
        {
            string result = "";
            code = Cleanse(code);
            string ID = "";
            if (code.Length >= 3)
                ID = code.Substring(0, 3);
            if (ID == "]A0")
                result = "A0";
            else if (ID == "]C0")
                result = "C0";
            else if (ID == "]C1")
                result = "C1";
            else if (ID == "]d1")
                result = "d1";
            else if (ID == "]d2")
                result = "d2";
            return result;
        }

        public string ADDITIONALID(string code)
        {
            string result = "";
            string type = Type(code);
            string subType = SubType(code, type);
            result = ADDITIONALID(code, type, subType);
            return result;
        }

        public string ADDITIONALID(string code, string type, string subType)
        {
            code = Cleanse(code);
            string result = "";
            if (type.StartsWith("GS1-"))
            {
                code = CleanSymbologyId(code);
                if (subType == "01.17.10.240")
                {
                    if (containsGS(code))
                    {
                        //TODO MB Controler Longueur code
                        int nextGS = indexOfGS(code, 27);
                        result = code.Substring(nextGS + 4, code.Length - (nextGS + 4));
                    }
                }
                else if (subType == "01.240")
                {
                    //TODO MB Controler Longueur code
                    result = code.Substring(19, code.Length - 19);
                }
                else if (subType == "240")
                {
                    //TODO MB Controler Longueur code
                    result = code.Substring(3, code.Length - 3);
                }
                else if (subType.StartsWith("240."))
                {
                    //TODO MB Controler Longueur code
                    int nextGS = indexOfGS(code, 1);
                    result = code.Substring(3, nextGS - 3);
                }
            }
            return result;
        }

        public string UPN(string code)
        {
            string type = Type(code);
            string subType = SubType(code);
            string result = UPN(code, type, subType);
            return result;
        }

        public string UPN(string code, string type, string subType)
        {
            string result = "";
            if ((type == "HIBC") & (subType.StartsWith("Primary")))
                result = LIC(code, type, subType).ToString() + PCN(code, type, subType).ToString() + UoM(code, type, subType);
            return result;
        }

        public string NaSIdParamName(string type, string subType)
        {
            string result = "";
            if (type == "NaS")
            {
                if (subType == "NaS7")
                    result = "NaS7";
                else if (subType == "001" |
                         subType == "004")
                    result = "EAN";
                else if (subType == "002" |
                         subType == "003")
                    result = "ACL";
            }
            return result;
        }

        public string BESTBEFORE(string code)
        {
            string type = Type(code);
            string subType = SubType(code);
            string result = BESTBEFORE(code, type, subType);
            return result;
        }

        public string BESTBEFORE(string code, string type, string subType)
        {
            code = Cleanse(code);
            string result = "";
            if (type.StartsWith("GS1-"))
            {
                code = CleanSymbologyId(code);
                //TODO MB Controler Longueur code
                if (subType.StartsWith("01.15"))
                    result = code.Substring(18, 6);
                else if (subType.StartsWith("02.10.15"))
                {
                    //TODO MB Controler Longueur code
                    int nextGS = indexOfGS(code, 16);
                    result = code.Substring(nextGS + 3, 6);
                }
            }
            return result;
        }

        private static bool CheckEan13Key(string code)
        {
            bool result = false;
            int length = code.Length;
            if (length == 13)
            {
                int sum = 0;
                char[] array = code.ToCharArray();
                bool ok = true;
                for (int i = 0; i < 12; i++)
                {
                    char c = array[i];
                    int n;
                    if (int.TryParse(c.ToString(), out n))
                    {
                        if (i % 2 == 0)
                        { // [fr] pair 
                            // [en] even
                            sum = sum + n;
                        }
                        else
                        { // [fr] impair 
                            // [en] odd
                            sum = sum + (3 * n);
                        }
                    }
                    else
                    {
                        ok = false;
                        break;
                    }
                }
                if (ok)
                {
                    int n1 = (10 - (sum % 10)) % 10;
                    int n2;
                    char c = array[12];
                    if (int.TryParse(c.ToString(), out n2))
                    {
                        result = (n1 == n2);
                    }
                }
            }
            return result;
        }


        private static bool CheckHIBCKey(string code)
        {
            bool result = false;
            int sum = 0;
            char[] array = code.ToCharArray();
            int mod = 0;
            for (int i = 0; i < code.Length - 1; i++)
            {
                char c = array[i];
                sum = sum + nValuesAssignmets.IndexOf(c);
                //sum = sum + mod; 
            }
            mod = sum % 43;
            char lastCharCode = array[code.Length - 1];
            if (nValuesAssignmets[mod] == lastCharCode)
                result = true;
            return result;
        }

        private static bool CheckGTINKey(string code)
        {
            bool result = false;
            int length = code.Length;
            int sum = 0;
            char[] array = code.ToCharArray();
            int n = -1;
            for (int i = 0; i < 13; i++)
            {
                char c = array[i];
                if (int.TryParse(c.ToString(), out n))
                {
                    if (i % 2 == 0)
                    { // [fr] pair 
                        // [en] even
                        sum = sum + (3 * n);
                    }
                    else
                    { // [fr] impair 
                        // [en] odd
                        sum = sum + n;
                    }
                }
            }
            int n1 = (10 - (sum % 10)) % 10;
            int n2;
            char key = array[13];
            if (int.TryParse(key.ToString(), out n2))
                result = (n1 == n2);
            return result;
        }

        private static bool CheckSSCCKey(string code)
        {
            bool result = false;
            int length = code.Length;
            int sum = 0;
            char[] array = code.ToCharArray();
            int n = -1;
            for (int i = 2; i < 19; i++)
            {
                char c = array[i];
                if (int.TryParse(c.ToString(), out n))
                {
                    if (i % 2 == 0)
                    { // [fr] pair 
                        // [en] even
                        sum = sum + (3 * n);
                    }
                    else
                    { // [fr] impair 
                        // [en] odd
                        sum = sum + n;
                    }
                }
            }
            int n1 = (10 - (sum % 10)) % 10;
            int n2;
            char key = array[19];
            if (int.TryParse(key.ToString(), out n2))
                result = (n1 == n2);
            return result;
        }

        private static bool Check7Car(string code)
        {
            bool result = false;
            bool ok = true;
            int sum = 0;
            char[] array = code.ToCharArray();
            int n = -1;
            for (int i = 0; i < code.Length; i++)
            {
                if (!NumericChar(array[i]))
                {
                    ok = false;
                    break;
                }
            }
            if (ok)
            {
                for (int i = 0; i < 6; i++)
                {
                    char c = array[i];
                    if (int.TryParse(c.ToString(), out n))
                    {
                        sum = sum + n * (i + 2);
                    }
                }
                int n1 = (sum % 11) % 10;
                int n2;
                char key = array[6];
                if (int.TryParse(key.ToString(), out n2))
                    result = (n1 == n2);
            }
            return result;
        }

        private static string Key7Car(string code)
        {
            string result = "-1";
            bool ok = true;
            int sum = 0;
            char[] array = code.ToCharArray();
            int n = -1;
            for (int i = 0; i < code.Length; i++)
            {
                if (!NumericChar(array[i]))
                {
                    ok = false;
                    break;
                }
            }
            if (ok)
            {
                for (int i = 0; i < 6; i++)
                {
                    char c = array[i];
                    if (int.TryParse(c.ToString(), out n))
                    {
                        sum = sum + n * (i + 2);
                    }
                }
                int n1 = (sum % 11) % 10;
                result = n1.ToString();
            }
            return result;
        }

        public bool containsOrMayContainId(string code, string type, string subType)
        {
            bool result = false;
            code = Cleanse(code);
            code = CleanSymbologyId(code);
            if (type.StartsWith("GS1-"))
            {
                if (subType.Contains("01") |
                    subType.Contains("240") |
                    subType.Contains("90") |
                    subType.Contains("91") |
                    subType.Contains("92") |
                    subType.Contains("93"))
                    result = true;
            }
            else if ((type == "HIBC") & (subType.Contains("Primary")))
            {
                result = true;
            }
            else if ((type == "NaS") & (code.Length > 0)) // To support case where just the SymbologyID is provided
            {
                if (subType == "" |
                     subType == "NaS" |
                     subType == "NaS7" |
                     subType == "001" |
                     subType == "002" |
                     subType == "003" |
                     subType == "004" |
                     subType == "005" |
                     subType == "006" |
                     subType == "007" |
                     subType == "008" |
                     subType == "009" |
                     subType == "012" |
                     subType == "013" |
                     subType == "014" |
                     subType == "016")
                    result = true;
            }
            else if (type == "EAN 13")
            {
                result = true;
            }
            return result;
        }


        public string ACL(string code)
        {
            string result = "";
            string type = Type(code);
            string subType = SubType(code);
            result = ACL(code, type, subType);
            return result;
        }

        public string ACL(string code, string type, string subType)
        {
            code = Cleanse(code);
            code = CleanSymbologyId(code);
            string result = "";
            if (code.Length >= 7)
            {
                if ((type == "EAN 13") & (subType == "ACL 13"))
                {
                    result = code;
                }
                else if ((type.StartsWith("GS1-")) & (subType.StartsWith("01")) & (code.Substring(3, 4) == "3401"))
                {
                    //TODO MB Controler Longueur code : Longueur testée à 7
                    result = code.Substring(3, 13);
                }
                else if ((type == "NaS") & ((subType == "002") | (subType == "003")))
                    result = code.Substring(0, 13);                    //TODO MB Controler Longueur code : Longueur testée à 7
            }
            return result;
        }

        public string CIP(string code)
        {
            string result = "";
            string type = Type(code);
            string subType = SubType(code);
            result = CIP(code, type, subType);
            return result;
        }

        public string CIP(string code, string type, string subType)
        {
            code = Cleanse(code);
            code = CleanSymbologyId(code);
            string result = "";
            if (type.StartsWith("GS1-"))
            {
                code = CleanSymbologyId(code);
                if ((code.Length > 3) && subType.StartsWith("01") && (code.Substring(0, 7) == "0103400"))                     //TODO MB Controler Longueur code 
                    result = code.Substring(3, 13);                     //TODO MB Controler Longueur code : Longueur testée à 7
            }
            else if ((type == "EAN 13") & (subType == "CIP 13"))
                result = code;

            return result;
        }

        public string EAN(string code)
        {
            code = Cleanse(code);
            code = CleanSymbologyId(code);
            string type = Type(code);
            string subType = SubType(code);
            string result = EAN(code, type, subType);
            return result;
        }

        public string EAN(string code, string type, string subType)
        {
            code = Cleanse(code);
            code = CleanSymbologyId(code);
            string result = "";
            if ((type == "EAN 13") & ((subType == "") | (subType == "ACL 13")))
                result = code;
            else if ((type == "NaS") & (subType == "001" | subType == "004"))
                result = code.Substring(0, 13);                     //TODO MB Controler Longueur code 
            return result;
        }


        private static string Cleanse(string code)
        {
            string result = code;
            result = result.Replace("(01)", "01");
            result = result.Replace("(10)", "10");
            result = result.Replace("(11)", "11");
            result = result.Replace("(17)", "17");
            result = result.Replace("(21)", "21");
            result = result.Replace("(22)", "22");
            result = result.Replace("(30)", "30");
            result = result.Replace("(240)", "240");
            if (result.StartsWith("*") & (result.EndsWith("*")))
                result = result.Substring(1, result.Length - 2);
            if (result.StartsWith("]C0*") & (result.EndsWith("*")))
                result = result.Replace("*", "");
            return result;
        }

        private static bool containsSymbologyId(string code)
        {
            bool result = false;
            if (code.StartsWith("]A0") |
                code.StartsWith("]C0") |
                code.StartsWith("]C1") |
                code.StartsWith("]d1") |
                code.StartsWith("]d2") |
                code.StartsWith("]E0"))
                result = true;
            return result;
        }

        private static string CleanSymbologyId(string code)
        {
            string result = code;
            if (containsSymbologyId(code))
                result = result.Substring(3, result.Length - 3);
            return result;
        }

        public string CONTENT(string code)
        {
            string type = Type(code);
            string subType = SubType(code, type);
            string result = CONTENT(code, type, subType);
            return result;
        }

        public string CONTENT(string code, string type, string subType)
        {
            code = Cleanse(code);
            code = CleanSymbologyId(code);
            string result = "";
            if (type.StartsWith("GS1-"))
            {
                code = CleanSymbologyId(code);
                if (subType.Substring(0, 2) == "02")
                    result = code.Substring(2, 14);                     //TODO MB Controler Longueur code 
            }
            return result;
        }

        /// 1-------MMyy
        /// 2-------MMddyy
        /// 3-------yyMMdd
        /// 4-------yyMMddHH
        /// 5-------yyJJJ
        /// 6-------yyJJJHH
        /// 7-------yyyy-MM
        /// 8-------MMddyy
        /// -1------error type
        private static DateTime ConvertDateTimeFromStr(String dateRaw, int dateType)
        {
            //if (dateType == 3)
            //{
            //    if (dateRaw.StartsWith("20"))
            //        if ((dateRaw.StartsWith("2013") |
            //             dateRaw.StartsWith("2014") |
            //             dateRaw.StartsWith("2015") |
            //             dateRaw.StartsWith("2016") |
            //             dateRaw.StartsWith("2017") |
            //             dateRaw.StartsWith("2018") |
            //             dateRaw.StartsWith("2019") |
            //             dateRaw.StartsWith("2020")) &
            //            (dateRaw.EndsWith("01") |
            //             dateRaw.EndsWith("02") |
            //             dateRaw.EndsWith("03") |
            //             dateRaw.EndsWith("04") |
            //             dateRaw.EndsWith("05") |
            //             dateRaw.EndsWith("06") |
            //             dateRaw.EndsWith("07") |
            //             dateRaw.EndsWith("08") |
            //             dateRaw.EndsWith("09") |
            //             dateRaw.EndsWith("10") |
            //             dateRaw.EndsWith("11") |
            //             dateRaw.EndsWith("12")))
            //        {
            //            // [fr] Est de la forme AAAAMM, devrait être AAMMJJ
            //            // [en] Is in YYYYMM form, should be YYMMDD
            //            dateRaw = dateRaw.Substring(2) + "00";  //27/01/2012 DU: A vérifier //TODO MB Controler Longueur code 
            //        }
            //}

            DateTime dt = DateTime.MinValue;
            int y = 0, m = 0, d = 0, h = 0, j = 0;
            // y ------years, m ------months, d ------days, h -------hours

            switch (dateType)
            {
                case 1:
                    m = int.Parse(dateRaw.Substring(0, 2));
                    y = int.Parse(dateRaw.Substring(2, 2));
                    break;
                case 2:
                    m = int.Parse(dateRaw.Substring(0, 2));
                    d = int.Parse(dateRaw.Substring(2, 2));
                    y = int.Parse(dateRaw.Substring(4, 2));
                    break;
                case 3:
                    //dateRaw = dateRaw.Substring(2);
                    y = int.Parse(dateRaw.Substring(0, 2));
                    m = int.Parse(dateRaw.Substring(2, 2));
                    d = int.Parse(dateRaw.Substring(4, 2));
                    break;
                case 4:
                    y = int.Parse(dateRaw.Substring(0, 2));
                    m = int.Parse(dateRaw.Substring(2, 2));
                    d = int.Parse(dateRaw.Substring(4, 2));
                    h = int.Parse(dateRaw.Substring(6, 2));
                    break;
                case 5:
                    y = int.Parse(dateRaw.Substring(0, 2));
                    j = int.Parse(dateRaw.Substring(2, 3));
                    break;
                case 6:
                    y = int.Parse(dateRaw.Substring(0, 2));
                    j = int.Parse(dateRaw.Substring(2, 3));
                    h = int.Parse(dateRaw.Substring(5, 2));
                    break;
                case 7:
                    y = int.Parse(dateRaw.Substring(2, 2));
                    m = int.Parse(dateRaw.Substring(5, 2));
                    break;
                case 8:
                    y = int.Parse(dateRaw.Substring(4, 2));
                    m = int.Parse(dateRaw.Substring(0, 2));
                    d = int.Parse(dateRaw.Substring(2, 2));
                    break;
                case 9:
                    y = int.Parse(dateRaw.Substring(8, 2));
                    m = int.Parse(dateRaw.Substring(3, 2));
                    d = int.Parse(dateRaw.Substring(0, 2));
                    break;
                case 10:
                    y = int.Parse(dateRaw.Substring(0, 2));
                    m = int.Parse(dateRaw.Substring(2, 1));
                    break;
            }

            //convert 2 digits year to 4 digits year
            dt = DateTime.ParseExact(String.Format("{0:00}", y), "yy", CultureInfo.CurrentUICulture);
            y = dt.Year;

            if (0 == y)
            {
                //invalid date time string...
                return dt;
            }

            //convert Julian Date  to DateTime
            if (0 != j)
            {
                dt = dt.AddDays(j - 1);
                if (h > 0)
                {
                    dt = dt.AddHours(h);
                }
                return dt;
            }

            //if month is zero
            if (0 == m)
            {
                m = 12;
            }

            //if days invalid
            if (_month_days[m - 1] < d || 0 == d)
            {
                if (2 == m)
                {
                    //leap year 
                    if (DateTime.IsLeapYear(y))
                    {
                        d = 29;
                    }
                    else
                    {
                        d = 28;
                    }
                }
                else
                {
                    d = _month_days[m - 1];
                }
            }

            //convert y,m,d,h to DateTime
            if (y > 0 && m > 0)
            {
                dt = dt.AddMonths(m - 1);
                dt = dt.AddDays(d - 1);
                if (h > 0)
                {
                    dt = dt.AddHours(h);
                }
            }
            return dt;
        }

        public string COUNT(string code)
        {
            string type = Type(code);
            string subType = SubType(code, type);
            string result = COUNT(code, type, subType);
            return result;
        }

        public string COUNT(string code, string type, string subType)
        {
            code = Cleanse(code);
            code = CleanSymbologyId(code);
            string result = "";
            if (type.StartsWith("GS1-"))
            {
                code = CleanSymbologyId(code);
                if (subType == "02.37")
                    result = code.Substring(18, code.Length - 18);                     //TODO MB Controler Longueur code 
                else if (subType == "02.10.37")
                {
                    if (containsGS(code))
                    {
                        int nextGS = indexOfGS(code, 16);
                        result = code.Substring(nextGS + 3, code.Length - (nextGS + 3));//TODO MB Controler Longueur code 
                    }
                    //result = code.Substring(25, 3);
                }
                else if (subType == "02.17.37.10")
                {
                    int nextGS = indexOfGS(code, 24);
                    result = code.Substring(26, nextGS - 26); //TODO MB Controler Longueur code 
                }
                else if (subType.StartsWith("02.10.15.37"))
                {
                    int nextGS = indexOfGS(code, 16);
                    result = code.Substring(nextGS + 11, code.Length - nextGS - 11); //TODO MB Controler Longueur code 
                }
                else if (subType == "02.37.10")
                {
                    int nextGS = indexOfGS(code, 16);
                    result = code.Substring(18, nextGS - 18); //TODO MB Controler Longueur code 
                }
                else if (subType.StartsWith("37"))
                {
                    int nextGS = indexOfGS(code, 1);
                    result = code.Substring(2, nextGS - 2); //TODO MB Controler Longueur code 
                }
            }
            return result;
        }

        public string Expiry(string code)
        {
            string type = Type(code);
            string subType = SubType(code, type);
            string result = Expiry(code, type, subType);
            return result;
        }

        public string Expiry(string code, string type, string subType)
        {
            code = Cleanse(code);
            code = CleanSymbologyId(code);
            string result = "";
            if (type.StartsWith("GS1-"))
            {
                //code = CleanSymbologyId(code);

                if (subType.StartsWith("01.10.17"))
                {
                    if (containsGS(code))
                    {
                        int nextGS = indexOfGS(code, 16);
                        result = code.Substring(nextGS + 3, 6); //TODO MB Controler Longueur code 
                    }
                    //result = code.Substring(code.Length-6, 6);
                }
                else if (subType.StartsWith("01.11.17"))
                {
                    result = code.Substring(26, 6); //TODO MB Controler Longueur code 
                }
                else if (subType.StartsWith("01.17"))
                {
                    result = code.Substring(18, 6); //TODO MB Controler Longueur code 
                }
                else if (subType.StartsWith("02.17"))
                {
                    result = code.Substring(18, 6); //TODO MB Controler Longueur code 
                }
                else if (subType.StartsWith("10.11.17"))
                {
                    int firstGS = indexOfGS(code, 1);
                    result = code.Substring(firstGS + 9 + 2, 6); //TODO MB Controler Longueur code 
                }
                else if (subType.StartsWith("10.17"))
                {
                    int length = code.Length;
                    int nextGS = indexOfGS(code, 1);
                    result = code.Substring(nextGS + 3, 6); //TODO MB Controler Longueur code 
                }
                else if (subType.StartsWith("11.17"))
                {
                    result = code.Substring(10, 6); //TODO MB Controler Longueur code 
                }

                else if (subType.StartsWith("17"))
                {
                    result = code.Substring(2, 6); //TODO MB Controler Longueur code 
                }
                else if (subType == "01.21.17")
                {
                    if (containsGS(code))
                    {
                        int nextGS = indexOfGS(code, 18);
                        result = code.Substring(nextGS + 3, 6); //TODO MB Controler Longueur code 
                    }
                }

                else if (subType.StartsWith("20.17"))
                {
                    result = code.Substring(6, 6); //TODO MB Controler Longueur code 
                }
                else if (subType.StartsWith("91.17.10"))
                {
                    if (containsGS(code))
                    {
                        int nextGS = indexOfGS(code, 1);
                        result = code.Substring(nextGS + 3, 6); //TODO MB Controler Longueur code 
                    }
                }
            }

            else if (type == "HIBC" && subType.Contains("Secondary"))
            {
                //code = CleanSymbologyId(code);
                string secondaryCode = null;
                if (subType.StartsWith(@"Primary/Secondary"))
                {
                    int position = code.IndexOf('/');
                    secondaryCode = "+" + code.Substring(position + 1); //TODO MB Controler Longueur code 
                }
                else
                {
                    secondaryCode = code;
                }
                int length = secondaryCode.Length;
                if (subType.EndsWith("Secondary.N") & (length >= 8))
                {
                    result = secondaryCode.Substring(1, 5);
                }
                else if (subType.EndsWith("Secondary.$$") & (length > 7))
                {
                    result = secondaryCode.Substring(3, 4);
                }
                else if (subType.EndsWith("Secondary.$$.2") & (length > 10))
                {
                    result = secondaryCode.Substring(4, 6);
                }
                else if (subType.EndsWith("Secondary.$$.3") & (length > 10))
                {
                    result = secondaryCode.Substring(4, 6);
                }
                else if (subType.EndsWith("Secondary.$$.4") & (length > 12))
                {
                    result = secondaryCode.Substring(4, 8);
                }
                else if (subType.Contains("Secondary.$$.5") & (length > 9))
                {
                    int position = secondaryCode.IndexOf("$$5");
                    result = secondaryCode.Substring(position + 3, 5);
                }
                else if (subType.EndsWith("Secondary.$$.6") & (length > 11))
                {
                    result = secondaryCode.Substring(4, 7);
                }
                else if (subType.EndsWith("Secondary.$$.8") & (length > 10))
                {
                    result = secondaryCode.Substring(6, 4);
                }
                else if (subType.EndsWith("Secondary.$$.8.2") & (length > 13))
                {
                    result = secondaryCode.Substring(7, 6);
                }
                else if (subType.EndsWith("Secondary.$$.8.3") & (length > 13))
                {
                    result = secondaryCode.Substring(7, 6);
                }
                else if (subType.EndsWith("Secondary.$$.8.4") & (length > 15))
                {
                    result = secondaryCode.Substring(7, 8);
                }
                else if (subType.EndsWith("Secondary.$$.8.5") & (length > 12))
                {
                    result = secondaryCode.Substring(7, 5);
                }
                else if (subType.EndsWith("Secondary.$$.8.6") & (length > 14))
                {
                    result = secondaryCode.Substring(7, 7);
                }
                else if (subType.EndsWith("Secondary.$$.9") & (length > 13))
                {
                    result = secondaryCode.Substring(9, 4);
                }
                else if (subType.EndsWith("Secondary.$$.9.2") & (length > 16))
                {
                    result = secondaryCode.Substring(10, 6);
                }
                else if (subType.EndsWith("Secondary.$$.9.3") & (length > 16))
                {
                    result = secondaryCode.Substring(10, 6);
                }
                else if (subType.EndsWith("Secondary.$$.9.4") & (length > 18))
                {
                    result = secondaryCode.Substring(10, 8);
                }
                else if (subType.EndsWith("Secondary.$$.9.5") & (length > 15))
                {
                    result = secondaryCode.Substring(10, 5);
                }
                else if (subType.EndsWith("Secondary.$$.9.6") & (length > 17))
                {
                    result = secondaryCode.Substring(10, 7);
                }
                if (containsASD(code))
                {
                    if (subType.Contains("14D"))
                    {
                        int position = secondaryCode.IndexOf("/14D");
                        result = secondaryCode.Substring(position + 4, 8);
                    }

                }
            }
            else if (type == "NaS")
            {
                if (subType == "005")
                {
                    result = code.Substring(21, 7);//TODO MB Controler Longueur code 
                }
                else if (subType == "007")
                {
                    result = code.Substring(16, 6);//TODO MB Controler Longueur code 
                }
                else if (subType == "015")
                {
                    result = code.Substring(5, 10);//TODO MB Controler Longueur code 

                }
                else if (subType == "016")
                {
                    result = code.Substring(18, 6);//TODO MB Controler Longueur code 

                }
                else if (subType == "017")
                {
                    result = code.Substring(7, 3);//TODO MB Controler Longueur code 

                }

            }
            //if (!NumericString(result)) // Il faut améliorer NormalizedExpriry pour supprimer définitivement ce code
            //{
            //  result = "";
            //}

            return result;
        }

        public string Family(string code)
        {
            string type = Type(code);
            string subType = SubType(code, type);
            string result = Family(code, type, subType);
            return result;
        }

        public string Family(string code, string type, string subType)
        {
            code = Cleanse(code);
            code = CleanSymbologyId(code);
            string result = "";
            if (code.Length >= 7)
            {
                if (subType == "ACL 13")
                    result = code.Substring(4, 1);
                else if ((type.StartsWith("GS1-")) & (subType.StartsWith("01") & (code.Substring(3, 4) == "3401")))
                {
                    result = code.Substring(7, 1);//TODO MB Controler Longueur code  testée à 7
                }
                else if ((type == "NaS") & ((subType == "002") | (subType == "003")))
                    result = code.Substring(4, 1);
            }
            return result;
        }

        public string NaS7(string code)
        {
            string result = "";
            string type = Type(code);
            string subType = SubType(code, type);
            result = NaS7(code, type, subType);
            return result;
        }

        public string NaS7(string code, string type, string subType)
        {
            string result = "";
            code = CleanSymbologyId(code);
            if ((type == "NaS") & (subType == "NaS7"))
                result = code;
            return result;
        }



        private string NormalizedDate(string dateRaw, string type, string subType)
        {
            string result = "";
            if (!String.IsNullOrEmpty(dateRaw))
            {
                int dateType = GetDateType(type, subType, dateRaw);
                if (dateType == 0)
                {
                    result = dateRaw;
                    return result;
                }
                else if (dateType != -1)
                {
                    DateTime dateTime = ConvertDateTimeFromStr(dateRaw, dateType);
                    if (dateTime != DateTime.MinValue)
                    {
                        if (dateTime.Hour > 0)
                        {
                            result = dateTime.ToString("yyyyMMddHH");
                        }
                        else
                        {
                            result = dateTime.ToString("yyyyMMdd");
                        }
                    }
                }
            }
            return result;
        }

        public string NormalizedBESTBEFORE(string code)
        {
            string dateRaw = BESTBEFORE(code);
            string type = Type(code);
            string subType = SubType(code);
            string result = NormalizedDate(dateRaw, type, subType);
            return result;
        }

        public string NormalizedBESTBEFORE(string code, string type, string subType)
        {
            string dateRaw = BESTBEFORE(code);
            string result = NormalizedDate(dateRaw, type, subType);
            return result;
        }

        public string NormalizedExpiry(string code)
        {
            string dateRaw = Expiry(code);
            string type = Type(code);
            string subType = SubType(code);
            string result = NormalizedDate(dateRaw, type, subType);
            return result;
        }

        public string NormalizedExpiry(string code, string type, string subType)
        {
            code = Cleanse(code);
            string dateRaw = Expiry(code, type, subType);
            string result = NormalizedDate(dateRaw, type, subType);
            return result;
        }

        public string NormalizedPRODDATE(string code)
        {
            string dateRaw = PRODDATE(code);
            string type = Type(code);
            string subType = SubType(code);
            string result = NormalizedDate(dateRaw, type, subType);
            return result;
        }

        public string NormalizedPRODDATE(string code, string type, string subType)
        {
            code = Cleanse(code);
            string dateRaw = PRODDATE(code);
            string result = NormalizedDate(dateRaw, type, subType);
            return result;
        }
        public string Company(string code)
        {
            string type = Type(code);
            string subType = SubType(code, type);
            string result = Company(code, type, subType);
            return result;
        }

        public string Company(string code, string type, string subType)
        {
            code = Cleanse(code);
            code = CleanSymbologyId(code);
            string result = "";
            if ((type == "EAN 13") & ((subType == "")))
                result = code.Substring(0, 7); //TODO MB Controler Longueur code 
            if ((type == "NaS") & (subType == "001") | (subType == "004"))
                result = code.Substring(0, 7); //TODO MB Controler Longueur code 
            return result;
        }

        /// <summary>
        /// get type of date time
        /// </summary>
        /// <param name="typeBarcode">type of barcode</param>
        /// <param name="subType">subType</param>
        /// <param name="code">barcode</param>
        /// <returns>type of date</returns>
        /// 1-------MMyy
        /// 2-------MMddyy
        /// 3-------yyMMdd
        /// 4-------yyMMddHH
        /// 5-------yyJJJ
        /// 6-------yyJJJHH
        /// 7-------yyyy-MM
        /// 8-------MMddyy  ??
        /// -1------error type
        private static int GetDateType(String typeBarcode, String subType, String dateRaw)
        {
            int typeDate = -1;
            if (typeBarcode == "GS1-128")
            {
                // YYMMDD
                typeDate = 3;
            }
            else if (typeBarcode == "HIBC" && subType.Contains("Secondary"))
            {
                if (dateRaw.Length == 4)
                {
                    // MMYY
                    typeDate = 1;
                }
                else if (dateRaw.Length == 5)
                {
                    // YYJJJ
                    typeDate = 5;

                }
                else if (dateRaw.Length == 6)
                {
                    if ((subType.Contains("$$.2") | (subType.Contains("$$.8.2"))))
                    {
                        // MMDDYY
                        typeDate = 2;
                    }
                    else if ((subType.Contains("$$.3") | (subType.Contains("$$.8.3"))))
                    {
                        // YYMMDD
                        typeDate = 3;
                    }
                }
                else if (dateRaw.Length == 7)
                {
                    // YYJJJHH
                    typeDate = 6;
                }
                else if (dateRaw.Length == 8)
                {
                    if ((subType.Contains(".14") | subType.Contains(".16")) && !(subType.Contains("$$.4") | (subType.Contains("$$.8.4"))))
                    {
                        // YYYYMMDD
                        typeDate = 0;
                    }
                    else if (!(subType.Contains(".14") | subType.Contains(".16")) && (subType.Contains("$$.4") | (subType.Contains("$$.8.4"))))
                    {
                        // YYMMDDHH
                        typeDate = 4;
                    }
                    else
                    {
                        // If the secondary structure contains both?
                        //Todo
                        // ? > YYYY > ?
                        // 12 => MM >= 01
                        // 31 => DD >= 01
                        // 24 => HH >= 00

                    }
                }
            }
            else if (typeBarcode == "NaS")
            {
                if (subType == "005")
                {
                    typeDate = 7;
                }
                else if (subType == "007")
                {
                    typeDate = 8;
                }
                else if (subType == "015")
                {
                    typeDate = 9;
                }
                else if (subType == "016")
                {
                    typeDate = 3;
                }
                else if (subType == "017")
                {
                    typeDate = 10;
                }
            }
            return typeDate;
        }


        private static int GetDateType_old(String typeBarcode, String subType, String code)
        {
            code = Cleanse(code);
            code = CleanSymbologyId(code);
            int typeDate = -1;
            if (typeBarcode == "GS1-128")
            {
                typeDate = 3; //?
            }
            else if (typeBarcode == "HIBC")
            {
                string secondaryCode = null;
                if (subType.StartsWith(@"Primary/Secondary"))
                {
                    int position = code.IndexOf('/');
                    secondaryCode = "+" + code.Substring(position + 1); //TODO MB Controler Longueur code 
                }
                else
                {
                    secondaryCode = code;
                }
                int length = secondaryCode.Length;
                if (subType.EndsWith("Secondary.N") & (length >= 8))
                {
                    typeDate = 5;
                }
                else if (subType.EndsWith("Secondary.$$") & (length > 7))
                {
                    typeDate = 1;
                }
                else if (subType.EndsWith("Secondary.$$.2") & (length > 10))
                {
                    typeDate = 2;
                }
                else if (subType.EndsWith("Secondary.$$.3") & (length > 10))
                {
                    typeDate = 3;
                }
                else if (subType.EndsWith("Secondary.$$.4") & (length > 12))
                {
                    typeDate = 4;
                }
                else if (subType.Contains("Secondary.$$.5") & (length > 9))
                {
                    typeDate = 5;
                }
                else if (subType.EndsWith("Secondary.$$.6") & (length > 11))
                {
                    typeDate = 6;
                }
                else if (subType.EndsWith("Secondary.$$.8") & (length > 10))
                {
                    typeDate = 1;
                }
                else if (subType.EndsWith("Secondary.$$.8.2") & (length > 13))
                {
                    typeDate = 2;
                }
                else if (subType.EndsWith("Secondary.$$.8.3") & (length > 13))
                {
                    typeDate = 3;
                }
                else if (subType.EndsWith("Secondary.$$.8.4") & (length > 15))
                {
                    typeDate = 4;
                }
                else if (subType.EndsWith("Secondary.$$.8.5") & (length > 12))
                {
                    typeDate = 5;
                }
                else if (subType.EndsWith("Secondary.$$.8.6") & (length > 14))
                {
                    typeDate = 6;
                }
                else if (subType.EndsWith("Secondary.$$.9") & (length > 13))
                {
                    typeDate = 1;
                }
                else if (subType.EndsWith("Secondary.$$.9.2") & (length > 16))
                {
                    typeDate = 2;
                }
                else if (subType.EndsWith("Secondary.$$.9.3") & (length > 16))
                {
                    typeDate = 3;
                }
                else if (subType.EndsWith("Secondary.$$.9.4") & (length > 18))
                {
                    typeDate = 4;
                }
                else if (subType.EndsWith("Secondary.$$.9.5") & (length > 15))
                {
                    typeDate = 5;
                }
                else if (subType.EndsWith("Secondary.$$.9.6") & (length > 17))
                {
                    typeDate = 6;
                }
                else if ((subType.Contains("14D") |
                         (subType.Contains("16D"))))
                {
                    typeDate = 99;
                }
            }
            else if (typeBarcode == "NaS")
            {
                if (subType == "005")
                {
                    typeDate = 7;
                }
                else if (subType == "007")
                {
                    typeDate = 8;
                }
                else if (subType == "015")
                {
                    typeDate = 9;
                }
                else if (subType == "016")
                {
                    typeDate = 3;
                }
                else if (subType == "017")
                {
                    typeDate = 10;
                }
            }
            return typeDate;
        }

        public string GTIN(string code)
        {
            code = Cleanse(code);
            string type = Type(code);
            string subType = SubType(code, type);
            string result = GTIN(code, type, subType);
            return result;
        }

        public string GTIN(string code, string type, string subType)
        {
            code = Cleanse(code);
            string result = "";
            if (type.StartsWith("GS1-"))
            {
                code = CleanSymbologyId(code);
                if ((subType.Substring(0, 2) == "01"))
                    if (CheckGTINKey(code.Substring(2, 14)))
                        result = code.Substring(2, 14);

            }
            return result;
        }

        public string LIC(string code)
        {
            string type = Type(code);
            string subType = SubType(code, type);
            string result = LIC(code, type, subType);
            return result;
        }

        public string LIC(string code, string type, string subType)
        {
            code = Cleanse(code);
            code = CleanSymbologyId(code);
            string result = "";
            if (type == "HIBC")
                if (subType.StartsWith("Primary"))
                {
                    code = CleanSymbologyId(code);
                    result = code.Substring(1, 4);//TODO MB Controler Longueur code 
                }
            return result;
        }

        public string Lot(string code)
        {
            string type = Type(code);
            string subType = SubType(code, type);
            string result = Lot(code, type, subType);
            return result;
        }

        public string Lot(string code, string type, string subType)
        {
            code = Cleanse(code);
            code = CleanSymbologyId(code);
            int codeLenght = code.Length;
            string result = "";
            if (type.StartsWith("GS1-"))
            {
                code = CleanSymbologyId(code);
                if (subType == "01.10")
                {
                    result = code.Substring(18); //TODO MB Controler Longueur code 
                }
                else if (subType.StartsWith("01.10.17"))
                {
                    if (containsGS(code))
                    {
                        int nextGS = indexOfGS(code, 16);
                        result = code.Substring(18, nextGS - 18);//TODO MB Controler Longueur code 
                    }
                }
                else if (subType.StartsWith("01.11.17.10"))
                {
                    result = code.Substring(34, codeLenght - 34);//TODO MB Controler Longueur code 
                }
                else if (subType.StartsWith("01.15.10"))
                {
                    int lenght = code.Length;
                    result = code.Substring(26, lenght - 26);//TODO MB Controler Longueur code 
                }
                else if (subType == "01.17.10")
                {
                    result = code.Substring(26);
                }
                else if (subType.StartsWith("01.17.10"))
                {
                    if (containsGS(code))
                    {
                        int nextGS = indexOfGS(code, 24);
                        result = code.Substring(26, nextGS - 26);//TODO MB Controler Longueur code 
                    }
                }
                else if (subType.StartsWith("01.17.30.10"))
                {
                    if (containsGS(code))
                    {
                        int nextGS = indexOfGS(code, 27);
                        result = code.Substring(nextGS + 3, code.Length - (nextGS + 3));//TODO MB Controler Longueur code 
                    }
                }

                else if (subType.StartsWith("02.10"))
                {
                    if (containsGS(code))
                    {
                        int nextGS = indexOfGS(code, 16);
                        result = code.Substring(18, nextGS - 18);//TODO MB Controler Longueur code 
                    }
                    else
                        result = code.Substring(18);
                }

                else if (subType.StartsWith("02.17.37.10"))
                {
                    if (containsGS(code))
                    {
                        int nextGS = indexOfGS(code, 27);
                        result = code.Substring(nextGS + 3, code.Length - (nextGS + 3));//TODO MB Controler Longueur code 
                    }
                }
                else if (subType.StartsWith("02.37.10"))
                {
                    if (containsGS(code))
                    {
                        int nextGS = indexOfGS(code, 16);
                        result = code.Substring(nextGS + 3, code.Length - (nextGS + 3));//TODO MB Controler Longueur code 
                    }
                }
                else if (subType.StartsWith("10"))
                {
                    if (containsGS(code))
                    {
                        int nextGS = indexOfGS(code, 1);
                        result = code.Substring(2, nextGS - 2);//TODO MB Controler Longueur code 
                    }
                    else
                    {
                        result = code.Substring(2, code.Length - 2);//TODO MB Controler Longueur code 
                    }
                }

                else if (subType.Equals("11.17.10"))
                {
                    int lenght = code.Length;
                    result = code.Substring(18, lenght - 18);//TODO MB Controler Longueur code 
                }

                else if (subType.StartsWith("17.10"))
                {
                    if (containsGS(code))
                    {
                        int nextGS = indexOfGS(code, 10);
                        result = code.Substring(10, nextGS - 10);//TODO MB Controler Longueur code 
                    }
                    else
                    {
                        result = code.Substring(10);
                    }
                }
                else if (subType.Equals("17.30.10"))
                {
                    if (containsGS(code))
                    {
                        int nextGS = indexOfGS(code, 8);
                        result = code.Substring(nextGS + 3, code.Length - nextGS - 3);//TODO MB Controler Longueur code 
                    }
                }
                else if (subType.StartsWith("20.17.10"))
                {
                    if (containsGS(code))
                    {
                        int firstGS = indexOfGS(code, 1);
                        result = code.Substring(firstGS + 11, code.Length - (firstGS + 11));//TODO MB Controler Longueur code 
                    }
                    else
                    {
                        result = code.Substring(14, code.Length - 14);//TODO MB Controler Longueur code 
                    }
                }

                else if (subType.StartsWith("37.10"))
                {
                    if (containsGS(code))
                    {
                        int firstGS = indexOfGS(code, 1);
                        int secondGS = indexOfGS(code, firstGS + 1);
                        result = code.Substring(firstGS + 3, secondGS - (firstGS + 3));//TODO MB Controler Longueur code 
                    }
                }

                else if (subType.StartsWith("91.17.10"))
                {
                    if (containsGS(code))
                    {
                        int nextGS = indexOfGS(code, 1);
                        result = code.Substring(nextGS + 11, code.Length - (nextGS + 11));//TODO MB Controler Longueur code 
                    }
                }

                else if (subType.StartsWith("240.10"))
                {
                    int firstGS = indexOfGS(code, 1);
                    int secondGS = indexOfGS(code, firstGS + 1);

                    if (secondGS != -1)
                    {
                        result = code.Substring(firstGS + 3, secondGS - firstGS - 3);//TODO MB Controler Longueur code 
                    }
                    else
                    {
                        result = code.Substring(firstGS + 3, code.Length - firstGS - 3);//TODO MB Controler Longueur code 
                    }
                }

                else if (subType.StartsWith("240.21.30.10"))
                {
                    if (containsGS(code))
                    {
                        int firstGS = indexOfGS(code, 1);
                        int secondGS = indexOfGS(code, firstGS + 1);
                        int thirdGS = indexOfGS(code, secondGS + 1);
                        result = code.Substring(thirdGS + 3, code.Length - (thirdGS + 3));//TODO MB Controler Longueur code 
                    }
                }
            }




            else if (type == "HIBC")
            {
                if (containsASD(code)) // Version 2.5
                {
                    int position;
                    string secondaryCode = null;
                    if (subType.StartsWith(@"Primary/Secondary"))
                    {
                        position = code.IndexOf('/');
                    }
                    else
                    {
                        position = 0;
                    }
                    secondaryCode = code.Substring(position + 1);
                    string[] parties = secondaryCode.Split('/');
                    string temp = parties[0].Substring(1);


                    // Shift
                    int shift = 0;
                    if (subType.Contains("$$.3"))
                    {
                        shift = 8;//10;
                    }
                    if (subType.Contains("$$.8.3"))
                    {
                        shift = 13;
                    }
                    if (subType.Contains("$$.9.3"))
                    {
                        shift = 16;
                    }

                    if (subType.Contains("$$.5"))
                    {
                        shift = 7;
                    }
                    if (subType.Contains("$$.8.5"))
                    {
                        shift = 10;
                    }
                    if (subType.Contains("$$.9.5"))
                    {
                        shift = 13;
                    }

                    result = temp.Substring(shift);
                }




                else // Version 2.4
                {
                    string secondaryCode = null;
                    if (subType.StartsWith(@"Primary/Secondary"))
                    {
                        int position = code.IndexOf('/');
                        secondaryCode = "+" + code.Substring(position + 1);//TODO MB Controler Longueur code 
                    }
                    else
                    {
                        secondaryCode = code;
                    }
                    int length = secondaryCode.Length;
                    if (subType.StartsWith("Secondary"))
                    {
                        if (subType.EndsWith("Secondary.N") & (length > 8))
                        {
                            result = secondaryCode.Substring(6, length - 8);
                        }
                        else if (subType.EndsWith("Secondary.$") & (length > 4))
                        {
                            result = secondaryCode.Substring(2, length - 4);
                        }
                        else if (subType.EndsWith("Secondary.$$") & (length > 9))
                        {
                            result = secondaryCode.Substring(7, length - 9);
                        }
                        else if (subType.EndsWith("Secondary.$$.2") & (length > 12))
                        {
                            result = secondaryCode.Substring(10, length - 12);
                        }
                        else if (subType.EndsWith("Secondary.$$.3") & (length > 12))
                        {
                            result = secondaryCode.Substring(10, length - 12);
                        }
                        else if (subType.EndsWith("Secondary.$$.4") & (length > 14))
                        {
                            result = secondaryCode.Substring(12, length - 14);
                        }
                        else if (subType.EndsWith("Secondary.$$.5") & (length > 8))
                        {
                            result = secondaryCode.Substring(9, length - 11);
                        }
                        else if (subType.EndsWith("Secondary.$$.6") & (length > 13))
                        {
                            result = secondaryCode.Substring(11, length - 13);
                        }
                        else if (subType.EndsWith("Secondary.$$.7") & (length > 6))
                        {
                            result = secondaryCode.Substring(4, length - 6);
                        }
                        else if (subType.EndsWith("Secondary.$$.8") & (length > 12))
                        {
                            result = secondaryCode.Substring(10, length - 12);
                        }
                        else if (subType.EndsWith("Secondary.$$.8.2") & (length > 15))
                        {
                            result = secondaryCode.Substring(13, length - 15);
                        }
                        else if (subType.EndsWith("Secondary.$$.8.3") & (length > 15))
                        {
                            result = secondaryCode.Substring(13, length - 15);
                        }
                        else if (subType.EndsWith("Secondary.$$.8.4") & (length > 17))
                        {
                            result = secondaryCode.Substring(15, length - 17);
                        }
                        else if (subType.EndsWith("Secondary.$$.8.5") & (length > 14))
                        {
                            result = secondaryCode.Substring(12, length - 14);
                        }
                        else if (subType.EndsWith("Secondary.$$.8.6") & (length > 16))
                        {
                            result = secondaryCode.Substring(14, length - 16);
                        }
                        else if (subType.EndsWith("Secondary.$$.8.7") & (length > 9))
                        {
                            result = secondaryCode.Substring(7, length - 9);
                        }
                        else if (subType.EndsWith("Secondary.$$.9") & (length > 15))
                        {
                            result = secondaryCode.Substring(13, length - 15);
                        }
                        else if (subType.EndsWith("Secondary.$$.9.2") & (length > 18))
                        {
                            result = secondaryCode.Substring(16, length - 18);
                        }
                        else if (subType.EndsWith("Secondary.$$.9.3") & (length > 18))
                        {
                            result = secondaryCode.Substring(16, length - 18);
                        }
                        else if (subType.EndsWith("Secondary.$$.9.4") & (length > 20))
                        {
                            result = secondaryCode.Substring(18, length - 20);
                        }
                        else if (subType.EndsWith("Secondary.$$.9.5") & (length > 17))
                        {
                            result = secondaryCode.Substring(15, length - 17);
                        }
                        else if (subType.EndsWith("Secondary.$$.9.6") & (length > 19))
                        {
                            result = secondaryCode.Substring(17, length - 19);
                        }
                        else if (subType.EndsWith("Secondary.$$.9.7") & (length > 12))
                        {
                            result = secondaryCode.Substring(10, length - 12);
                        }
                    }

                    if (subType.StartsWith("Primary/Secondary"))
                    {
                        if (subType.EndsWith(".N"))
                        {
                            result = secondaryCode.Substring(6, length - 7);//TODO MB Controler Longueur code 
                        }
                        else if (subType.EndsWith(".$"))
                        {
                            result = secondaryCode.Substring(2, length - 3);//TODO MB Controler Longueur code 
                        }
                        else if (subType.EndsWith(".$$"))
                        {
                            result = secondaryCode.Substring(7, length - 8);//TODO MB Controler Longueur code 
                        }

                        else if (subType.EndsWith(".$$.2") & (length > 12))
                        {
                            result = secondaryCode.Substring(10, length - 11);
                        }
                        else if (subType.EndsWith(".$$.3") & (length > 12))
                        {
                            result = secondaryCode.Substring(10, length - 11);
                        }
                        else if (subType.EndsWith(".$$.4") & (length > 14))
                        {
                            result = secondaryCode.Substring(12, length - 13);
                        }
                        else if (subType.EndsWith(".$$.5") & (length > 11))
                        {
                            result = secondaryCode.Substring(9, length - 10);
                        }
                        else if (subType.EndsWith(".$$.6") & (length > 13))
                        {
                            result = secondaryCode.Substring(11, length - 12);
                        }
                        else if (subType.EndsWith(".$$.7") & (length > 6))
                        {
                            result = secondaryCode.Substring(4, length - 5);
                        }
                        else if (subType.EndsWith(".$$.8") & (length > 12))
                        {
                            result = secondaryCode.Substring(10, length - 11);
                        }
                        else if (subType.EndsWith(".$$.8.2") & (length > 15))
                        {
                            result = secondaryCode.Substring(13, length - 14);
                        }
                        else if (subType.EndsWith(".$$.8.3") & (length > 15))
                        {
                            result = secondaryCode.Substring(13, length - 14);
                        }
                        else if (subType.EndsWith(".$$.8.4") & (length > 17))
                        {
                            result = secondaryCode.Substring(15, length - 16);
                        }
                        else if (subType.EndsWith(".$$.8.5") & (length > 14))
                        {
                            result = secondaryCode.Substring(12, length - 13);
                        }
                        else if (subType.EndsWith(".$$.8.6") & (length > 16))
                        {
                            result = secondaryCode.Substring(14, length - 15);
                        }
                        else if (subType.EndsWith(".$$.8.7") & (length > 9))
                        {
                            result = secondaryCode.Substring(7, length - 8);
                        }
                        else if (subType.EndsWith(".$$.9") & (length > 15))
                        {
                            result = secondaryCode.Substring(13, length - 14);
                        }
                        else if (subType.EndsWith(".$$.9.2") & (length > 18))
                        {
                            result = secondaryCode.Substring(16, length - 17);
                        }
                        else if (subType.EndsWith(".$$.9.3") & (length > 18))
                        {
                            result = secondaryCode.Substring(16, length - 17);
                        }
                        else if (subType.EndsWith(".$$.9.4") & (length > 20))
                        {
                            result = secondaryCode.Substring(18, length - 19);
                        }
                        else if (subType.EndsWith(".$$.9.5") & (length > 17))
                        {
                            result = secondaryCode.Substring(15, length - 16);
                        }
                        else if (subType.EndsWith(".$$.9.6") & (length > 19))
                        {
                            result = secondaryCode.Substring(17, length - 18);
                        }
                        else if (subType.EndsWith(".$$.9.7") & (length > 12))
                        {
                            result = secondaryCode.Substring(10, length - 11);
                        }
                    }
                }
            }

            else if (type == "NaS")
            {
                if (subType == "006")
                {
                    result = code.Substring(11, 6);//TODO MB Controler Longueur code 
                }
                else if (subType == "007")
                {
                    result = code.Substring(8, 8);//TODO MB Controler Longueur code 
                }
                else if (subType == "010")
                {
                    result = code.Substring(1, 6);//TODO MB Controler Longueur code 
                }
                else if (subType == "012")
                {
                    result = code.Substring(code.IndexOf('^') + 1, code.Length - code.IndexOf('^') - 2); //TODO MB Controler Longueur code ATTENTION si un seul ^
                }
                else if (subType == "015")
                {
                    result = code.Substring(0, 4);//TODO MB Controler Longueur code 
                }
                else if (subType == "016")
                {
                    result = code.Substring(9, 9);//TODO MB Controler Longueur code 
                }
                else if (subType == "017")
                {
                    result = code.Substring(0, 7);//TODO MB Controler Longueur code 
                }
            }
            return result;
        }

        public string LPP(string code)
        {
            string result = "";
            string type = Type(code);
            string subType = SubType(code);
            result = LPP(code, type, subType);
            return result;
        }


        public string LPP(string code, string type, string subType)
        {
            string result = "";
            code = CleanSymbologyId(code);
            if ((type == "NaS") & (subType == "001"))
                result = code.Substring(13, 6) + Key7Car(code.Substring(13, 6));//TODO MB Controler Longueur code 
            if ((type == "NaS") & ((subType == "002") | (subType == "004")))
                result = code.Substring(13, 7);//TODO MB Controler Longueur code 
            if ((type == "NaS") & (subType == "003"))
                result = code.Substring(14, 7);//TODO MB Controler Longueur code 
            return result;
        }

        private static bool NumericChar(char c)
        // [fr] Pas utilisé la classe Char du .Net Framework pour faciliter la transposition dans un autre langage
        // [en] Not used the Char class of the .Net Framewort to facilitate the translation into another language
        {
            return (
              c == '0' |
              c == '1' |
              c == '2' |
              c == '3' |
              c == '4' |
              c == '5' |
              c == '6' |
              c == '7' |
              c == '8' |
              c == '9');
        }

        private static bool NumericString(string code)
        {
            bool ok = true;
            char[] array = code.ToCharArray();
            for (int i = 0; i < code.Length; i++)
            {
                if (!NumericChar(array[i]))
                {
                    ok = false;
                    break;
                }
            }
            return ok;
        }

        public string PCN(string code)
        {
            string type = Type(code);
            string subType = SubType(code, type);
            string result = PCN(code, type, subType);
            return result;
        }

        public string PCN(string code, string type, string subType)
        {
            code = Cleanse(code);
            code = CleanSymbologyId(code);
            string result = "";
            if (type == "HIBC")
            {
                code = CleanSymbologyId(code);
                if (subType == "Primary")
                {
                    result = code.Substring(5, code.Length - 7);//TODO MB Controler Longueur code 
                }
                else if (subType.StartsWith(@"Primary/Secondary"))
                {
                    int position = code.IndexOf('/');
                    result = code.Substring(5, position - 6);//TODO MB Controler Longueur code 
                }
            }
            return result;
        }

        public string PRODDATE(string code)
        {
            string type = Type(code);
            string subType = SubType(code);
            string result = PRODDATE(code, type, subType);
            return result;
        }

        public string PRODDATE(string code, string type, string subType)
        {
            code = Cleanse(code);
            code = CleanSymbologyId(code);
            string result = "";
            if (type.StartsWith("GS1-"))
            {
                if (subType.StartsWith("01.11"))
                {
                    result = code.Substring(18, 6);//TODO MB Controler Longueur code 
                }
                else if (subType.StartsWith("10.11"))
                {
                    int firstGS = indexOfGS(code, 1);
                    result = code.Substring(firstGS + 3, 6);//TODO MB Controler Longueur code 
                }
                else if (subType.StartsWith("11"))
                {
                    result = code.Substring(2, 6);//TODO MB Controler Longueur code 
                }

            }
            else if (type == "HIBC")
            {
                if (subType.Contains("16D"))
                {
                    int position = code.IndexOf("/16D");
                    result = code.Substring(position + 4, 8);
                }
            }
            return result;
        }

        public string Reference(string code)
        {
            string type = Type(code);
            string subType = SubType(code, type);
            string result = Reference(code, type, subType);
            return result;
        }

        public string Reference(string code, string type, string subType)
        {
            code = Cleanse(code);
            code = CleanSymbologyId(code);
            string result = "";
            if (type == "NaS")
            {
                if (subType == "005")
                {
                    result = code.Substring(0, 9);//TODO MB Controler Longueur code 
                }
                else if (subType == "006")
                {
                    result = code.Substring(0, 10);//TODO MB Controler Longueur code 
                }
                else if (subType == "007")
                {
                    result = code.Substring(0, 8);//TODO MB Controler Longueur code 
                }
                else if (subType == "008")
                {
                    result = code.Substring(0, 8);//TODO MB Controler Longueur code 
                }
                else if (subType == "009")
                {
                    result = code.Substring(1, code.Length - 1);
                }
                else if (subType == "012")
                {
                    result = code.Substring(3, 6);//TODO MB Controler Longueur code 
                }
                else if (subType == "013")
                {
                    result = code.Substring(1, 13);//TODO MB Controler Longueur code 
                }
                else if (subType == "014")
                {
                    result = code.Substring(0, 4) + code.Substring(5, 5);//TODO MB Controler Longueur code 
                }
                else if (subType == "015")
                {
                    //To Do : waiting for Symbios answer
                }
                else if (subType == "016")
                {
                    result = code.Substring(0, 9);//TODO MB Controler Longueur code 
                }
                else if (subType == "NaS")
                {
                    result = code;
                }
            }
            return result;
        }

        public string Product(string code)
        {
            string type = Type(code);
            string subType = SubType(code, type);
            string result = Product(code, type, subType);
            return result;
        }

        public string Product(string code, string type, string subType)
        {
            code = Cleanse(code);
            code = CleanSymbologyId(code);
            string result = "";
            if ((type == "EAN 13") & (subType == ""))
                result = code.Substring(7, 5);//TODO MB Controler Longueur code 
            if ((type == "NaS") & ((subType == "001") | (subType == "004")))
                result = code.Substring(7, 5);//TODO MB Controler Longueur code 
            return result;
        }

        public string Serial(string code)
        {
            string type = Type(code);
            string subType = SubType(code);
            string result = Serial(code, type, subType);
            return result;
        }

        public string Serial(string code, string type, string subType)
        {
            code = Cleanse(code);
            code = CleanSymbologyId(code);
            int length = code.Length;
            string result = "";
            if (type.StartsWith("GS1-"))
            {
                code = CleanSymbologyId(code);
                if (subType == "01.17.21")
                {
                    result = code.Substring(26, code.Length - 26);//TODO MB Controler Longueur code 
                }
                else if (subType == "01.10.17.21")
                {
                    int firstGS = indexOfGS(code, 16);
                    result = code.Substring(firstGS + 11, length - (firstGS + 11));//TODO MB Controler Longueur code 
                }
                else if (subType == "01.11.17.21")
                {
                    result = code.Substring(34, length - 34);//TODO MB Controler Longueur code 
                }
                else if (subType.StartsWith("01.21"))
                {
                    if (containsGS(code))
                    {
                        int firstGS = indexOfGS(code, 18);
                        result = code.Substring(18, firstGS - 18);//TODO MB Controler Longueur code 
                    }
                }
                else if (subType == "10.21")
                {
                    int firstGS = indexOfGS(code, 1);
                    result = code.Substring(firstGS + 3, length - (firstGS + 3));//TODO MB Controler Longueur code 
                }
                else if (subType == "17.21")
                {
                    result = code.Substring(10, code.Length - 10);//TODO MB Controler Longueur code 
                }
                else if (subType == "37.10.21")
                {
                    if (containsGS(code))
                    {
                        int firstGS = indexOfGS(code, 1);
                        int secondGS = indexOfGS(code, firstGS + 1);
                        result = code.Substring(secondGS + 3, code.Length - (secondGS + 3));//TODO MB Controler Longueur code 
                    }
                }

                else if (subType.StartsWith("240.21"))
                {
                    if (containsGS(code))
                    {
                        int firstGS = indexOfGS(code, 3);
                        int secondGS = indexOfGS(code, firstGS + 1);
                        result = code.Substring(firstGS + 3, secondGS - (firstGS + 3));//TODO MB Controler Longueur code 
                    }
                }
            }
            else if (type == "HIBC" && subType.Contains("Secondary"))
            {
                string data = semanticData(code, subType);
                if (containsASD(data))
                {
                    if (subType.EndsWith(".S"))
                    {
                        int start = data.IndexOf("/S") + 2;
                        int stop = data.Length - start;
                        result = data.Substring(start, stop);
                    }
                }
            }


            else if (type == "NaS")
            {
                if (subType == "005")
                {
                    result = code.Substring(10, 10);//TODO MB Controler Longueur code 
                }

            }
            return result;
        }

        public static string semanticData(string code, string subType)
        {
            string result = "";
            if (subType.Contains("Secondary"))
            {
                if (subType.StartsWith("Primary/"))
                {
                    result = code.Substring(code.IndexOf("/"), code.Length - code.IndexOf("/") - 1);
                }
                else
                {
                    result = code.Substring(1, code.Length - 2);
                }
            }
            return result;
        }
        public string VARCOUNT(string code)
        {
            string type = Type(code);
            string subType = SubType(code);
            string result = VARCOUNT(code, type, subType);
            return result;
        }

        public string VARCOUNT(string code, string type, string subType)
        {
            code = Cleanse(code);
            int length = code.Length;
            string result = "";
            if (type.StartsWith("GS1-"))
            {
                code = CleanSymbologyId(code);
                if (subType.StartsWith("01.10.17.30"))
                {
                    if (containsGS(code))
                    {
                        int nextGS = indexOfGS(code, 19);
                        result = code.Substring(nextGS + 11, code.Length - (nextGS + 11));//TODO MB Controler Longueur code 
                    }
                }
                else if (subType == "01.30")
                    result = code.Substring(18, code.Length - 18);
                else if (subType.StartsWith("01.17.30"))
                {
                    if (containsGS(code))
                    {
                        int nextGS = indexOfGS(code, 24);
                        result = code.Substring(26, nextGS - 26);//TODO MB Controler Longueur code 
                    }
                }
                else if (subType.StartsWith("01.17.10.30"))
                {
                    if (containsGS(code))
                    {
                        int nextGS = indexOfGS(code, 27);
                        result = code.Substring(nextGS + 3, code.Length - (nextGS + 3));//TODO MB Controler Longueur code 
                    }
                }
                else if (subType == "10.11.17.30")
                {
                    int firstGS = indexOfGS(code, 1);
                    int shift = firstGS + 1 + 8 + 8 + 2;
                    int nb = length - shift - 3;
                    result = code.Substring(shift, nb);//TODO MB Controler Longueur code 
                }
                else if (subType == "10.17.30")
                {
                    int firstGS = indexOfGS(code, 1);
                    int shift = firstGS + 1 + 8 + 2;
                    int nb = length - shift - 3;
                    result = code.Substring(shift, nb);//TODO MB Controler Longueur code 
                }
                else if (subType.StartsWith("17.10.30"))
                {
                    if (containsGS(code))
                    {
                        int nextGS = indexOfGS(code, 8);
                        result = code.Substring(nextGS + 3, code.Length - (nextGS + 3));//TODO MB Controler Longueur code 
                    }
                }
                else if (subType.StartsWith("17.30"))
                {
                    if (containsGS(code))
                    {
                        int nextGS = indexOfGS(code, 8);
                        result = code.Substring(10, nextGS - 10);//TODO MB Controler Longueur code 
                    }
                    else
                    {
                        result = code.Substring(10, code.Length - 10);//TODO MB Controler Longueur code 
                    }
                }
                else if (subType.StartsWith("240.21.30"))
                {
                    if (containsGS(code))
                    {
                        int firstGS = indexOfGS(code, 1);
                        int secondGS = indexOfGS(code, firstGS + 1);
                        int thirdGS = indexOfGS(code, secondGS + 1);
                        result = code.Substring(secondGS + 3, thirdGS - (secondGS + 3));//TODO MB Controler Longueur code 
                    }
                }
            }

            return result;
        }

        public string VARIANT(string code)
        {
            string type = Type(code);
            string subType = SubType(code);
            string result = VARIANT(code, type, subType);
            return result;
        }

        public string VARIANT(string code, string type, string subType)
        {
            code = Cleanse(code);
            string result = "";
            if (type.StartsWith("GS1-"))
            {
                code = CleanSymbologyId(code);
                if (subType.StartsWith("20"))
                    result = code.Substring(2, 2);//TODO MB Controler Longueur code 
            }
            return result;
        }

        public string Quantity(string code)
        {
            string type = Type(code);
            string subType = SubType(code);
            string result = Quantity(code, type, subType);
            return result;
        }

        public string Quantity(string code, string type, string subType)
        {
            code = Cleanse(code);
            code = CleanSymbologyId(code);
            string result = "";

            if ((type == "HIBC") && (subType.Contains("Secondary")))
            {
                int start = 1;
                int stop;
                string secondaryCode = null;
                string data = "";
                if (subType.StartsWith(@"Primary/Secondary"))
                {
                    start = start + code.IndexOf('/');
                }
                else
                {
                    //Nothing
                }
                secondaryCode = code.Substring(start);

                if (containsASD(code)) // Version 2.5
                {
                    string[] parties = secondaryCode.Split('/');
                    data = parties[0].Substring(1);

                }
                else
                {
                    if (subType.StartsWith("Primary"))
                    {
                        data = secondaryCode.Substring(0, secondaryCode.Length - 1);
                    }
                    else
                    {
                        data = secondaryCode.Substring(0, secondaryCode.Length - 2);
                    }
                }



                if (subType.Contains("Secondary.$$.8"))
                {
                    result = data.Substring(3, 2);
                }
                else if (subType.Contains("Secondary.$$.9"))
                {
                    result = data.Substring(3, 5);
                }
            }

            else if (type == "NaS")
            {
                if (subType == "011")
                    result = code.Substring(1, 1);
            }
            return result;
        }

        public string Quantity_old(string code, string type, string subType)
        {
            code = Cleanse(code);
            code = CleanSymbologyId(code);
            string result = "";

            if (type == "HIBC")
            {
                string secondaryCode = null;
                if (subType.StartsWith(@"Primary/Secondary"))
                {
                    int position = code.IndexOf('/');
                    secondaryCode = "+" + code.Substring(position + 1);//TODO MB Controler Longueur code 
                }
                else
                {
                    secondaryCode = code;
                }
                int length = secondaryCode.Length;
                if (subType.Contains("Secondary.$$.8") & (length > 8))
                {
                    result = secondaryCode.Substring(4, 2);
                }
                else if (subType.EndsWith("Secondary.$$.9") & (length > 4))
                {
                    result = secondaryCode.Substring(4, 5);
                }
            }
            //if (type == "HIBC")
            //{
            //  if (subType.StartsWith("Secondary.$$.8"))
            //    result = code.Substring(4, 2);
            //  if (subType.StartsWith("Secondary.$$.9"))
            //    result = code.Substring(4, 5);
            //}


            else if (type == "NaS")
            {
                if (subType == "011")
                    result = code.Substring(1, 1);
            }
            return result;
        }

        public string SSCC(string code)
        {
            string type = Type(code);
            string subType = SubType(code, type);
            string result = SSCC(code, type, subType);
            return result;
        }

        public string SSCC(string code, string type, string subType)
        {
            code = Cleanse(code);
            string result = "";
            if (type.StartsWith("GS1-"))
            {
                code = CleanSymbologyId(code);
                if (subType.Substring(0, 2) == "00")
                    result = code.Substring(2, 18);//TODO MB Controler Longueur code 
            }
            return result;
        }

        //private bool IsNumeric(string valueToCheck)
        //{
        //  Regex regex = new Regex(@"^[0-9]*$");
        //  return regex.IsMatch(valueToCheck);
        //}

        public string Type(string code)
        {
            string result = "NaS";
            int length = code.Length;
            code = Cleanse(code);
            if ((length > 5) && code.StartsWith("]C1"))
            {
                result = "GS1-128";
            }

            else if ((length > 5) && code.StartsWith("]d2"))
            {
                result = "GS1-Datamatrix";
            }

            else if ((code.StartsWith("]d1+") | (code.StartsWith("]C0+") | code.StartsWith("]A0+") | code.StartsWith("+"))))
            {
                code = CleanSymbologyId(code);
                if (CheckHIBCKey(code))
                    result = "HIBC";
            }
            else if (code.StartsWith("]E0"))
            {
                code = CleanSymbologyId(code);
                length = code.Length;
                if (length == 13 && CheckEan13Key(code))
                {
                    result = "EAN 13";
                }
            }
            else if (length == 13 && CheckEan13Key(code))
            {
                result = "EAN 13";
            }

            else if ((length >= 20) && (code.StartsWith("00")))
            {
                bool ok = true;
                char[] array = code.ToCharArray();
                for (int i = 2; i < 20; i++)
                {
                    if (!NumericChar(array[i]))
                    {
                        ok = false;
                        break;
                    }
                }
                if (ok)
                {
                    if (CheckSSCCKey(code))
                    {
                        result = "GS1-128";
                    }
                }
            }
            else if ((length >= 16) && (code.StartsWith("01")))
            {
                bool ok = true;
                char[] array = code.ToCharArray();
                for (int i = 2; i < 16; i++)
                {
                    if (!NumericChar(array[i]))
                    {
                        ok = false;
                        break;
                    }
                }
                if (ok)
                {
                    if (CheckGTINKey(code.Substring(2, 14)))
                    {
                        result = "GS1-128";
                    }
                }
            }
            else if ((length >= 16) && (code.StartsWith("02")))
            {
                bool ok = true;
                char[] array = code.ToCharArray();
                for (int i = 2; i < 16; i++)
                {
                    if (!NumericChar(array[i]))
                    {
                        ok = false;
                        break;
                    }
                }
                if (ok)
                {
                    if (CheckGTINKey(code.Substring(2, 14)))
                    {
                        result = "GS1-128";
                    }
                }
            }

            //else if ((length >= 10) && code.StartsWith("11"))
            //{
            //    if ((code.Substring(8, 2).Equals("17")) & (length >= 16))
            //        if ((code.Substring(16, 2).Equals("10")) & (length >= 18))
            //            result = "GS1-128";
            //}
            // This conditions is not enough strong
            //else if (code.StartsWith("17") & (length >= 11))
            //{
            //  string ai2 = code.Substring(8, 2);
            //  if ((ai2 == "10") | (ai2 == "30") | (ai2 == "21"))
            //    result = "GS1-128";
            //}

            // This conditions is not enough strong
            //else if (code.StartsWith("20") & (length >= 6))
            //{
            //  string ai2 = code.Substring(4, 2);
            //  if (ai2 == "17")
            //    result = "GS1-128";
            //}

            //else if ((code.StartsWith("240") & (length >= 4)))
            //{
            //  result = "GS1-128";
            //}
            else if (containsGS(code))
            {
                result = "GS1-128";
                // int testposition = indexOfBL(code, 0);
            }
            return result;
        }

        private static string getGStype(string code)
        {
            string result = "Not";
            string GS = ((char)0x001d).ToString();
            if (code.Contains(GS))
                result = "GS";
            else if (code.Contains("@"))
                result = "@";
            return result;
        }

        private static int indexOfGS(string code, int start)
        {
            int result = -1;
            string GSchar = getGStype(code);
            if (GSchar == "GS")
            {
                string GS = ((char)0x001d).ToString();
                result = code.IndexOf(GS, start);
            }
            else if (GSchar == "@")
                result = code.IndexOf("@", start);
            return result;
        }

        private static bool containsGS(string code)
        {
            bool result = false;
            string temp = getGStype(code);
            if (temp != "Not")
                result = true;
            return result;
        }

        private static int indexOfASD(string code, int start)
        {
            int result = -1;
            Regex reg = new Regex(hibcASDlist);
            Match m = reg.Match(code);
            if (m.Success)
            {
                result = m.Index;
            }
            return result;
        }
        private static bool containsASD(string secondaryData) //Additional Supplemental Data
        {
            bool result = false;
            if (indexOfASD(secondaryData, 0) != -1)
            {
                result = true;
            }
            return result;
        }

        private static bool containsASD_old(string secondaryData) //Additional Supplemental Data
        {
            bool result = false;
            if (secondaryData.Contains("/") && (secondaryData.IndexOf("/") < secondaryData.Length - 2))
            {
                if (secondaryData.Contains("/14D") |
                    secondaryData.Contains("/16D") |
                    secondaryData.Contains("/S"))
                {
                    result = true;
                }
            }
            return result;
        }

        public string UDI(string code)
        {
            string result = "";
            string type = Type(code);
            string subType = SubType(code, type);
            result = UDI(code, type, subType);
            return result;
        }


        public string UDI(string code, string type, string subType)
        {
            string result = "";
            code = Cleanse(code);
            if (type == "HIBC")
            {
                if (subType.Contains("Primary"))
                {
                    result = UPN(code, type, subType);
                }
            }
            else if (type.Contains("GS1-"))
            {
                result = GTIN(code, type, subType);
            }
            return result;
        }

        public string UoM(string code)
        {
            string result = "";
            string type = Type(code);
            string subType = SubType(code, type);
            result = UoM(code, type, subType);
            return result;
        }

        public string UoM(string code, string type, string subType)
        {
            string result = "";
            code = Cleanse(code);
            if (type == "HIBC")
            {
                code = CleanSymbologyId(code);
                if (subType == "Primary")
                    result = code.Substring(code.Length - 2, 1);
                else if (subType.StartsWith("Primary/Secondary"))
                    result = code.Substring(code.IndexOf("/") - 1, 1);
            }
            return result;
        }

        public string SubType(string code)
        {
            string type = Type(code);
            string result = SubType(code, type);
            return result;
        }


        public string SubType(string code, string type)
        {
            code = Cleanse(code);
            code = CleanSymbologyId(code);
            string result = "NaS";
            string ai2 = "";
            string ai3 = "";
            int length = code.Length;

            // Start EAN 13
            if (type == "EAN 13")
            {
                if (code.Substring(0, 4) == "3401")
                    result = "ACL 13";
                else if (code.Substring(0, 4) == "3400")
                    result = "CIP 13";
                else
                    result = "";
            }
            // End EAN 13
            //
            // Start HIBC
            else if (type == "HIBC")
            {
                char[] array = code.ToCharArray();
                if (length >= 8)
                {
                    if (Alphabetic(array[1])) //...with the first character always being alphabetic.
                    {
                        result = "Primary";
                        int position = code.IndexOf('/');
                        if ((position != -1) & (position != code.Length - 1))
                        {
                            result = result + @"/Secondary";
                            array = code.Substring(position).ToCharArray();
                        }
                    }
                    else // 
                    {
                        result = "Secondary";
                    }
                    if (result.EndsWith("Secondary") & (array.Length > 0))
                    {
                        if (NumericChar(array[1]))
                            result = result + ".N";
                        else if (array[1] == '$')
                        {
                            result = result + ".$";
                            if (array[2] == '$')
                            {
                                result = result + "$";
                                char c1 = array[3];
                                if (
                                  (c1 == '2') |
                                  (c1 == '3') |
                                  (c1 == '4') |
                                  (c1 == '5') |
                                  (c1 == '6') |
                                  (c1 == '7'))
                                {
                                    result = result + "." + c1;
                                }
                                else if (
                                  (c1 == '8') |
                                  (c1 == '9'))
                                {
                                    result = result + "." + c1;
                                    if (c1 == '8')
                                    {
                                        if (length > 8)
                                        {
                                            char c2 = array[6];
                                            if (
                                              (c2 == '2') |
                                              (c2 == '3') |
                                              (c2 == '4') |
                                              (c2 == '5') |
                                              (c2 == '6') |
                                              (c2 == '7'))
                                            {
                                                result = result + "." + c2;
                                            }
                                        }
                                    }
                                    if (c1 == '9')
                                    {
                                        if (length > 11)
                                        {
                                            char c2 = array[9];
                                            if (
                                              (c2 == '2') |
                                              (c2 == '3') |
                                              (c2 == '4') |
                                              (c2 == '5') |
                                              (c2 == '6') |
                                              (c2 == '7'))
                                            {
                                                result = result + "." + c2;
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        string secondaryData = String.Join("", array);//.Substring(1); 

                        if (containsASD(secondaryData))
                        {
                            //There is at least a supplementary data!
                            int nextDI = 0;
                            for (int i = 0; i < secondaryData.Length; i++)
                            {
                                nextDI = secondaryData.IndexOf("/", nextDI + i);
                                if ((nextDI != -1) & (nextDI + 1 != secondaryData.Length))
                                {
                                    if (secondaryData.Substring(nextDI, 4) == "/14D")
                                    {
                                        result = result + ".14D";
                                    }

                                    else if (secondaryData.Substring(nextDI, 4) == "/16D")
                                    {
                                        result = result + ".16D";
                                    }
                                    else if (secondaryData.Substring(nextDI, 2) == "/S")
                                    {
                                        result = result + ".S";
                                    }
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            // End HIBC
            //
            //Start GS1-128
            else if (type.StartsWith("GS1-"))
            {
                // Starting here analyse using a GS1-128 code without special characters
                ai2 = code.Substring(0, 2);
                ai3 = code.Substring(0, 3);
                if (ai2 == "00")
                {
                    result = "00"; //00
                }
                else if (ai2 == "01")
                {
                    result = "01"; //01
                    if (length > 19)
                    {
                        ai2 = code.Substring(16, 2);
                        ai3 = code.Substring(16, 3);
                        if (ai2 == "10")
                        {
                            result = result + ".10";
                        }
                        else if (ai2 == "11")
                        {
                            result = result + ".11"; //01.11
                            if (length > 25)
                            {
                                ai2 = code.Substring(24, 2);
                                if (ai2 == "17")
                                {
                                    result = result + ".17"; //01.11.17
                                    if (length >= 34)
                                    {
                                        ai2 = code.Substring(32, 2);
                                        if (ai2 == "10")
                                        {
                                            result = result + ".10"; //01.11.17.10
                                        }
                                        if (ai2 == "21")
                                        {
                                            result = result + ".21"; //01.11.17.21
                                        }
                                    }
                                }
                            }
                        }
                        else if (ai2 == "15")
                        {
                            result = result + ".15"; //01.15
                            if (length >= 26)
                            {
                                ai2 = code.Substring(24, 2);
                                if (ai2 == "10")
                                {
                                    result = result + ".10"; //01.15.10
                                }
                            }
                        }
                        else if (ai2 == "17")
                        {
                            result = result + ".17"; //01.17
                            if (length > 24)
                            {
                                ai2 = code.Substring(24, 2);
                                if (ai2 == "10")
                                {
                                    result = result + ".10"; //01.17.10
                                }
                                else if (ai2 == "21")
                                {
                                    result = result + ".21"; //01.17.21
                                }
                                else if (ai2 == "30")
                                {
                                    result = result + ".30"; //01.17.30
                                }
                            }
                        }

                        else if (ai3 == "240")
                        {
                            result = result + ".240"; // 01.240
                        }
                        else if (ai2 == "30")
                        {
                            result = result + ".30"; //01.30
                        }
                    }
                }
                else if (ai2 == "02")
                {
                    result = "02"; //02
                    if (length >= 18)
                    {
                        ai2 = code.Substring(16, 2);
                        if (ai2 == "10")
                        {
                            result = result + ".10"; //02.10
                        }
                        else if (ai2 == "17")
                        {
                            result = result + ".17"; //02.17
                            if (length >= 27)
                            {
                                ai2 = code.Substring(24, 2);
                                if (ai2 == "37")
                                {
                                    result = result + ".37"; //02.17.37
                                }
                            }
                        }
                        else if (ai2 == "37")
                        {
                            result = result + ".37"; //02.37
                        }
                    }
                }
                else if (ai2 == "10")
                {
                    result = "10"; //10
                }
                else if (ai2 == "11")
                {
                    result = "11"; //11
                    if (length > 9)
                    {
                        ai2 = code.Substring(8, 2);
                        if (ai2 == "17")
                        {
                            result = result + ".17"; //11.17
                            if (length >= 15)
                            {
                                ai2 = code.Substring(13, 2);
                                if (ai2 == "10")
                                {
                                    result = result + ".10"; //11.17.10
                                }
                            }
                        }
                    }
                }
                else if (ai2 == "17")
                {
                    result = "17"; //17
                    if (length > 9)
                    {
                        ai2 = code.Substring(8, 2);
                        if (ai2 == "10")
                        {
                            result = result + ".10"; //17.10
                        }
                        if (ai2 == "21")
                        {
                            result = result + ".21"; //17.21
                        }
                        else if (ai2 == "30")
                        {
                            result = result + ".30"; //17.30
                        }
                    }
                }
                else if (ai2 == "20")
                {
                    result = "20"; //20
                    if (length > 6)
                    {
                        ai2 = code.Substring(4, 2);
                        if (ai2 == "17")
                        {
                            result = result + ".17"; //20.17
                            if (length >= 13)
                            {
                                ai2 = code.Substring(12, 2); //TODO MB Controler Longueur code Longueur testée à >=13
                                if (ai2 == "10")
                                {
                                    result = result + ".10"; //20.17.10
                                }
                            }
                        }
                    }
                }
                else if (ai2 == "22")
                {
                    result = "22"; //22
                }
                else if (ai3 == "240")
                {
                    result = "240";
                }
                else if (ai2 == "91")
                {
                    result = "91"; //91
                }

                if (containsGS(code))
                {
                    // Starting here analyse using a GS1-128 code with special characters
                    int nextGS = -1;
                    if (result == "01.10")
                    {
                        nextGS = indexOfGS(code, 18);
                        ai2 = code.Substring(nextGS + 1, 2);
                        if (ai2 == "17")
                        {
                            result = result + ".17"; //01.10.17
                            if (length >= nextGS + 11)
                            {
                                ai2 = code.Substring(nextGS + 9, 2);
                                if (ai2 == "21")
                                {
                                    result = result + ".21"; //01.10.17.21
                                }
                                else if (ai2 == "30")
                                {
                                    result = result + ".30"; //01.10.17.30
                                }
                            }
                        }
                    }
                    else if (result == "01.17.10")
                    {
                        nextGS = indexOfGS(code, 24);
                        if (length >= nextGS + 4)
                        {
                            ai2 = code.Substring(nextGS + 1, 2);
                            ai3 = code.Substring(nextGS + 1, 3);
                            if (ai3 == "240")
                            {
                                result = result + ".240"; //01.17.10.240
                            }
                            else if (ai2 == "30")
                            {
                                result = result + ".30"; //01.17.10.30
                            }
                            else if (ai2 == "91")
                            {
                                result = result + ".91";
                            }
                            else if (ai2 == "93")
                            {
                                result = result + ".93";
                            }
                        }
                    }
                    else if (result == "01.17.30")
                    {
                        nextGS = indexOfGS(code, 18);
                        if (length >= nextGS + 3)
                        {
                            ai2 = code.Substring(nextGS + 1, 2);
                            if (ai2 == "10")
                            {
                                result = result + ".10";
                            }
                        }
                    }

                    else if (result == "02.10")
                    {
                        nextGS = indexOfGS(code, 16);
                        if (length >= nextGS + 3)
                        {
                            ai2 = code.Substring(nextGS + 1, 2);
                            if (ai2 == "37")
                            {
                                result = result + ".37"; //02.10.37
                            }
                        }
                    }

                    else if (result == "02.17.37")
                    {
                        nextGS = indexOfGS(code, 18);
                        if (length >= nextGS + 3)
                        {
                            ai2 = code.Substring(nextGS + 1, 2);
                            if (ai2 == "10")
                            {
                                result = result + ".10";
                            }
                        }
                    }

                    else if (result == "02.37")
                    {
                        nextGS = indexOfGS(code, 18);
                        if (length >= nextGS + 3)
                        {
                            ai2 = code.Substring(nextGS + 1, 2);
                            if (ai2 == "10")
                            {
                                result = result + ".10";
                            }
                        }
                    }
                    else if (result == "10")
                    {
                        nextGS = indexOfGS(code, 0);
                        ai2 = code.Substring(nextGS + 1, 2);
                        if (ai2 == "11")
                        {
                            result = result + ".11"; //10.11
                            if (length >= nextGS + 11)
                            {
                                ai2 = code.Substring(nextGS + 9, 2);
                                if (ai2 == "17")
                                {
                                    result = result + ".17"; //10.11.17
                                    if (length >= nextGS + 9 + 8 + 2)
                                    {
                                        ai2 = code.Substring(nextGS + 9 + 8, 2);
                                        result = result + ".30"; //10.11.17.30
                                    }
                                }
                            }

                        }
                        else if (ai2 == "17")
                        {
                            result = result + ".17"; //10.17
                            if (code.Length > nextGS + 12)
                            {
                                ai2 = code.Substring(nextGS + 9, 2);
                                if (ai2 == "30")
                                {
                                    result = result + ".30"; //10.17.30
                                }
                            }
                        }
                        else if (ai2 == "21")
                        {
                            result = result + ".21"; //10.21
                        }
                    }
                    else if (result == "17.10")
                    {
                        nextGS = indexOfGS(code, 8);
                        ai2 = code.Substring(nextGS + 1, 2);
                        if (ai2 == "30")
                        {
                            result = result + ".30"; //17.10.30
                        }
                        else if (ai2 == "91")
                        {
                            result = result + ".91"; //17.10.91
                        }
                    }
                    else if (result == "17.30")
                    {
                        nextGS = indexOfGS(code, 0);
                        if (length >= nextGS + 3)
                        {
                            ai2 = code.Substring(nextGS + 1, 2);
                            if (ai2 == "10")
                            {
                                result = result + ".10";
                            }
                        }
                    }
                    else if (result == "240")
                    {
                        nextGS = indexOfGS(code, 1);
                        if (length >= nextGS + 3)
                        {
                            ai2 = code.Substring(nextGS + 1, 2);
                            if (ai2 == "21")
                            {
                                result = result + ".21"; //240.21
                                nextGS = indexOfGS(code, nextGS + 1);
                                if (nextGS != -1)
                                {
                                    if (length >= nextGS + 3)
                                    {
                                        ai2 = code.Substring(nextGS + 1, 2);
                                        if (ai2 == "30")
                                        {
                                            result = result + ".30"; //240.21.30
                                            nextGS = indexOfGS(code, nextGS + 1);
                                            if (nextGS != -1)
                                            {
                                                if (length >= nextGS + 3)
                                                {
                                                    ai2 = code.Substring(nextGS + 1, 2);
                                                    if (ai2 == "10")
                                                    {
                                                        result = result + ".10"; //240.21.30.10
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else if (result == "91")
                    {
                        nextGS = indexOfGS(code, 1);
                        if (length >= nextGS + 3)
                        {
                            ai2 = code.Substring(nextGS + 1, 2);
                            if (ai2 == "17")
                            {
                                result = result + ".17"; //91.17
                                if (code.Length > nextGS + 3)
                                {
                                    int shift = nextGS + 9;
                                    if (length >= shift + 2)
                                    {
                                        ai2 = code.Substring(shift, 2);
                                        if (ai2 == "10")
                                        {
                                            result = result + ".10"; //91.17.10
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            // End GS1-128
            //
            // Start NaS
            else if (type == "NaS")
            {
                if (code.Length == 7)
                    if (Check7Car(code))
                    {
                        result = "NaS7";
                    }

                if (code.Length == 19)
                {
                    string subLeftCode = code.Substring(0, 13);
                    if (CheckEan13Key(subLeftCode))
                        result = "001"; // EAN 13 and LPP without checksum
                }

                if (code.Length == 20)
                {
                    string subLeftCode = code.Substring(0, 13);
                    string subRightCode = code.Substring(13, 7);
                    if (CheckEan13Key(subLeftCode) & Check7Car(subRightCode) & code.StartsWith("3401"))
                        result = "002"; // ACL 13 and LPP
                }

                if (code.Length == 21)
                {
                    string subLeftCode = code.Substring(0, 13);
                    string subRightCode = code.Substring(14, 7);
                    if (CheckEan13Key(subLeftCode) & Check7Car(subRightCode) & code.StartsWith("3401"))
                        result = "003"; // ACL 13 and LPP with Espace
                }

                if (code.Length == 20)
                {
                    string subLeftCode = code.Substring(0, 13);
                    string subRightCode = code.Substring(13, 7);
                    if (CheckEan13Key(subLeftCode) & Check7Car(subRightCode) & !code.StartsWith("3401"))
                        result = "004"; // EAN 13 and LPP
                }

                if (code.Length == 28)
                {
                    if ((code.Substring(20, 1) == " ") & (code.Substring(25, 1) == "-"))
                    {
                        result = "005"; // Chris Eyes Company (Example: ASK +20.0 1102745059 2016-05)
                    }
                }

                if (code.Length == 17)
                {
                    string maybeLot = code.Substring(11, 6);
                    bool ok = NumericString(maybeLot);
                    if ((ok) & (code.Substring(10, 1) == " "))
                    {
                        result = "006"; // COUSIN BIOSERV Company (Example: FBIOW8D160 102223)
                    }
                }


                if (code.Length == 22)
                {
                    string maybeRef = code.Substring(0, 8);
                    string maybeExpiry = code.Substring(16, 6);
                    string maybeLot = code.Substring(8, 8);
                    bool ok1 = NumericString(maybeRef);
                    bool ok2 = NumericString(maybeExpiry);
                    bool ok3 = !NumericString(maybeLot);
                    if (ok1 & ok2 & ok3)
                        result = "007"; // BARD France Company (Example: 58562152ANTL0294122012)
                }

                // Obsolete
                //if (code.Length == 28)
                //{
                //    bool ok = NumericString(code);
                //    if (ok)
                //        result = "008"; // PHYSIOL France Company (Example: 2808123005365310060911306301)
                //}                                                   //  28081230 053653 10060911306301

                if (code.Length >= 8)
                {
                    if (!NumericString(code) & (code.Substring(0, 4) == "PAR-"))
                        result = "009"; //  Arthrex Company (Example: PAR-1234-AB)
                }

                if (code.Length == 7)
                {
                    if (NumericString(code.Substring(1, 6)) & (code.Substring(0, 1) == "T"))
                        result = "010"; //  Arthrex Company (Example: T123456)
                }

                // Obsolete
                //if (code.Length == 2)
                //{
                //    if (NumericString(code.Substring(1, 1)) & (code.Substring(0, 1) == "Q"))
                //        result = "011"; //  Arthrex Company (Example: Q1)
                //}

                // Obsolete
                //if (code.Length > 10)
                //{
                //  if (NumericString(code.Substring(3, 6)) & (code.Substring(0, 3) == "SEM") & (code.Substring(9, 1) == "^"))
                //    result = "012"; //  SEM (Sciences Et Medecine) Company (Example: SEM171252^P30778E4009A)
                //}

                if (code.Length > 10)
                {
                    if ((code.Substring(0, 3) == "SEM") & (code.Substring(9, 2) == "^P") & (Regex.IsMatch(code.Substring(code.Length - 1, 1), @"^[a-zA-Z]+$")))
                        result = "012"; //  SEM (Sciences Et Medecine) Company (Example: SEM171252^P30778E4009A)
                }

                if (code.Length == 14)
                {
                    if (NumericString(code.Substring(6, 8)) & (code.Substring(0, 1) == " ") & (code.Substring(5, 1) == "-"))
                        result = "013"; //   ABS BOLTON Company (Example:  BF01-11018180)
                }

                if (code.Length == 10)
                {
                    if (NumericString(code.Substring(5, 5)) & (code.Substring(0, 5) == "CPDR "))
                        result = "014"; //   CHIRURGIE OUEST / EUROSILICONE / SORMED Company (Example: CPDR 24602)
                }
                if (code.Length == 17)
                {
                    if ((code.Substring(4, 1) == "-") & (code.Substring(15, 1) == "-"))
                        result = "015"; // Symbios Orthopédie (Example: H080-25.01.2014-1)
                }
                if (code.Length == 24)
                {
                    if (NumericString(code.Substring(18, 6)))
                        result = "016"; // Teleflex / Arrow (Example : ]C0FR04052CFZF3015237141231)
                }
                if (code.Length == 14)
                {
                    if (NumericString(code.Substring(0, 9)) & (code.Substring(10, 1) == " "))
                        result = "017"; // FCI (Example : ]C01401788197 001)
                }
            }
            // End NaS
            return result;
        }
    }
}
