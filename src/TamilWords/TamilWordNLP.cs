///
/// Some part of code is inspired by open-tamil Python project
/// https://github.com/Ezhil-Language-Foundation/open-tamil
///

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using WPEntities.Noolkal.Entities;

namespace TamilWords
{


    public partial class TamilWordNLP
    {
        List<string> tamilWords = new List<string>();
        List<string> taEncryptedLetters = new List<string>();

       
        // constants;
        int TA_ACCENT_LEN = 13;
        //12 + 1;
        int TA_AYUDHA_LEN = 1;
        int TA_UYIR_LEN = 12;
        int TA_MEI_LEN = 18;
        int TA_AGARAM_LEN = 18;
        int TA_SANSKRIT_LEN = 6;
        int TA_UYIRMEI_LEN = 216;
        int TA_GRANTHA_UYIRMEI_LEN = 24 * 12;
        int TA_LETTERS_LEN = 0;
        //int TA_LETTERS_LEN = 247 + 6 * 12 + 22 + 4 - TA_AGARAM_LEN - 4;

        List<string> uyir_letters = new List<string>() { "அ", "ஆ", "இ", "ஈ", "உ", "ஊ", "எ", "ஏ", "ஐ", "ஒ", "ஓ", "ஔ" };

        public List<string> Uyir_letters
        {
            get { return uyir_letters; }
            set { uyir_letters = value; }
        }


        string ayudha_letter = "ஃ";
        List<string> kuril_letters = new List<string>() { "அ", "இ", "உ", "எ", "ஒ" };
        List<string> nedil_letters = new List<string>() { "ஆ", "ஈ", "ஊ", "ஏ", "ஓ" };
        List<string> vallinam_letters = new List<string>() { "க்", "ச்", "ட்", "த்", "ப்", "ற்" };
        List<string> mellinam_letters = new List<string>() { "ங்", "ஞ்", "ண்", "ந்", "ம்", "ன்" };
        List<string> idayinam_letters = new List<string>() { "ய்", "ர்", "ல்", "வ்", "ழ்", "ள்" };
        List<string> mei_letters = new List<string>(){"க்","ச்","ட்","த்","ப்","ற்",
           "ஞ்","ங்","ண்","ந்","ம்","ன்",
           "ய்","ர்","ல்","வ்","ழ்","ள்" };
        List<string> wordOttuSorkal = new List<string>() { "களில்", };

        List<string> accent_symbols = new List<string>(){"","ா","ி","ீ","ு","ூ",
          "ெ","ே","ை","ொ","ோ","ௌ","ஃ"};
        List<string> pulli_symbols = new List<string>() { "்" };
        List<string> agaram_letters = new List<string>(){"க","ச","ட","த","ப","ற",
          "ஞ","ங","ண","ந","ம","ன",
          "ய","ர","ல","வ","ழ","ள"};

        public List<string> Agaram_letters
        {
            get { return agaram_letters; }
            set { agaram_letters = value; }
        }
        List<string> sanskrit_letters = new List<string>() { "ஶ", "ஜ", "ஷ", "ஸ", "ஹ", "க்ஷ" };
        List<string> sanskrit_mei_letters = new List<string>() { "ஶ்", "ஜ்", "ஷ்", "ஸ்", "ஹ்", "க்ஷ்" };


