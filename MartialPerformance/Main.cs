// Decompiled with JetBrains decompiler
// Type: MartialPerformance.Main
// Assembly: MartialPerformance, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8F5AAD95-4D78-4F35-9C67-71C978C4D3D8
// Assembly location: F:\Games\steamapps\common\Pathfinder Second Adventure\Mods\MartialPerformance\MartialPerformance.dll

using HarmonyLib;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Blueprints.Items.Armors;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.Blueprints.Root;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.Localization;
using Kingmaker.UnitLogic.FactLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityModManagerNet;

namespace MartialPerformance
{
  public static class Main
  {
    private static readonly BlueprintGuid martialPerformanceGuid = BlueprintGuid.Parse("20e1d93cc17b4a34a7ef21b4849b2ba9");
    private static readonly Dictionary<string, BlueprintGuid> weaponTypeGuids;
    private static readonly string description;

    public static void Load(UnityModManager.ModEntry modEntry) => new Harmony(modEntry.Info.Id).PatchAll(Assembly.GetExecutingAssembly());

    static Main()
    {
      Dictionary<string, BlueprintGuid> dictionary = new Dictionary<string, BlueprintGuid>();
      dictionary.Add("MartialPerformanceUnarmedStrike", BlueprintGuid.Parse("c1a8c4efe3b24c029ff4d52a78329f94"));
      dictionary.Add("MartialPerformanceDagger", BlueprintGuid.Parse("a994ec0c74574811a589adb339ad8651"));
      dictionary.Add("MartialPerformanceLightMace", BlueprintGuid.Parse("52f5b5a25f6f4127b089ead2094d6869"));
      dictionary.Add("MartialPerformancePunchingDagger", BlueprintGuid.Parse("7a0b1829175e4398b29b68e3e8a21efe"));
      dictionary.Add("MartialPerformanceSickle", BlueprintGuid.Parse("600763c5f5e448bb869366393671a2c9"));
      dictionary.Add("MartialPerformanceClub", BlueprintGuid.Parse("9a56af8839004f25a53507239166a183"));
      dictionary.Add("MartialPerformanceHeavyMace", BlueprintGuid.Parse("1436bfc4558443619c06abdf804ef1a2"));
      dictionary.Add("MartialPerformanceShortspear", BlueprintGuid.Parse("69d362c11cb04f3f817e7ff21220e837"));
      dictionary.Add("MartialPerformanceGreatclub", BlueprintGuid.Parse("25b6ad7d0a8f4ce3a718328d5051a423"));
      dictionary.Add("MartialPerformanceLongspear", BlueprintGuid.Parse("d8e380ccf3764505bdfc2a4aab153354"));
      dictionary.Add("MartialPerformanceQuarterstaff", BlueprintGuid.Parse("b71838603021429c90605b724a19e8e1"));
      dictionary.Add("MartialPerformanceSpear", BlueprintGuid.Parse("4cf370ddf80d4f4ea31cba5ac8fe14a8"));
      dictionary.Add("MartialPerformanceTrident", BlueprintGuid.Parse("51585077a0d94ae3914a3faeca21d472"));
      dictionary.Add("MartialPerformanceDart", BlueprintGuid.Parse("18497068d5754ea393b8daec055593a6"));
      dictionary.Add("MartialPerformanceLightCrossbow", BlueprintGuid.Parse("f705ce88ebd34b77a14a94f17db00907"));
      dictionary.Add("MartialPerformanceHeavyCrossbow", BlueprintGuid.Parse("6688e8c37976492d960272973d790ea7"));
      dictionary.Add("MartialPerformanceJavelin", BlueprintGuid.Parse("5335c3969b4f4740bf4c76eaadebd2bb"));
      dictionary.Add("MartialPerformanceSling", BlueprintGuid.Parse("f727581c0bf84bae94c93f1a9ca7d69b"));
      dictionary.Add("MartialPerformanceHandaxe", BlueprintGuid.Parse("e556233c74f3422791302ff77e0d0b2a"));
      dictionary.Add("MartialPerformanceKukri", BlueprintGuid.Parse("5664599f2cb84e60954d0e47aa2e4b38"));
      dictionary.Add("MartialPerformanceLightHammer", BlueprintGuid.Parse("0bee3eeaed534786b959456952c46e9a"));
      dictionary.Add("MartialPerformanceLightPick", BlueprintGuid.Parse("2c3841e2d5cb419486dd0e25400db00c"));
      dictionary.Add("MartialPerformanceShortsword", BlueprintGuid.Parse("a1decff86274439d96219b8fa4df3e7c"));
      dictionary.Add("MartialPerformanceStarknife", BlueprintGuid.Parse("ed00ef8509d2443b82ddb1eabc5a0e2e"));
      dictionary.Add("MartialPerformanceWeaponLightShield", BlueprintGuid.Parse("82a8f6a07458459395fd218de109e52f"));
      dictionary.Add("MartialPerformanceSpikedLightShield", BlueprintGuid.Parse("c9d6be771a8d4583a2eaefc310422ad9"));
      dictionary.Add("MartialPerformanceBattleaxe", BlueprintGuid.Parse("4c591d78bbc84f09adc48840ff673ead"));
      dictionary.Add("MartialPerformanceFlail", BlueprintGuid.Parse("4eebe1b09c474b9f8dca5ee1cffd38c2"));
      dictionary.Add("MartialPerformanceHeavyPick", BlueprintGuid.Parse("3f295ed6f72143edbbc439fc3198fba2"));
      dictionary.Add("MartialPerformanceLongsword", BlueprintGuid.Parse("25510392b6ae4a2cac7e59bebe4bab43"));
      dictionary.Add("MartialPerformanceRapier", BlueprintGuid.Parse("88cd10ba04ff4ed0a668130bb584bf4b"));
      dictionary.Add("MartialPerformanceScimitar", BlueprintGuid.Parse("83642a14cf9141aa9ae824b8bd522e12"));
      dictionary.Add("MartialPerformanceWarhammer", BlueprintGuid.Parse("a0a52538344745bb9419c3f2c82605da"));
      dictionary.Add("MartialPerformanceWeaponHeavyShield", BlueprintGuid.Parse("cfa459bfb76d4080a3291bf3b38b5071"));
      dictionary.Add("MartialPerformanceSpikedHeavyShield", BlueprintGuid.Parse("819508f62b78499e9c08e2c776fab925"));
      dictionary.Add("MartialPerformanceEarthBreaker", BlueprintGuid.Parse("8947c8adf3c14316985426e1d43b17ea"));
      dictionary.Add("MartialPerformanceFalchion", BlueprintGuid.Parse("ba3bd1a708074dcfb3280467f495e5bc"));
      dictionary.Add("MartialPerformanceGlaive", BlueprintGuid.Parse("365675b4781c4c73bf794640f0896d4e"));
      dictionary.Add("MartialPerformanceGreataxe", BlueprintGuid.Parse("f457abdcbdbc471f86050efe951f966a"));
      dictionary.Add("MartialPerformanceGreatsword", BlueprintGuid.Parse("693bef8563b14e0ab468e038a9dd5a04"));
      dictionary.Add("MartialPerformanceHeavyFlail", BlueprintGuid.Parse("b7eadc3d82044fcfbdf6f34c52936c96"));
      dictionary.Add("MartialPerformanceScythe", BlueprintGuid.Parse("0768dc1daa02473fad89ad5d18672c2c"));
      dictionary.Add("MartialPerformanceShortbow", BlueprintGuid.Parse("ab8a19dde4b345d981e1c1adb7fd603a"));
      dictionary.Add("MartialPerformanceLongbow", BlueprintGuid.Parse("2d11e8efd88f47caadbc2ace4bc95fa8"));
      dictionary.Add("MartialPerformanceKama", BlueprintGuid.Parse("50c6bac2ad0c487ca785a485dbcbc4bc"));
      dictionary.Add("MartialPerformanceNunchaku", BlueprintGuid.Parse("f68f84d5ed044b02b91f1d5a4ef67d3d"));
      dictionary.Add("MartialPerformanceSai", BlueprintGuid.Parse("5daf084375d643d68ddf5ba6ba5c2fb1"));
      dictionary.Add("MartialPerformanceSiangham", BlueprintGuid.Parse("4c7abc756da94091acc0cae90bc51d21"));
      dictionary.Add("MartialPerformanceBastardSword", BlueprintGuid.Parse("455b65e4dbb84020906789ee90efca2f"));
      dictionary.Add("MartialPerformanceDuelingSword", BlueprintGuid.Parse("8612927d84f9459c80b252bae2818c14"));
      dictionary.Add("MartialPerformanceDwarvenWaraxe", BlueprintGuid.Parse("f167cda8c2184e0f920885adb3ec7f2f"));
      dictionary.Add("MartialPerformanceEstoc", BlueprintGuid.Parse("c93de917328f4dcfbd1b4f7a79d9de0d"));
      dictionary.Add("MartialPerformanceFalcata", BlueprintGuid.Parse("577d648ebe80401e9fb3ae502724ca29"));
      dictionary.Add("MartialPerformanceTongi", BlueprintGuid.Parse("80e75fb51b9147948a481fac3b2e78fe"));
      dictionary.Add("MartialPerformanceElvenCurvedBlade", BlueprintGuid.Parse("5c84018a787c4e63acece79450124e2b"));
      dictionary.Add("MartialPerformanceFauchard", BlueprintGuid.Parse("d751592882254076bc8d405d1a478536"));
      dictionary.Add("MartialPerformanceHandCrossbow", BlueprintGuid.Parse("3a2e2c3fc07042be94b06698de508cdb"));
      dictionary.Add("MartialPerformanceLightRepeatingCrossbow", BlueprintGuid.Parse("728e902a7e44450d95d50e748f2bd521"));
      dictionary.Add("MartialPerformanceHeavyRepeatingCrossbow", BlueprintGuid.Parse("fd1fdf5efa524695996d18e44d1adb32"));
      dictionary.Add("MartialPerformanceShuriken", BlueprintGuid.Parse("4dbc96970795470e9fd0e1f5087bc661"));
      dictionary.Add("MartialPerformanceSlingStaff", BlueprintGuid.Parse("c2387084bf7845ce96c11c3a43c8eaa2"));
      dictionary.Add("MartialPerformanceTouch", BlueprintGuid.Parse("e071d1e6c7ad4d508f8b41c6c2e5eb33"));
      dictionary.Add("MartialPerformanceRay", BlueprintGuid.Parse("78dc12ba149043af860540a2df217704"));
      dictionary.Add("MartialPerformanceBomb", BlueprintGuid.Parse("2c5a6d211d6b42559a71bdb8b0f42047"));
      dictionary.Add("MartialPerformanceBite", BlueprintGuid.Parse("ff931704462c41cab13538f167782d3e"));
      dictionary.Add("MartialPerformanceClaw", BlueprintGuid.Parse("58f1d57c72c04e55b88ff0a33b059941"));
      dictionary.Add("MartialPerformanceGore", BlueprintGuid.Parse("7791731057fc46679283a3856c877fc9"));
      dictionary.Add("MartialPerformanceOtherNaturalWeapons", BlueprintGuid.Parse("bea00d55a53c4b6faf015b2c17953861"));
      dictionary.Add("MartialPerformanceBardiche", BlueprintGuid.Parse("1196fb76cc4a49a093b709701d9ff140"));
      dictionary.Add("MartialPerformanceDoubleSword", BlueprintGuid.Parse("f298ffcaa4554edbbcf9535625a68d1e"));
      dictionary.Add("MartialPerformanceDoubleAxe", BlueprintGuid.Parse("41655defb5b64799b13b62ff8415d7fc"));
      dictionary.Add("MartialPerformanceUrgrosh", BlueprintGuid.Parse("f9e4e2badc624391bb8e1cdc1c4b6810"));
      dictionary.Add("MartialPerformanceHookedHammer", BlueprintGuid.Parse("20dfe1377d954a6bbf52a1271ddb5fcd"));
      dictionary.Add("MartialPerformanceKineticBlast", BlueprintGuid.Parse("ee3b7b4cf6854bca839d2df4deb48328"));
      dictionary.Add("MartialPerformanceThrowingAxe", BlueprintGuid.Parse("3f30a10209d3420992c5ca6f750c5394"));
      dictionary.Add("MartialPerformanceTail", BlueprintGuid.Parse("b8e9e4af32c04331ba204a167da5eb10"));
      dictionary.Add("MartialPerformanceHoof", BlueprintGuid.Parse("4a837cda-34d4-419b-9b78-7a2f21ec4c30"));
      dictionary.Add("MartialPerformanceTalon", BlueprintGuid.Parse("4e70b439-1dcc-4964-af7a-dd0bc6c090c0"));
      dictionary.Add("MartialPerformanceTentacle", BlueprintGuid.Parse("22a11d82-b833-4517-9e71-6774e32660ee"));
      dictionary.Add("MartialPerformanceSting", BlueprintGuid.Parse("4c15f0c5-faf4-43ea-aefb-12a464a3cdc3"));
      dictionary.Add("MartialPerformanceSlam", BlueprintGuid.Parse("588e7b36-268a-4498-98e1-2c902af0a658"));
      Main.weaponTypeGuids = dictionary;
      Main.description = "The bard or skald selects a weapon she is proficient with. She gains Weapon Focus with that weapon as a bonus feat. In addition, her effective fighter level is equal to 1/2 her bard and skald levels for the purpose of qualifying for combat feats.";
    }

