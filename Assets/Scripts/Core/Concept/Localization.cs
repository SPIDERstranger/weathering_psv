
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Weathering
{
    public interface ILocalization
    {
        string Get<T>();
        string Get(Type key);

        string TryGet<T>();
        string TryGet(Type key);

        string GetDescription<T>();
        string GetDescription(Type type);

        string ValUnit<T>();
        string ValUnit(Type key);
        //string NoVal(Type key);
        //string NoVal<T>();
        string Val<T>(long val);
        string Val(Type key, long val);
        string ValPlus<T>(long val);
        string ValPlus(Type key, long val);
        string Inc<T>(long val);
        string Inc(Type key, long val);

        void SyncActiveLanguage(); // Globals.Ins.PlayerPreferences[activeLanguageKey]
        void SwitchNextLanguage();
    }

    public class Localization : MonoBehaviour, ILocalization
    {
        public static ILocalization Ins { get; private set; }
        public const string ACTIVE_LANGUAGE = "active_language";
        // 从streamingAsset 中获取对应的语言
        private void Awake() {
            if (Ins != null) {
                throw new Exception();
            }
            Ins = this;
            LoadSupportLanguageFromSA();
            // 判断该语言是否存在，若不存在，则读取文件，若还没有，就不管了
            if (Globals.Ins.PlayerPreferences.ContainsKey(ACTIVE_LANGUAGE)) {

            } else {
                LoadDefaultLanguage();
                Globals.Ins.PlayerPreferences.Add(ACTIVE_LANGUAGE, DefaultLangInSA);
            }
            CorrectLanguage();

            SyncActiveLanguage();
        }


        private string DefaultLanguage = "zh_cn";
        private string DefaultLangInSA;

        //public string[] SupporttedLanguages;

        //[SerializeField]
        //private TextAsset[] Jsons;
        private Dictionary<string, string> Dict;
        private Dictionary<string, string> DictOfDescription;

        public string Get<T>() {
            return Get(typeof(T));
        }
        public string Get(Type key) {
            string result;
            if (Dict.TryGetValue(key.FullName, out  result)) {
                // throw new Exception($"localization key not found: {key}");
                // return string.Format(result, "");
                return result;
            }
            return key.FullName;
        }
        public string TryGet<T>() {
            return TryGet(typeof(T));
        }

        public string TryGet(Type key) {
            string result;
            if (Dict.TryGetValue(key.FullName, out  result)) {
                // throw new Exception($"localization key not found: {key}");
                // return string.Format(result, "");
                return result;
            }
            return null;
        }

        public string GetDescription<T>() {
            return GetDescription(typeof(T));
        }

        public const string DescriptionSuffix = "#Description";
        public string GetDescription(Type key) {
            string result;
            if (DictOfDescription.TryGetValue(key.FullName, out  result)) {
                return result;
            }
            return null;
        }


        public string ValUnit<T>() {
            return ValUnit(typeof(T));
        }
        public string ValUnit(Type key) {
            string result;
            if (Dict.TryGetValue(key.FullName, out  result)) {
                return string.Format(result, "");
            }
            return key.FullName;
        }



        public string Val<T>(long val) {
            return Val(typeof(T), val);
        }
        public string Val(Type key, long val) {
            if (key == null) throw new Exception();
            string result;
            if (Dict.TryGetValue(key.FullName, out  result)) {
                // throw new Exception($"localization key not found: {key}");
                if (val > 0) {
                    return string.Format(result, $" {val}");
                } else if (val < 0) {
                    return string.Format(result, $"-{-val}");
                } else {
                    return string.Format(result, " 0");
                }
            }
            return key.FullName;
        }
        public string ValPlus<T>(long val) {
            return ValPlus(typeof(T), val);
        }
        public string ValPlus(Type key, long val) {
            string result;
            if (Dict.TryGetValue(key.FullName, out  result)) {
                // throw new Exception($"localization key not found: {key}");
                if (val > 0) {
                    return string.Format(result, $"+{val}");
                } else if (val < 0) {
                    return string.Format(result, $"-{-val}");
                } else {
                    return string.Format(result, " 0");
                }
            }
            return key.FullName;
        }

        public string Inc<T>(long val) {
            return Inc(typeof(T), val);
        }
        public string Inc(Type key, long val) {
            string result;
            if (Dict.TryGetValue(key.FullName, out  result)) {
                // throw new Exception($"localization key not found: {key}");
                if (val > 0) {
                    return string.Format(result, $" Δ{val}");
                } else if (val < 0) {
                    return string.Format(result, $"-Δ{-val}");
                } else {
                    return string.Format(result, " 0");
                }
            }
            return key.FullName;
        }

        public void SyncActiveLanguage() {
            string activeLanguage = Globals.Ins.PlayerPreferences[ACTIVE_LANGUAGE];
            bool found = LoadLangFromSA(activeLanguage);
            #region 弃用

            //Dict = new Dictionary<string, string>();
            //DictOfDescription = new Dictionary<string, string>();
            //foreach (var jsonTextAsset in Jsons) {
            //    if (jsonTextAsset.name.StartsWith(activeLanguage)) {
            //        Dictionary<string, string> subDict = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonTextAsset.text);
            //        foreach (var pair in subDict) {
            //            if (Dict.ContainsKey(pair.Key)) {
            //                UIPreset.Throw($"出现了重复的key “{pair.Key}” in {jsonTextAsset.name}. 不知道另一个key在哪个文件");
            //            }
            //            else {
            //                int indexOfHashMark = pair.Key.IndexOf('#');
            //                if (indexOfHashMark < 0) {
            //                    Dict.Add(pair.Key, pair.Value);
            //                } 
            //                else {
            //                    string typeName = pair.Key.Substring(0, indexOfHashMark);
            //                    //if (DictOfDescription.ContainsKey(typeName)) {
            //                    //    Debug.LogError(typeName);
            //                    //}
            //                    DictOfDescription.Add(typeName, pair.Value);
            //                }
            //            }
            //        }
            //        found = true;
            //    }
            //}
            #endregion
            if (!found) {
                throw new Exception(activeLanguage);
            }
        }

        public void SwitchNextLanguage() {
            string activeLanguage = Globals.Ins.PlayerPreferences[ACTIVE_LANGUAGE];
            if (supportLanguagesInSA.Length == 1&& activeLanguage.Equals(supportLanguagesInSA[0],StringComparison.CurrentCulture) ){//TODO 判断是否为当前语言
                UIPreset.Notify(null, "只有一种语言配置");
                return;
            }

            // 找到下一个语言, 效率很低, 但可以用
            bool found = false;
            int index = 0;
            foreach (var jsonTextAsset in supportLanguagesInSA) {
                if (jsonTextAsset == activeLanguage) {
                    // Dict = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonTextAsset.text);
                    found = true;
                    break;
                }
                index++;
            }
            if (!found)
            {
                UIPreset.Notify(null, "无当前配置语言");
                throw new Exception();
            }
            index++;
            if (index == supportLanguagesInSA.Length) {
                index = 0;
            }

            // Dict = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(Jsons[index].text);

            Globals.Ins.PlayerPreferences[ACTIVE_LANGUAGE] = supportLanguagesInSA[index];
            SyncActiveLanguage();
        }

        public void CorrectLanguage()
        {
            var lang = Globals.Ins.PlayerPreferences[ACTIVE_LANGUAGE];
            foreach (var support in supportLanguagesInSA)
                if (lang.Equals(support,StringComparison.CurrentCulture))
                    return;

            if (supportLanguagesInSA.Length > 0)
            {
                LoadDefaultLanguage();
                Globals.Ins.PlayerPreferences[ACTIVE_LANGUAGE] = DefaultLangInSA;
            }
        }

        public const string localizationPath = "/Localization/";
        private string[] supportLanguagesInSA;
        public const string JSON_Extension = ".json";
        public void LoadSupportLanguageFromSA()
        {
            var fullPath = Application.streamingAssetsPath + localizationPath;
            string[] langDirs = System.IO.Directory.GetDirectories(fullPath);
            supportLanguagesInSA = new string[langDirs.Length];
            for (int i = 0; i < langDirs.Length; i++)
            {
                var langDir = langDirs[i];
                System.IO.DirectoryInfo info = new System.IO.DirectoryInfo(langDir);
                supportLanguagesInSA[i]=info.Name;
            }
        }
        public bool LoadLangFromSA(string name)
        {
            Dict = new Dictionary<string, string>();
            DictOfDescription = new Dictionary<string, string>();

            var fullpath = Application.streamingAssetsPath + localizationPath + name;
            if (!System.IO.Directory.Exists(fullpath))
                return false;
            var filePaths = System.IO.Directory.GetFiles(fullpath);
            if (filePaths.Length == 0)
                return false;

            foreach (var file in filePaths)
            {
                var Extension = new System.IO.FileInfo(file).Extension;
                if (!Extension.Equals(JSON_Extension, StringComparison.CurrentCultureIgnoreCase))
                    continue;
                var fileText = System.IO.File.ReadAllText(file);
                Dictionary<string, string> subDict = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(fileText);
                foreach (var pair in subDict)
                {
                    if (Dict.ContainsKey(pair.Key))
                    {
                        UIPreset.Throw($"出现了重复的key “{pair.Key}” in {file}. 不知道另一个key在哪个文件");
                    }
                    else
                    {
                        int indexOfHashMark = pair.Key.IndexOf('#');
                        if (indexOfHashMark < 0)
                        {
                            Dict.Add(pair.Key, pair.Value);
                        }
                        else
                        {
                            string typeName = pair.Key.Substring(0, indexOfHashMark);
                            //if (DictOfDescription.ContainsKey(typeName)) {
                            //    Debug.LogError(typeName);
                            //}
                            DictOfDescription.Add(typeName, pair.Value);
                        }
                    }
                }
            }

            return true;

        }
        public void LoadDefaultLanguage()
        {
            var name = "defaultLang";
            var fullpath = Application.streamingAssetsPath + localizationPath+name;
            if (System.IO.File.Exists(fullpath))
            {
                var defaultLang = System.IO.File.ReadAllText(fullpath);
                defaultLang =  defaultLang.Trim();
                foreach (var support in supportLanguagesInSA)
                    if (defaultLang.Equals(support, StringComparison.CurrentCulture))
                    {
                        DefaultLangInSA = defaultLang;
                        return ;
                    }
            }
            DefaultLangInSA = supportLanguagesInSA.Length > 0 ? supportLanguagesInSA[0] : DefaultLanguage;
            //using (var writer = System.IO.File.CreateText(fullpath))
            //    writer.Write(DefaultLangInSA);

        }
    }
}