        List<string> uyirmei_letters = new List<string>(){
"க"  ,"கா"  ,"கி"  ,"கீ"  ,"கு"  ,"கூ"  ,"கெ"  ,"கே"  ,"கை"  ,"கொ"  ,"கோ"  ,"கௌ"  ,
"ச"  ,"சா"  ,"சி"  ,"சீ"  ,"சு"  ,"சூ"  ,"செ"  ,"சே"  ,"சை"  ,"சொ"  ,"சோ"  ,"சௌ" ,
"ட"  ,"டா"  ,"டி"  ,"டீ"  ,"டு"  ,"டூ"  ,"டெ"  ,"டே"  ,"டை"  ,"டொ"  ,"டோ"  ,"டௌ",
"த"  ,"தா"  ,"தி"  ,"தீ"  ,"து"  ,"தூ"  ,"தெ"  ,"தே"  ,"தை"  ,"தொ"  ,"தோ"  ,"தௌ",
"ப"  ,"பா"  ,"பி"  ,"பீ"  ,"பு"  ,"பூ"  ,"பெ"  ,"பே"  ,"பை"  ,"பொ"  ,"போ"  ,"பௌ" ,
"ற"  ,"றா"  ,"றி"  ,"றீ"  ,"று"  ,"றூ"  ,"றெ"  ,"றே"  ,"றை"  ,"றொ"  ,"றோ"  ,"றௌ",
"ஞ"  ,"ஞா"  ,"ஞி"  ,"ஞீ"  ,"ஞு"  ,"ஞூ"  ,"ஞெ"  ,"ஞே"  ,"ஞை"  ,"ஞொ"  ,"ஞோ"  ,"ஞௌ"  ,
"ங"  ,"ஙா"  ,"ஙி"  ,"ஙீ"  ,"ஙு"  ,"ஙூ"  ,"ஙெ"  ,"ஙே"  ,"ஙை"  ,"ஙொ"  ,"ஙோ"  ,"ஙௌ"  ,
"ண"  ,"ணா"  ,"ணி"  ,"ணீ"  ,"ணு"  ,"ணூ"  ,"ணெ"  ,"ணே"  ,"ணை"  ,"ணொ"  ,"ணோ"  ,"ணௌ"  ,
"ந"  ,"நா"  ,"நி"  ,"நீ"  ,"நு"  ,"நூ"  ,"நெ"  ,"நே"  ,"நை"  ,"நொ"  ,"நோ"  ,"நௌ"  ,
"ம"  ,"மா"  ,"மி"  ,"மீ"  ,"மு"  ,"மூ"  ,"மெ"  ,"மே"  ,"மை"  ,"மொ"  ,"மோ"  ,"மௌ" ,
"ன"  ,"னா"  ,"னி"  ,"னீ"  ,"னு"  ,"னூ"  ,"னெ"  ,"னே"  ,"னை"  ,"னொ"  ,"னோ"  ,"னௌ",
"ய"  ,"யா"  ,"யி"  ,"யீ"  ,"யு"  ,"யூ"  ,"யெ"  ,"யே"  ,"யை"  ,"யொ"  ,"யோ"  ,"யௌ",
"ர"  ,"ரா"  ,"ரி"  ,"ரீ"  ,"ரு"  ,"ரூ"  ,"ரெ"  ,"ரே"  ,"ரை"  ,"ரொ"  ,"ரோ"  ,"ரௌ",
"ல"  ,"லா"  ,"லி"  ,"லீ"  ,"லு"  ,"லூ"  ,"லெ"  ,"லே"  ,"லை"  ,"லொ"  ,"லோ"  ,"லௌ" ,
"வ"  ,"வா"  ,"வி"  ,"வீ"  ,"வு"  ,"வூ"  ,"வெ"  ,"வே"  ,"வை"  ,"வொ"  ,"வோ"  ,"வௌ" ,
"ழ"  ,"ழா"  ,"ழி"  ,"ழீ"  ,"ழு"  ,"ழூ"  ,"ழெ"  ,"ழே"  ,"ழை"  ,"ழொ"  ,"ழோ"  ,"ழௌ" ,
"ள"  ,"ளா"  ,"ளி"  ,"ளீ"  ,"ளு"  ,"ளூ"  ,"ளெ"  ,"ளே"  ,"ளை"  ,"ளொ"  ,"ளோ"  ,"ளௌ" };
        // Ref: https:;
        //en.wikipedia.org/wiki/Tamil_numerals;
        // tamil digits : Apart from the numerals (0-9), Tamil also has numerals for 10, 100 and 1000.;
        List<string> tamil_digit_1to10 = new List<string>() { "௦", "௧", "௨", "௩", "௪", "௫", "௬", "௭", "௮", "௯", "௰" };
        string tamil_digit_100 = "௱";
        string tamil_digit_1000 = "௲";
        // tamil symbols;
        string _day = "௳";
        string _month = "௴";
        string _year = "௵";
        string _debit = "௶";
        string _credit = "௷";
        string _rupee = "௹";
        string _numeral = "௺";
        string _sri = "\u0bb6\u0bcd\u0bb0\u0bc0";
        //SRI - ஶ்ரீ;
        string _ksha = "\u0b95\u0bcd\u0bb7";
        //KSHA - க்ஷ;
        string _ksh = "\u0b95\u0bcd\u0bb7\u0bcd";
        //KSH - க்ஷ்;
        List<string> tamil_symbols = new List<string>();//{ _day, _month, _year, _debit, _credit, _rupee, _numeral, _sri, _ksha, _ksh };
        // total tamil letters in use, including sanskrit letters;
        List<string> tamil_letters = new List<string>(){
// /* Uyir */;
"அ","ஆ","இ", "ஈ","உ","ஊ","எ","ஏ","ஐ","ஒ","ஓ","ஔ",
///* Ayuda Ezhuthu */;
"ஃ",
// /* Mei */;
"க்","ச்","ட்","த்","ப்","ற்","ஞ்","ங்","ண்","ந்","ம்","ன்","ய்","ர்","ல்","வ்","ழ்","ள்",
// /* Agaram */;
// "க","ச","ட","த","ப","ற","ஞ","ங","ண","ந","ம","ன","ய","ர","ல","வ","ழ","ள",
// /* Sanskrit (Vada Mozhi) */;
// "ஜ","ஷ", "ஸ","ஹ",
///* Sanskrit (Mei) */;
"ஜ்","ஷ்", "ஸ்","ஹ்",
// /* Uyir Mei */;
"க"  ,"கா"  ,"கி"  ,"கீ"  ,"கு"  ,"கூ"  ,"கெ"  ,"கே"  ,"கை"  ,"கொ"  ,"கோ"  ,"கௌ"
,"ச"  ,"சா"  ,"சி"  ,"சீ"  ,"சு"  ,"சூ"  ,"செ"  ,"சே"  ,"சை"  ,"சொ"  ,"சோ"  ,"சௌ"
,"ட"  ,"டா"  ,"டி"  ,"டீ"  ,"டு"  ,"டூ"  ,"டெ"  ,"டே"  ,"டை"  ,"டொ"  ,"டோ"  ,"டௌ"
,"த"  ,"தா"  ,"தி"  ,"தீ"  ,"து"  ,"தூ"  ,"தெ"  ,"தே"  ,"தை"  ,"தொ"  ,"தோ"  ,"தௌ"
,"ப"  ,"பா"  ,"பி"  ,"பீ"  ,"பு"  ,"பூ"  ,"பெ"  ,"பே"  ,"பை"  ,"பொ"  ,"போ"  ,"பௌ"
,"ற"  ,"றா"  ,"றி"  ,"றீ"  ,"று"  ,"றூ"  ,"றெ"  ,"றே"  ,"றை"  ,"றொ"  ,"றோ"  ,"றௌ"
,"ஞ"  ,"ஞா"  ,"ஞி"  ,"ஞீ"  ,"ஞு"  ,"ஞூ"  ,"ஞெ"  ,"ஞே"  ,"ஞை"  ,"ஞொ"  ,"ஞோ"  ,"ஞௌ"
,"ங"  ,"ஙா"  ,"ஙி"  ,"ஙீ"  ,"ஙு"  ,"ஙூ"  ,"ஙெ"  ,"ஙே"  ,"ஙை"  ,"ஙொ"  ,"ஙோ"  ,"ஙௌ"
,"ண"  ,"ணா"  ,"ணி"  ,"ணீ"  ,"ணு"  ,"ணூ"  ,"ணெ"  ,"ணே"  ,"ணை"  ,"ணொ"  ,"ணோ"  ,"ணௌ"
,"ந"  ,"நா"  ,"நி"  ,"நீ"  ,"நு"  ,"நூ"  ,"நெ"  ,"நே"  ,"நை"  ,"நொ"  ,"நோ"  ,"நௌ"
,"ம"  ,"மா"  ,"மி"  ,"மீ"  ,"மு"  ,"மூ"  ,"மெ"  ,"மே"  ,"மை"  ,"மொ"  ,"மோ"  ,"மௌ"
,"ன"  ,"னா"  ,"னி"  ,"னீ"  ,"னு"  ,"னூ"  ,"னெ"  ,"னே"  ,"னை"  ,"னொ"  ,"னோ"  ,"னௌ"
,"ய"  ,"யா"  ,"யி"  ,"யீ"  ,"யு"  ,"யூ"  ,"யெ"  ,"யே"  ,"யை"  ,"யொ"  ,"யோ"  ,"யௌ"
,"ர"  ,"ரா"  ,"ரி"  ,"ரீ"  ,"ரு"  ,"ரூ"  ,"ரெ"  ,"ரே"  ,"ரை"  ,"ரொ"  ,"ரோ"  ,"ரௌ"
,"ல"  ,"லா"  ,"லி"  ,"லீ"  ,"லு"  ,"லூ"  ,"லெ"  ,"லே"  ,"லை"  ,"லொ"  ,"லோ"  ,"லௌ"
,"வ"  ,"வா"  ,"வி"  ,"வீ"  ,"வு"  ,"வூ"  ,"வெ"  ,"வே"  ,"வை"  ,"வொ"  ,"வோ"  ,"வௌ"
,"ழ"  ,"ழா"  ,"ழி"  ,"ழீ"  ,"ழு"  ,"ழூ"  ,"ழெ"  ,"ழே"  ,"ழை"  ,"ழொ"  ,"ழோ"  ,"ழௌ"
,"ள"  ,"ளா"  ,"ளி"  ,"ளீ"  ,"ளு"  ,"ளூ"  ,"ளெ"  ,"ளே"  ,"ளை"  ,"ளொ"  ,"ளோ"  ,"ளௌ"
///* Sanskrit Uyir-Mei */;
,"ஶ", 	"ஶா", 	"ஶி", 	"ஶீ", "ஶு", "ஶூ", "ஶெ", "ஶே", "ஶை", "ஶொ", "ஶோ", "ஶௌ"
,"ஜ"  ,"ஜா"  ,"ஜி"  ,"ஜீ"  ,"ஜு"  ,"ஜூ"  ,"ஜெ"  ,"ஜே"  ,"ஜை"  ,"ஜொ"  ,"ஜோ"  ,"ஜௌ"
,"ஷ"  ,"ஷா"  ,"ஷி"  ,"ஷீ"  ,"ஷு"  ,"ஷூ"  ,"ஷெ"  ,"ஷே"  ,"ஷை"  ,"ஷொ"  ,"ஷோ"  ,"ஷௌ"
,"ஸ"  ,"ஸா"  ,"ஸி"  ,"ஸீ"  ,"ஸு"  ,"ஸூ"  ,"ஸெ"  ,"ஸே"  ,"ஸை"  ,"ஸொ"  ,"ஸோ"  ,"ஸௌ"
,"ஹ"  ,"ஹா"  ,"ஹி"  ,"ஹீ"  ,"ஹு"  ,"ஹூ"  ,"ஹெ"  ,"ஹே"  ,"ஹை"  ,"ஹொ"  ,"ஹோ"  ,"ஹௌ"
,"க்ஷ"  ,"க்ஷா"  ,"க்ஷி" 	,"க்ஷீ" 	,"க்ஷு"  ,"க்ஷூ"  ,"க்ஷெ"   ,"க்ஷே" ,"க்ஷை"  ,"க்ஷொ" ,"க்ஷோ"  ,"க்ஷௌ",
"ஸ்ரீ" };
        List<string> muthal_letters = new List<string>() {"அ",
"ஆ",
"இ",
"ஈ",
"உ",
"ஊ",
"எ",
"ஏ",
"ஐ",
"ஒ",
"ஓ",
"ஔ",
"க",
"கா",
"கி",
"கீ",
"கு",
"கூ",
"கெ",
"கே",
"கை",
"கொ",
"கோ",
"கௌ",
"ங",
"ச",
"சா",
"சி",
"சீ",
"சு",
"சூ",
"செ",
"சே",
"சை",
"சொ",
"சோ",
"சௌ",
"ஞ",
"ஞா",
"ஞெ",
"ஞொ",
"த",
"தா",
"தி",
"தீ",
"து",
"தூ",
"தெ",
"தே",
"தை",
"தொ",
"தோ",
"தௌ",
"ந",
"நா",
"நி",
"நீ",
"நு",
"நூ",
"நெ",
"நே",
"நை",
"நொ",
"நோ",
"நௌ",
"ப",
"பா",
"பி",
"பீ",
"பு",
"பூ",
"பெ",
"பே",
"பை",
"பொ",
"போ",
"பௌ",
"ம",
"மா",
"மி",
"மீ",
"மு",
"மூ",
"மெ",
"மே",
"மை",
"மொ",
"மோ",
"மௌ",
"ய",
"யா",
"யு",
"யூ",
"யோ",
"யௌ",
"வ",
"வா",
"வி",
"வீ",
"வெ",
"வே",
"வை",
"வௌ"
};