    [HarmonyPatch(typeof (StartGameLoader), "LoadAllJson")]
    private static class StartGameLoader_LoadAllJson_Patch
    {
      public static void Postfix()
      {
        try
        {
          BlueprintParametrizedFeature weaponFocus = ResourcesLibrary.TryGetBlueprint<BlueprintParametrizedFeature>("1e1f627d26ad36f43bbd26cc2bf8ac7e");
          BlueprintParametrizedFeatureReference weaponFocusReference = BlueprintReferenceEx.ToReference<BlueprintParametrizedFeatureReference>((SimpleBlueprint) weaponFocus);
          BlueprintCharacterClassReference reference1 = BlueprintReferenceEx.ToReference<BlueprintCharacterClassReference>((SimpleBlueprint) ResourcesLibrary.TryGetBlueprint<BlueprintCharacterClass>("48ac8db94d5de7645906c7d0ad3bcfbd"));
          BlueprintCharacterClassReference reference2 = BlueprintReferenceEx.ToReference<BlueprintCharacterClassReference>((SimpleBlueprint) ResourcesLibrary.TryGetBlueprint<BlueprintCharacterClass>("772c83a25e2268e448e841dcd548235f"));
          BlueprintCharacterClassReference reference3 = BlueprintReferenceEx.ToReference<BlueprintCharacterClassReference>((SimpleBlueprint) ResourcesLibrary.TryGetBlueprint<BlueprintCharacterClass>("6afa347d804838b48bda16acb0573dc0"));
          PrerequisiteStatValue prerequisiteStatValue1 = new PrerequisiteStatValue();
          ((BlueprintComponent) prerequisiteStatValue1).name = "MartialPerformanceBabPrerequisite";
          ((Prerequisite) prerequisiteStatValue1).Group = (Prerequisite.GroupType) 0;
          prerequisiteStatValue1.Stat = (StatType) 7;
          prerequisiteStatValue1.Value = 1;
          PrerequisiteStatValue prerequisiteStatValue2 = prerequisiteStatValue1;
          PrerequisiteClassLevel prerequisiteClassLevel1 = new PrerequisiteClassLevel();
          ((BlueprintComponent) prerequisiteClassLevel1).name = "MartialPerformanceBardPrerequisite";
          prerequisiteClassLevel1.Level = 6;
          ((Prerequisite) prerequisiteClassLevel1).Group = (Prerequisite.GroupType) 1;
          PrerequisiteClassLevel prerequisiteClassLevel2 = prerequisiteClassLevel1;
          AccessTools.FieldRefAccess<PrerequisiteClassLevel, BlueprintCharacterClassReference>(prerequisiteClassLevel2, "m_CharacterClass") = reference2;
          PrerequisiteClassLevel prerequisiteClassLevel3 = new PrerequisiteClassLevel();
          ((BlueprintComponent) prerequisiteClassLevel3).name = "MartialPerformanceSkaldPrerequisite";
          prerequisiteClassLevel3.Level = 6;
          ((Prerequisite) prerequisiteClassLevel3).Group = (Prerequisite.GroupType) 1;
          PrerequisiteClassLevel prerequisiteClassLevel4 = prerequisiteClassLevel3;
          AccessTools.FieldRefAccess<PrerequisiteClassLevel, BlueprintCharacterClassReference>(prerequisiteClassLevel4, "m_CharacterClass") = reference3;
          ClassLevelsForPrerequisites forPrerequisites1 = new ClassLevelsForPrerequisites();
          ((BlueprintComponent) forPrerequisites1).name = "MartialPerformanceBardFighterLevels";
          forPrerequisites1.Modifier = 0.5;
          ClassLevelsForPrerequisites forPrerequisites2 = forPrerequisites1;
          AccessTools.FieldRefAccess<ClassLevelsForPrerequisites, BlueprintCharacterClassReference>(forPrerequisites2, "m_FakeClass") = reference1;
          AccessTools.FieldRefAccess<ClassLevelsForPrerequisites, BlueprintCharacterClassReference>(forPrerequisites2, "m_ActualClass") = reference2;
          ClassLevelsForPrerequisites forPrerequisites3 = new ClassLevelsForPrerequisites();
          ((BlueprintComponent) forPrerequisites3).name = "MartialPerformanceSkaldFighterLevels";
          forPrerequisites3.Modifier = 0.5;
          ClassLevelsForPrerequisites forPrerequisites4 = forPrerequisites3;
          AccessTools.FieldRefAccess<ClassLevelsForPrerequisites, BlueprintCharacterClassReference>(forPrerequisites4, "m_FakeClass") = reference1;
          AccessTools.FieldRefAccess<ClassLevelsForPrerequisites, BlueprintCharacterClassReference>(forPrerequisites4, "m_ActualClass") = reference3;
          BlueprintFeatureSelection featureSelection = new BlueprintFeatureSelection();
          ((SimpleBlueprint) featureSelection).AssetGuid = Main.martialPerformanceGuid;
          ((SimpleBlueprint) featureSelection).name = "MartialPerformance";
          ((BlueprintScriptableObject) featureSelection).ComponentsArray = new BlueprintComponent[5]
          {
            (BlueprintComponent) prerequisiteStatValue2,
            (BlueprintComponent) prerequisiteClassLevel2,
            (BlueprintComponent) prerequisiteClassLevel4,
            (BlueprintComponent) forPrerequisites2,
            (BlueprintComponent) forPrerequisites4
          };
          ((BlueprintFeature) featureSelection).Groups = new FeatureGroup[2]
          {
            (FeatureGroup) 7,
            (FeatureGroup) 74
          };
          ((BlueprintFeature) featureSelection).IsClassFeature = true;
          BlueprintFeatureSelection aggregate = featureSelection;
          ((BlueprintComponent) prerequisiteStatValue2).OwnerBlueprint = (BlueprintScriptableObject) aggregate;
          ((BlueprintComponent) prerequisiteClassLevel2).OwnerBlueprint = (BlueprintScriptableObject) aggregate;
          ((BlueprintComponent) prerequisiteClassLevel4).OwnerBlueprint = (BlueprintScriptableObject) aggregate;
          AccessTools.FieldRefAccess<BlueprintUnitFact, LocalizedString>((BlueprintUnitFact) aggregate, "m_DisplayName") = Main.StartGameLoader_LoadAllJson_Patch.CreateLocalizedString(((SimpleBlueprint) aggregate).name + ".Name", "Martial Performance");
          LocalizedString descriptionLs = Main.StartGameLoader_LoadAllJson_Patch.CreateLocalizedString(((SimpleBlueprint) aggregate).name + ".Description", Main.description);
          AccessTools.FieldRefAccess<BlueprintUnitFact, LocalizedString>((BlueprintUnitFact) aggregate, "m_Description") = descriptionLs;
          AccessTools.FieldRefAccess<BlueprintUnitFact, Sprite>((BlueprintUnitFact) aggregate, "m_Icon") = ((BlueprintUnitFact) weaponFocus).Icon;
          ResourcesLibrary.BlueprintsCache.AddCachedBlueprint(((SimpleBlueprint) aggregate).AssetGuid, (SimpleBlueprint) aggregate);
          BlueprintFeatureReference[] array = Enum.GetValues(typeof (WeaponCategory)).Cast<WeaponCategory>().Select<WeaponCategory, BlueprintFeatureReference>((Func<WeaponCategory, BlueprintFeatureReference>) (weapon =>
          {
            string key = string.Format("MartialPerformance{0}", (object) weapon);
            Type type = AccessTools.Inner(typeof (AddParametrizedFeatures), "FeatureData");
            object instance1 = Activator.CreateInstance(type);
            AccessTools.Field(type, "m_Feature").SetValue(instance1, (object) weaponFocusReference);
            AccessTools.Field(type, "ParamWeaponCategory").SetValue(instance1, (object) weapon);
            Array instance2 = Array.CreateInstance(type, 1);
            instance2.SetValue(instance1, 0);
            AddParametrizedFeatures parametrizedFeatures1 = new AddParametrizedFeatures();
            ((BlueprintComponent) parametrizedFeatures1).name = key + "WeaponFocus";
            AddParametrizedFeatures parametrizedFeatures2 = parametrizedFeatures1;
            AccessTools.Field(((object) parametrizedFeatures2).GetType(), "m_Features").SetValue((object) parametrizedFeatures2, (object) instance2);
            BlueprintFeature blueprintFeature1 = new BlueprintFeature();
            ((SimpleBlueprint) blueprintFeature1).AssetGuid = Main.weaponTypeGuids[key];
            ((SimpleBlueprint) blueprintFeature1).name = key;
            BlueprintFeature blueprintFeature2 = blueprintFeature1;
            BlueprintComponent[] blueprintComponentArray = new BlueprintComponent[2]
            {
              (BlueprintComponent) parametrizedFeatures2,
              null
            };
            PrerequisiteProficiency prerequisiteProficiency = new PrerequisiteProficiency();
            ((BlueprintComponent) prerequisiteProficiency).name = key + "Prerequisite";
            prerequisiteProficiency.WeaponProficiencies = new WeaponCategory[1]
            {
              weapon
            };
            prerequisiteProficiency.ArmorProficiencies = new ArmorProficiencyGroup[0];
            blueprintComponentArray[1] = (BlueprintComponent) prerequisiteProficiency;
            ((BlueprintScriptableObject) blueprintFeature2).ComponentsArray = blueprintComponentArray;
            blueprintFeature1.Groups = new FeatureGroup[2]
            {
              (FeatureGroup) 7,
              (FeatureGroup) 74
            };
            BlueprintFeature blueprintFeature3 = blueprintFeature1;
            AccessTools.FieldRefAccess<BlueprintUnitFact, LocalizedString>((BlueprintUnitFact) blueprintFeature3, "m_DisplayName") = Main.StartGameLoader_LoadAllJson_Patch.CreateLocalizedString(((SimpleBlueprint) blueprintFeature3).name + ".Name", "Martial Performance (" + LocalizedTexts.Instance.Stats.GetText(weapon) + ")");
            AccessTools.FieldRefAccess<BlueprintUnitFact, LocalizedString>((BlueprintUnitFact) blueprintFeature3, "m_Description") = descriptionLs;
            AccessTools.FieldRefAccess<BlueprintUnitFact, Sprite>((BlueprintUnitFact) blueprintFeature3, "m_Icon") = ((BlueprintUnitFact) weaponFocus).Icon;
            ResourcesLibrary.BlueprintsCache.AddCachedBlueprint(((SimpleBlueprint) blueprintFeature3).AssetGuid, (SimpleBlueprint) blueprintFeature3);
            return BlueprintReferenceEx.ToReference<BlueprintFeatureReference>((SimpleBlueprint) blueprintFeature3);
          })).ToArray<BlueprintFeatureReference>();
          Main.StartGameLoader_LoadAllJson_Patch.AddToAllFeaturesArray<BlueprintFeatureSelection, BlueprintFeatureReference>(aggregate, array);
          BlueprintFeatureReference reference4 = BlueprintReferenceEx.ToReference<BlueprintFeatureReference>((SimpleBlueprint) aggregate);
          BlueprintFeatureSelection blueprint1 = ResourcesLibrary.TryGetBlueprint<BlueprintFeatureSelection>("94e2cd84bf3a8e04f8609fe502892f4f");
          BlueprintFeatureSelection blueprint2 = ResourcesLibrary.TryGetBlueprint<BlueprintFeatureSelection>("d2a8fde8985691045b90e1ec57e3cc57");
          BlueprintFeatureReference[] featureReferenceArray = new BlueprintFeatureReference[1]
          {
            reference4
          };
          Main.StartGameLoader_LoadAllJson_Patch.AddToAllFeaturesArray<BlueprintFeatureSelection, BlueprintFeatureReference>(blueprint1, featureReferenceArray);
          Main.StartGameLoader_LoadAllJson_Patch.AddToAllFeaturesArray<BlueprintFeatureSelection, BlueprintFeatureReference>(blueprint2, reference4);
        }
        catch (Exception ex)
        {
          Debug.Log((object) ex);
        }
      }

      private static void AddToAllFeaturesArray<T1, T2>(T1 aggregate, params T2[] itemsToAdd)
      {
        ref T2[] local = ref AccessTools.FieldRefAccess<T1, T2[]>(aggregate, "m_AllFeatures");
        local = ((IEnumerable<T2>) local).Concat<T2>((IEnumerable<T2>) itemsToAdd).ToArray<T2>();
      }

      private static LocalizedString CreateLocalizedString(string key, string value)
      {
        LocalizationManager.CurrentPack.PutString(key, value);
        return new LocalizedString() { Key = key };
      }
    }
  }
}
