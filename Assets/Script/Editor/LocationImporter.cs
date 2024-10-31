using System.Collections;
using UnityEngine;
using Tarahiro;
using Tarahiro.MasterData;
using Tarahiro.Editor.XmlImporter;
using System.Collections.Generic;
using UnityEditor;
using gaw241020.Model;

namespace gaw241020.Editor
{
    internal sealed class LocationImporter
    {
        const string c_XmlPath = "ImportData/Location/Location.xml";
        const string c_SheetName = "Script";
        enum Columns
        {
            Index = 0,
            Id = 1,
            Description = 2,
            EventSituation = 3,
            EventId = 4
        }

        //--------------------------------------------------------------------
        // 読み込み
        //--------------------------------------------------------------------

        [MenuItem("Assets/Tables/Import Location", false, 2)]
        static void ImportMenuLocation()
        {
            var stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();

            Import();

            stopwatch.Stop();
            Log.DebugLog($"Location imported in {stopwatch.ElapsedMilliseconds / 1000.0f} seconds.");
        }

        public static void Import()
        {
            var book = XmlImporter.ImportWorkbook(c_XmlPath);

            var LocationDataList = new List<LocationMasterData.Record>();

            var sheet = book.TryGetWorksheet(c_SheetName);
            if (sheet == null)
            {
                Log.DebugWarning($"シート: {c_SheetName} が見つかりませんでした。");
            }
            else
            {
                for (int row = 0; row < sheet.Height; ++row)
                {
                    // Indexの欄が有効な数字だったら読み込み
                    if (int.TryParse(sheet[row, (int)Columns.Index].String, out int index))
                    {
                        string id = sheet[row, (int)Columns.Id].String;
                        LocationDataList.Add(new LocationMasterData.Record(index, id)
                        {
                            SettableDescription = sheet[row, (int)Columns.Description].String,
                            SettableEventSituation = sheet[row, (int)Columns.EventSituation].String,
                            SettableEventId = sheet[row, (int)Columns.EventId].String,
                        });
                    }
                }
            }

            // データ出力
            XmlImporter.ExportOrderedDictionary<LocationMasterData, LocationMasterData.Record, IMasterDataRecord<ILocationMaster>>(LocationMasterData.c_DataPath, LocationDataList);
        }
    }
}