        public List<string> Muthal_letters
        {
            get { return muthal_letters; }
            set { muthal_letters = value; }
        }


        List<string> last_letters = new List<string>() {"க",
"கா",
"கி",
"கீ",
"கு",
"கூ",
"கே",
"கை",
"கோ",
"கௌ",
"ங",
"ஙா",
"ஙி",
"ஙீ",
"ஙு",
"ஙூ",
"ஙே",
"ஙை",
"ஙோ",
"ச",
"சா",
"சி",
"சீ",
"சு",
"சூ",
"சே",
"சை",
"சோ",
"ஞ்",
"ஞ",
"ஞா",
"ஞி",
"ஞீ",
"ஞு",
"ஞூ",
"ஞே",
"ஞை",
"ஞோ",
"ட",
"டா",
"டி",
"டீ",
"டு",
"டூ",
"டே",
"டை",
"டோ",
"ண்",
"ண",
"ணா",
"ணி",
"ணீ",
"ணு",
"ணூ",
"ணே",
"ணை",
"ணோ",
"த",
"தா",
"தி",
"தீ",
"து",
"தூ",
"தே",
"தை",
"தோ",
"ந்",
"ந",
"நா",
"நி",
"நீ",
"நு",
"நூ",
"நே",
"நை",
"நொ",
"நோ",
"ப",
"பா",
"பி",
"பீ",
"பு",
"பூ",
"பே",
"பை",
"போ",
"ம்",
"ம",
"மா",
"மி",
"மீ",
"மு",
"மூ",
"மே",
"மை",
"மோ",
"ய்",
"ய",
"யா",
"யி",
"யீ",
"யு",
"யூ",
"யே",
"யை",
"யோ",
"ர்",
"ர",
"ரா",
"ரி",
"ரீ",
"ரு",
"ரூ",
"ரே",
"ரை",
"ரோ",
"ல்",
"ல",
"லா",
"லி",
"லீ",
"லு",
"லூ",
"லே",
"லை",
"லோ",
"வ்",
"வ",
"வா",
"வி",
"வீ",
"வு",
"வூ",
"வே",
"வை",
"வோ",
"வௌ",
"ழ்",
"ழ",
"ழா",
"ழி",
"ழீ",
"ழு",
"ழூ",
"ழே",
"ழை",
"ழோ",
"ள்",
"ள",
"ளா",
"ளி",
"ளீ",
"ளு",
"ளூ",
"ளே",
"ளை",
"ளோ",
"ற",
"றா",
"றி",
"றீ",
"று",
"றூ",
"றே",
"றை",
"றோ",
"ன்",
"ன",
"னா",
"னி",
"னீ",
"னு",
"னூ",
"னே",
"னை",
"னோ"};

