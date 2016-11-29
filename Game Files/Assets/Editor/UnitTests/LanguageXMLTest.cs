using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using NUnit.Framework;


public class LanguageXMLTest {

	[Test]
	public void XMLKeysIdentical()
	{
        Dictionary<Language, Dictionary<string, string>> languageStringDictionaries = new Dictionary<Language, Dictionary<string, string>>();
        foreach(Language language in Enum.GetValues(typeof(Language)))
        {
            StringManager.SetLanguage(language);
            languageStringDictionaries.Add(language, StringManager.Strings);
        }
        foreach(KeyValuePair<Language, Dictionary<string,string>> entry in languageStringDictionaries)
        {
            Dictionary<string, string> englishStringDictionary = languageStringDictionaries[Language.English];
            List<string> englishStringDictionaryKeys = englishStringDictionary.Keys.ToList<string>();

            Dictionary<string, string> currentLanguageStringDictionary = entry.Value;
            List<string> currentLanguageStringDictionaryKeys = currentLanguageStringDictionary.Keys.ToList<string>();

            Assert.That(Enumerable.SequenceEqual(englishStringDictionaryKeys.OrderBy(t => t), currentLanguageStringDictionaryKeys.OrderBy(t => t)), "The " + entry.Key + "'s keys do not equal the English ones.");
        }
	}
}