        public List<string> Last_letters
        {
            get { return last_letters; }
            set { last_letters = value; }
        }

        List<String> grantha_agaram_letters = new List<String>();

        //grantha_agaram_letters = grantha_agaram_letters.concat(sanskrit_letters);

        List<String> grantha_agaram_set = new List<String>();//Array.from(grantha_agaram_letters);
        List<String> accent_symbol_set = new List<String>();//Array.from(accent_symbols);

        public List<String> Accent_symbol_set
        {
            get { return accent_symbol_set; }
            set { accent_symbol_set = value; }
        }
        List<String> uyir_letter_set = new List<String>();//Array.from(uyir_letters);

        public List<String> Uyir_letter_set
        {
            get { return uyir_letter_set; }
            set { uyir_letter_set = value; }
        }

        public TamilWordNLP()
        {
            tamil_symbols = new List<string>() { _day, _month, _year, _debit, _credit, _rupee, _numeral, _sri, _ksha, _ksh };
            TA_LETTERS_LEN = 247 + 6 * 12 + 22 + 4 - TA_AGARAM_LEN - 4;


            grantha_agaram_letters.AddRange(agaram_letters);
            grantha_agaram_letters.AddRange(sanskrit_letters);

            grantha_agaram_set.AddRange(grantha_agaram_letters);
            accent_symbol_set.AddRange(accent_symbols);
            uyir_letter_set.AddRange(uyir_letters);

            baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            fontDirectories = baseDirectory + "/font_maps/";

            dataDirectories = baseDirectory + "/data/";

            assignTamilWordsList(dataDirectories);
        }

        private void assignTamilWordsList(string dataDirectories)
        {
            tamilWords = File.ReadAllLines(dataDirectories + "tamil_words_list.txt", Encoding.UTF8).ToList();
            taEncryptedLetters = File.ReadAllLines(dataDirectories + "ta_encrypted_letters.txt", Encoding.UTF8).ToList();

        }
        public string[] get_tamil_letters(string word)
        {
            List<string> ta_letters = new List<string>();
            bool not_empty = false;
            int WLEN = word.Length;
            int idx = 0;
            try
            {
                while (idx < WLEN)
                {
                    string c = word[idx].ToString();
                    //c = word[idx];

                    ////print(idx,hex(ascii(c)),len(ta_letters));
                    if (uyir_letter_set.Contains(c)
                        || c == ayudha_letter)
                    {
                        ta_letters.Add(c);
                        not_empty = true;
                    }
                    else if (grantha_agaram_set.Contains(c))
                    {
                        ta_letters.Add(c);
                        not_empty = true;
                    }
                    else if (accent_symbol_set.Contains(c))
                    {
                        if (!not_empty)
                        {
                            // odd situation;
                            ta_letters.Add(c);
                            not_empty = true;
                        }
                        else
                        {
                            //print("Merge/accent");
                            //ta_letters[-1] += c;
                            ta_letters[ta_letters.Count - 1] += c;
                        }
                    }
                    else
                    {
                        if (c[0] < 256)
                        {
                            ta_letters.Add(c);
                        }
                        else
                        {
                            if (not_empty)
                            {
                                //print("Merge/??");
                                //ta_letters[-1] += c;
                                ta_letters[ta_letters.Count - 1] += c;
                            }
                            else
                            {
                                ta_letters.Add(c);
                                not_empty = true;
                            }
                        }
                    }
                    idx = idx + 1;
                }

            }
            catch
            {

            }

            return ta_letters.ToArray();
        }
        public string EncodeToUTF8(string fileNameFontMap, string inputContent)
        {
            fileNameFontMap = fontDirectories + fileNameFontMap;
            string[] fontToUTF8Map = File.ReadAllLines(fileNameFontMap,
                Encoding.UTF8);

            List<FontMapChars> lstFontMapChars = new List<FontMapChars>();


            foreach (string strLine in fontToUTF8Map)
            {
                string[] mapstr = strLine.Split(' ');
                lstFontMapChars.Add(new FontMapChars() { TaChar = mapstr[0], TaCharUtf8 = mapstr[1] });
                inputContent = inputContent.Replace(mapstr[0], mapstr[1]);
            }
            return inputContent;
        }

        public string Kirantham_nekki(string inputWord)
        {
            var givenWords = inputWord.Split(' ');
            var theWholeWord = "";

            for (int wrdsCount = 0; wrdsCount < givenWords.Length; wrdsCount++)
            {

                string word = givenWords[wrdsCount].Replace("ஸ்ரீ", "திரு").Replace("க்ஷூ", "கீ");

                var _ta_letters = get_tamil_letters(word);


                for (int i = 0; i < _ta_letters.Length; i++)
                {
                    if (i == 0)
                    {
                        //First character-list
                        _ta_letters[i] = _ta_letters[i].Replace("ஷ", "ச");
                        _ta_letters[i] = _ta_letters[i].Replace("ஜ", "ச");
                        _ta_letters[i] = _ta_letters[i].Replace("ர்", "இ");
                        _ta_letters[i] = _ta_letters[i].Replace("ர", "இர");
                        _ta_letters[i] = _ta_letters[i].Replace("ல", "இல");
                        _ta_letters[i] = _ta_letters[i].Replace("ய", "இய");
                        if (_ta_letters[i] == ("ஹௌ"))
                        {
                            _ta_letters[i] = _ta_letters[i].Replace("ஹௌ", "ஔ");
                        }
                        else if (_ta_letters[i] == ("ஹோ"))
                        {
                            _ta_letters[i] = _ta_letters[i].Replace("ஹோ", "ஓ");
                        }
                        else if (_ta_letters[i] == ("ஹொ"))
                        {
                            _ta_letters[i] = _ta_letters[i].Replace("ஹொ", "ஒ");
                        }
                        else if (_ta_letters[i] == ("ஹை"))
                        {
                            _ta_letters[i] = _ta_letters[i].Replace("ஹை", "ஐ");
                        }
                        else if (_ta_letters[i] == ("ஹே"))
                        {
                            _ta_letters[i] = _ta_letters[i].Replace("ஹே", "ஏ");
                        }
                        else if (_ta_letters[i] == ("ஹே"))
                        {
                            _ta_letters[i] = _ta_letters[i].Replace("ஹே", "எ");
                        }
                        else if (_ta_letters[i] == ("ஹூ"))
                        {
                            _ta_letters[i] = _ta_letters[i].Replace("ஹூ", "ஊ");
                        }
                        else if (_ta_letters[i] == ("ஹு"))
                        {
                            _ta_letters[i] = _ta_letters[i].Replace("ஹு", "உ");
                        }
                        else if (_ta_letters[i] == ("ஹீ"))
                        {
                            _ta_letters[i] = _ta_letters[i].Replace("ஹீ", "ஈ");
                        }
                        else if (_ta_letters[i] == ("ஹி"))
                        {
                            _ta_letters[i] = _ta_letters[i].Replace("ஹி", "இ");
                        }
                        else if (_ta_letters[i] == ("ஹா"))
                        {
                            _ta_letters[i] = _ta_letters[i].Replace("ஹா", "ஆ");
                        }
                        else
                        {
                            _ta_letters[i] = _ta_letters[i].Replace("ஹ", "அ");
                        }
                        _ta_letters[i] = _ta_letters[i].Replace("க்ஷ", "க");
                    }
                    else if (i == (_ta_letters.Length - 1))
                    {
                        //lastCharList
                        if (_ta_letters[i].Contains("ஷ்") ||
                        _ta_letters[i].Contains("ஸ்")
                        )
                        {
                            _ta_letters[i] = _ta_letters[i].Replace("ஷ்", "சு");
                            _ta_letters[i] = _ta_letters[i].Replace("ஸ்", "சு"); //அமிருதசரஸ்
                        }
                        else if (_ta_letters[i].Contains("ஷ") ||
                        _ta_letters[i].Contains("ஸ") ||
                        _ta_letters[i].Contains("ஜ")
                        )
                        {
                            _ta_letters[i] = _ta_letters[i].Replace("ஷ", "ச/ய");
                            _ta_letters[i] = _ta_letters[i].Replace("ஸ", "ச/த");
                            _ta_letters[i] = _ta_letters[i].Replace("ஜ", "ச");
                        }
                        else
                        {
                            _ta_letters[i] = _ta_letters[i].Replace("ா", "ை");
                        }
                    }
                    else
                    {
                        //middle characters
                        if (_ta_letters[i].Contains("க்ஷ்"))
                        {
                            _ta_letters[i] = _ta_letters[i].Replace("க்ஷ்", "க்கு");
                        }
                        else if (_ta_letters[i].Contains("ஷ்"))
                        {
                            _ta_letters[i] = _ta_letters[i].Replace("ஷ்", "ட்");
                        }
                        else
                        {
                            _ta_letters[i] = _ta_letters[i].Replace("ஷ", "ச/ய");
                            _ta_letters[i] = _ta_letters[i].Replace("க்ஷ", "க்க");
                            _ta_letters[i] = _ta_letters[i].Replace("ஸ", "ச/த");
                            _ta_letters[i] = _ta_letters[i].Replace("ஜ", "ச");
                        }
                    }
                }

                for (int i = 0; i < _ta_letters.Length; i++)
                {
                    //For all common letters
                    _ta_letters[i] = _ta_letters[i].Replace("ஹ", "க");
                    _ta_letters[i] = _ta_letters[i].Replace("ஸ", "ச");
                    _ta_letters[i] = _ta_letters[i].Replace("ஜ", "ய");
                }

                string pureTaWord = "";

                for (int i = 0; i < _ta_letters.Length; i++)
                {
                    //For all common letters
                    pureTaWord += _ta_letters[i];
                }

                pureTaWord = pureTaWord.Replace("க்ல", "க்கில")
                    .Replace("க்ர", "க்கிர")
                    .Replace("்வ", "ுவ");
                //.Replace("்ம", "ும")

                if (word == pureTaWord)
                {
                    theWholeWord += pureTaWord + " ";
                }
                else
                {
                    theWholeWord += pureTaWord + " (" + word + ") ";
                }
            }

            return theWholeWord;
        }
        string baseDirectory = "", fontDirectories = "", dataDirectories = "";

        public string[] getAvailableFontConversions()
        {
            string[] files = Directory.GetFiles(fontDirectories);
            List<string> fontNames = new List<string>();
            foreach (string file in files)
            {
                string font_name = Path.GetFileName(file);
                fontNames.Add(font_name);
            }

            //cboTamilFontType.SelectedIndex = 0;
            return fontNames.ToArray();
        }
        public bool CheckTaFirstAndLastCharCorrect3(string inputSol,
         out bool correctFirstLetter,
           out bool correctLastLetter)
        {
            bool everythingIsCorrect = false;

            string[] tamilLettersInputSol = get_tamil_letters(inputSol);

            everythingIsCorrect = true;
            correctFirstLetter = true;
            correctLastLetter = true;

            foreach (string wordLetter in tamilLettersInputSol)
            {
                int match = taEncryptedLetters.IndexOf(wordLetter);

                if (match > 0)
                {
                    everythingIsCorrect = false;
                    correctFirstLetter = false;
                    correctLastLetter = false;
                    break;
                }
            }

            return everythingIsCorrect;
        }

        public bool CheckTaFirstAndLastCharCorrect(string inputSol,
          out bool correctFirstLetter,
            out bool correctLastLetter)
        {
            bool everythingIsCorrect = false;
            correctLastLetter = false;
            correctFirstLetter = false;




            //check vallinam ottu at last?
            //vallinam_letters
            string[] TamilLetters = get_tamil_letters(inputSol);
            if (everythingIsCorrect == false)
            {
                //check last characters in vallinam mey
                string lastLetter = TamilLetters[TamilLetters.Length - 1];
                int isVallinamLetter = vallinam_letters.IndexOf(lastLetter);

                if (isVallinamLetter >= 0)
                {
                    int availWord = tamilWords.IndexOf(inputSol.Substring(0, TamilLetters.Length - 2));
                    if (availWord > 0)
                    {
                        correctLastLetter = true;
                        correctFirstLetter = true;
                        everythingIsCorrect = true;
                    }
                }
            }
            //check word contains correct word?
            if (everythingIsCorrect == false)
            {
                int availWord = tamilWords.IndexOf(inputSol);
                if (availWord > 0)
                {
                    correctLastLetter = true;
                    correctFirstLetter = true;
                    everythingIsCorrect = true;
                }
                else
                {
                    correctLastLetter = false;
                    correctFirstLetter = false;
                    everythingIsCorrect = false;
                }
            }
            //check word contains correct word without vallinam last mey?
            if (everythingIsCorrect == false)
            {
                string lastLetter = TamilLetters[TamilLetters.Length - 1];
                int lastValMatch = vallinam_letters.IndexOf(lastLetter);

                if (lastValMatch > 0)
                {

                    string inputSolWithoutLastVallinam = inputSol.TrimEnd(lastLetter.ToCharArray());

                    int availWord = tamilWords.IndexOf(inputSolWithoutLastVallinam);
                    if (availWord > 0)
                    {
                        correctLastLetter = true;
                        correctFirstLetter = true;
                        everythingIsCorrect = true;
                    }
                    else
                    {
                        correctLastLetter = false;
                        correctFirstLetter = false;
                        everythingIsCorrect = false;
                    }
                }
            }

            //check the word contains any wordOttuSorkal
            if (everythingIsCorrect == false)
            {
                string ottu = getLastOttuLetters(TamilLetters, 3);

                int availWord = tamilWords.IndexOf(inputSol);
                if (availWord > 0)
                {
                    correctLastLetter = true;
                    correctFirstLetter = true;
                    everythingIsCorrect = true;
                }
                else
                {
                    correctLastLetter = false;
                    correctFirstLetter = false;
                    everythingIsCorrect = false;
                }
            }

            if (inputSol.Length > 0 && everythingIsCorrect == false)
            {
                int match = Muthal_letters.IndexOf(inputSol[0].ToString());

                if (match < 0)
                {
                    //lblMuthal.BackColor = Color.IndianRed;
                    correctFirstLetter = false;
                    everythingIsCorrect = false; ;
                }
                else
                {
                    //lblMuthal.BackColor = Color.Green;
                    correctFirstLetter = true;
                }

                string strCheckLetter = inputSol[(inputSol.Length - 1)].ToString();

                if (strCheckLetter == "்"
                    || strCheckLetter == "ா"
                    || strCheckLetter == "ி"
                    || strCheckLetter == "ீ"
                    || strCheckLetter == "ு"
                    || strCheckLetter == "ூ"
                    || strCheckLetter == "ெ"
                    || strCheckLetter == "ே"
                    || strCheckLetter == "ை"
                    || strCheckLetter == "ொ"
                    || strCheckLetter == "ோ"
                    || strCheckLetter == "ௌ"
                    )
                {
                    match = Last_letters.IndexOf(inputSol.Substring(inputSol.Length - 2));

                }
                else
                {
                    match = Last_letters.IndexOf(inputSol[(inputSol.Length - 1)].ToString());
                }

                if (match < 0)
                {
                    //lblEeru.BackColor = Color.IndianRed;
                    correctLastLetter = false;
                    everythingIsCorrect = false; ;
                }
                else
                {
                    //lblEeru.BackColor = Color.Green;
                    correctLastLetter = true;
                }
            }
            //else
            //{
            //    //lblMuthal.BackColor = SystemColors.Control;
            //    //lblEeru.BackColor = SystemColors.Control;
            //    correctLastLetter = false;
            //    correctFirstLetter = false;
            //    everythingIsCorrect = false;
            //}

            //Check whether the word contains special characters except last character
            if (everythingIsCorrect == false)
            {
                foreach (string wordLetter in TamilLetters)
                {
                    int match = taEncryptedLetters.IndexOf(wordLetter);

                    if (match > 0)
                    {
                        everythingIsCorrect = false;
                        correctFirstLetter = false;
                        correctLastLetter = false;
                        break;
                    }
                }
            }

            if (correctLastLetter && correctFirstLetter)
            {
                everythingIsCorrect = true;
            }
            else
            {
                everythingIsCorrect = false;
            }

            return everythingIsCorrect;
        }

        private string getLastOttuLetters(string[] TamilLetters, int lengthOfOttuLetters)
        {
            if (TamilLetters.Length <= lengthOfOttuLetters + 1)
            {
                return "";
            }
            string finalOttuWord = "";
            //for (int i = TamilLetters.Length - 1; i >= lengthOfOttuLetters; i--)
            for (int i = TamilLetters.Length - lengthOfOttuLetters; i <= TamilLetters.Length - 1; i++)
            {
                finalOttuWord += TamilLetters[i];
            }
            return finalOttuWord;
        }

        private string getLastOttuLetters(string[] TamilLetters)
        {
            throw new NotImplementedException();
        }

        public string EncodeToUTF8AutoMultiple(string inputstring)
        {
            string[] splitedtext = inputstring.Split(' ');
            StringBuilder stb = new StringBuilder();

            foreach(string singleWord in splitedtext)
            {
                stb.Append(EncodeToUTF8AutoSingle(singleWord)+" ");
            }

            return stb.ToString();
        }

        public string EncodeToUTF8AutoSingle(string inputstring)
        {
            return getUTFConvertedWord(inputstring);
        }
        string fontNames = "";
        private string getUTFConvertedWord(string inputstring)
        {
            string correctWords = "";
            //[^\x00-\x7F]+
            bool convertedWordIsRight = false;

            bool a, b;
            foreach (string fontNamesLoc in getAvailableFontConversions())
            {                
                correctWords = EncodeToUTF8(fontNamesLoc, inputstring);
                convertedWordIsRight = CheckTaFirstAndLastCharCorrect(correctWords,
                out a, out b);
                if (convertedWordIsRight)
                {
                    fontNames = fontNamesLoc;
                    break;
                }
            }

            return correctWords;
        }

        public string DetectFontType(string inputstring)
        {
            if (inputstring != "" && inputstring.Length > 0 )
            {
                string getFirstWord = inputstring.Split('\n')[0].Split(' ')[0].Trim();
                getUTFConvertedWord(getFirstWord);
            }
            return fontNames;
        }
    }
}